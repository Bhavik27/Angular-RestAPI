using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WebAPI.Infrastructure.context;
using WebAPI.Infrastructure.Interfaces;
using WebAPI.Infrastructure.Models;
using WebAPI.Infrastructure.Models.VModels;

namespace WebAPI.Infrastructure.Repository
{
    public class UserMasterRepository : IUserMasterRepository
    {
        private WebDbContext _context;
        private readonly IActivityLogRepository _logRepository;
        public UserMasterRepository(WebDbContext context, IActivityLogRepository logRepository)
        {
            _context = context;
            _logRepository = logRepository;
        }

        public List<VMUserMaster> GetUsers(PageModel pageModel)
        {
            List<VMUserMaster> data = new List<VMUserMaster>();
            var data2 = _context.UserMasters.ToList();
            int TotalRecords = data2.Count;
            data = (from d in data2
                    select new VMUserMaster
                    {
                        UserId = d.UserId,
                        UserName = d.UserName,
                        FirstName = d.FirstName,
                        LastName = d.LastName,
                        MailId = d.MailId,
                        Gender = d.Gender,
                        DateOfBirth = d.DateOfBirth,
                        IsActive = d.IsActive,
                        TotalRecords = TotalRecords
                    }).ToList();
            if (pageModel.SortOrder == "desc")
            {
                data = PagingUtils.OrderDesc<VMUserMaster>(data.AsQueryable<VMUserMaster>(), pageModel).ToList();
            }
            else
            {
                data = PagingUtils.OrderAsc<VMUserMaster>(data.AsQueryable<VMUserMaster>(), pageModel).ToList();
            }
            return data;
        }

        public int SaveUser(UserMaster user, int UserID)
        {
            var data = _context.UserMasters.Where(u => u.UserId == user.UserId).FirstOrDefault();
            if (data == null)
            {
                user.CreatedBy = UserID;
                user.Role = 2;
                user.CreatedTime = DateTime.Now;
                user.UpdatedBy = null;
                user.UpdatedTime = null;
                _context.Add(user);
                _context.SaveChanges();

                int id = user.UserId;
                ActivityLog activity = new ActivityLog();
                activity.ActivityType = "created";
                activity.ActivityFor = "User";
                _logRepository.SetActivityLog(activity, id, UserID);
            }
            else
            {
                data.UserName = user.UserName;
                data.FirstName = user.FirstName;
                data.LastName = user.LastName;
                data.MailId = user.MailId;
                data.Gender = user.Gender;
                data.IsActive = user.IsActive;
                data.DateOfBirth = user.DateOfBirth;
                data.UpdatedTime = DateTime.Now;
                data.UpdatedBy = UserID;
                //data.Role = user.Role;
                _context.Update(data);
                _context.SaveChanges();

                ActivityLog activity = new ActivityLog();
                activity.ActivityType = "updated";
                activity.ActivityFor = "User";
                _logRepository.SetActivityLog(activity, data.UserId, UserID);
            }
            return 1;
        }

        public int DeleteUser(int id, int UserID)
        {
            UserMaster vMUser = _context.UserMasters.Where(u => u.UserId == id).FirstOrDefault();
            if (vMUser != null)
            {
                var tempUserID = vMUser.UserId;
                //_context.UserMasters.Remove(vMUser);
                _context.SaveChanges();

                ActivityLog activity = new ActivityLog();
                activity.ActivityType = "removed";
                activity.ActivityFor = "User";
                _logRepository.SetActivityLog(activity, tempUserID, UserID);
                return 1;
            }
            return 0;
        }

        public UserMaster Authenticate(VMUserLogin userLogin)
        {
            return _context.UserMasters
                .Where(x => x.UserName == userLogin.UserName && x.Password == userLogin.Password)
                .FirstOrDefault();
        }


        public void SaveToken(string Token, int UserID)
        {
            TokenMaster data = new TokenMaster();
            data.jwtToken = Token;
            data.CreatedBy = UserID;
            data.CreatedTime = DateTime.Now;
            _context.TokenMasters.Add(data);
            _context.SaveChanges();
        }

        public VMUserMaster ProfileData(int UserID)
        {
            var data = (from user in _context.UserMasters
                        where user.UserId == UserID
                        select new VMUserMaster
                        {
                            UserId = user.UserId,
                            UserName = user.UserName,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            DateOfBirth = user.DateOfBirth,
                            Gender = user.Gender,
                            IsActive = user.IsActive,
                            MailId = user.MailId,
                            Role = user.Role
                        }).FirstOrDefault();
            return data;
        }

        public int UpdateProfile(VMUserMaster vMUser)
        {
            var data = _context.UserMasters.Where(user => user.UserId == vMUser.UserId).FirstOrDefault();
            if (data != null)
            {
                data.UserName = vMUser.UserName;
                data.FirstName = vMUser.FirstName;
                data.LastName = vMUser.LastName;
                data.MailId = vMUser.MailId;
                data.Gender = vMUser.Gender;
                data.IsActive = vMUser.IsActive;
                data.DateOfBirth = vMUser.DateOfBirth;
                data.UpdatedTime = DateTime.Now;
                data.UpdatedBy = vMUser.UserId;
                data.Role = vMUser.Role;
                _context.Update(data);
                _context.SaveChanges();

                ActivityLog activity = new ActivityLog();
                activity.ActivityType = "updated";
                activity.ActivityFor = "Profile";
                _logRepository.SetActivityLog(activity, vMUser.UserId, vMUser.UserId);
                return 1;
            }
            return 0;
        }

        public int ResetPassword(string userName, string newPassword, int UserID)
        {
            var data = _context.UserMasters.Where(user => user.UserId == UserID && user.UserName == userName).FirstOrDefault();
            if (data != null)
            {
                data.Password = newPassword;
                _context.UserMasters.Update(data);
                _context.SaveChanges();
                return 1;
            }
            return 0;
        }
    }
}
