using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WebAPI.Infrastructure.context;
using WebAPI.Infrastructure.Interfaces;
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

        public List<UserMaster> GetUsers()
        {
            var data = _context.userMasters.ToList();
                            
            if (data != null)
            {
                return data;
            }
            return null;
        }


    }
}
