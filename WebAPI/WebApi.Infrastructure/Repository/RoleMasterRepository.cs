using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAPI.Infrastructure.context;
using WebAPI.Infrastructure.Interfaces;
using WebAPI.Infrastructure.Models;

namespace WebAPI.Infrastructure.Repository
{
    public class RoleMasterRepository : IRoleMasterRepository
    {
        private WebDbContext _context;
        public RoleMasterRepository(WebDbContext context)
        {
            _context = context;
        }
        public List<RoleMaster> GetRoles()
        {
            var data = _context.RoleMasters.ToList();
            return data;
        }
    }
}
