using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WebAPI.Infrastructure.context;
using WebAPI.Infrastructure.Interfaces;
using WebAPI.Infrastructure.VModels;
using WebAPI.Infrastructure.Models;

namespace WebAPI.Infrastructure.Repository
{
    public class UserMasterRepository : IUserMasterRepository
    {
        private WebDbContext _context;
        public UserMasterRepository(WebDbContext context)
        {
            _context = context;
        }

        public List<VMUserMaster> GetUsers()
        {
            List<VMUserMaster> data = new List<VMUserMaster>();
            data = (from um in _context.userMasters
                    select new VMUserMaster
                    {
                        UserId = um.UserId,
                        UserName = um.UserName,
                        FirstName = um.FirstName,
                        LastName = um.LastName,
                        MailId = um.MailId,
                        Gender = um.Gender,
                        CreatedBy = um.CreatedBy,
                        CreatedTime = um.CreatedTime,
                        UpdatedBy = um.UpdatedBy,
                        UpdatedTime = um.UpdatedTime,
                    }).ToList();
            return data;
        }

        public int SaveUser(UserMaster user)
        {
            if (_context.userMasters.Where(u => u.UserId == user.UserId).FirstOrDefault() == null)
            {
                user.CreatedBy = 1;
                user.CreatedTime = DateTime.Now;
                user.UpdatedBy = null;
                user.UpdatedTime = null;
                _context.Add(user);
                _context.SaveChanges();
            }
            else
            {
                var data = _context.userMasters.FirstOrDefault(u => u.UserId == user.UserId);
                data.UserName = user.UserName;
                data.FirstName = user.FirstName;
                data.LastName = user.LastName;
                data.MailId = user.MailId;
                data.Gender = user.Gender;
                data.DateOfBirth = user.DateOfBirth;
                data.UpdatedTime = DateTime.Now;
                data.UpdatedBy = 1;
                _context.Update(data);
                _context.SaveChanges();
            }
            return 1;
        }
        public int DeleteUser(int id)
        {
            UserMaster vMUser = _context.userMasters.Where(u => u.UserId == id).FirstOrDefault();
            if (vMUser != null)
            {
                _context.userMasters.Remove(vMUser);
                _context.SaveChanges();
                return 1;
            }
            return 0;
        }


    }
}
