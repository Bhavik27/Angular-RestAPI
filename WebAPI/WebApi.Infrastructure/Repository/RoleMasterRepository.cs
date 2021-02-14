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
        public List<VMRoleMaster> GetRoles()
        {
            List<VMRoleMaster> data = new List<VMRoleMaster>();

            var data2 = _context.RoleMasters.ToList();
            int totalRecords = data.Count;

            data = (from d in data2
                    select new VMRoleMaster
                    {
                        RoleId = d.RoleId,
                        RoleName = d.RoleName,
                        TotalRecords = totalRecords
                    }).ToList();

            return data;
        }

        public int SaveRoles(VMRoleMaster roleMaster)
        {
            if (_context.RoleMasters.Where(u => u.RoleId == roleMaster.RoleId).FirstOrDefault() == null)
            {
                RoleMaster role = new RoleMaster();
                role.RoleName = roleMaster.RoleName;
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
                data.RoleName = roleMaster.RoleName;
                data.UpdatedTime = DateTime.Now;
                data.UpdatedBy = 1;
                _context.Update(data);
                _context.SaveChanges();
            }
            return 1;
        }

        public List<VMRoleAccess> GeteRoleRights(VMRoleMaster roleMaster)
        {
            var data = (from roles in _context.RoleMasters
                        join roleAccess in _context.RoleAccessMasters
                        on roles.RoleId equals roleAccess.RoleId
                        select new VMRoleAccess
                        {
                            RoleId = roles.RoleId,
                            RoleAccessId = roleAccess.RoleAccessId,
                            AddAccess = roleAccess.AddAccess,
                            InsertAccess = roleAccess.InsertAccess,
                            DeleteAccess = roleAccess.DeleteAccess,
                            ViewAccess = roleAccess.ViewAccess,
                        }).ToList();
            return data;
        }
    }
}
