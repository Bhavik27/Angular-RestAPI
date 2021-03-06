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
                        CreatedBy = d.CreatedBy,
                        CreatedTime = d.CreatedTime,
                        UpdatedBy = d.UpdatedBy,
                        UpdatedTime = d.UpdatedTime,
                        TotalRecords = TotalRecords,
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
            if (_context.UserMasters.Where(u => u.UserId == user.UserId).FirstOrDefault() == null)
            {
                user.CreatedBy = UserID;
                user.Role = 2;
                user.CreatedTime = DateTime.Now;
                user.UpdatedBy = null;
                user.UpdatedTime = null;
                _context.Add(user);
                _context.SaveChanges();

                ActivityLog activity = new ActivityLog();
                activity.ActivityType = "CREATE";
                int UserId = 1;
                _logRepository.SetActivityLog(activity, UserId);
            }
            else
            {
                var data = _context.UserMasters.FirstOrDefault(u => u.UserId == user.UserId);
                data.UserName = user.UserName;
                data.FirstName = user.FirstName;
                data.LastName = user.LastName;
                data.MailId = user.MailId;
                data.Gender = user.Gender;
                data.IsActive = user.IsActive;
                data.DateOfBirth = user.DateOfBirth;
                data.UpdatedTime = DateTime.Now;
                data.UpdatedBy = UserID;
                data.Role = 2;
                _context.Update(data);
                _context.SaveChanges();

                ActivityLog activity = new ActivityLog();
                activity.ActivityType = "UPDATE";
                _logRepository.SetActivityLog(activity, UserID);
            }
            return 1;
        }
        public int DeleteUser(int id, int UserID)
        {
            UserMaster vMUser = _context.UserMasters.Where(u => u.UserId == id).FirstOrDefault();
            if (vMUser != null)
            {
                var tempUser = vMUser.UserName;
                _context.UserMasters.Remove(vMUser);
                _context.SaveChanges();

                ActivityLog activity = new ActivityLog();
                activity.ActivityType = "DELETE";
                _logRepository.SetActivityLog(activity, UserID);
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
    }
}
