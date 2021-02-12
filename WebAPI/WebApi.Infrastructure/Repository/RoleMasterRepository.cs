using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAPI.Infrastructure.context;
using WebAPI.Infrastructure.Interfaces;
using WebAPI.Infrastructure.Models;
using WebAPI.Infrastructure.Models.VModels;

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

        public int SaveRoles(VMRoleMaster roleMaster)
        {
            if(_context.RoleMasters.Where(u => u.RoleId == roleMaster.RoleId).FirstOrDefault() == null)
            {
                RoleMaster role = new RoleMaster();
                role.Role = roleMaster.Role;
                role.CreatedBy = 1;
                role.CreatedTime = DateTime.Now;
                role.UpdatedBy = null;
                role.UpdatedTime = null;
                _context.Add(role);
                _context.SaveChanges();
            }
            else
            {
                var data = _context.RoleMasters.FirstOrDefault(u => u.RoleId == roleMaster.RoleId);
                data.Role = roleMaster.Role;
                data.UpdatedTime = DateTime.Now;
                data.UpdatedBy = 1;
                _context.Update(data);
                _context.SaveChanges();
            }
            return 1;
        }

        public int ManageRoleRights(RoleMaster roleMaster)
        {
            if(_context.RoleMasters.FirstOrDefault(r => r.RoleId == roleMaster.RoleId) == null)
            {
                _context.RoleMasters.Add(roleMaster);
                _context.SaveChanges();
                return 1;
            }
            return 0;
        }
    }
}
