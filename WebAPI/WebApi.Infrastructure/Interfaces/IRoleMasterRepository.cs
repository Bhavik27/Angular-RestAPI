using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Infrastructure.Models;
using WebAPI.Infrastructure.Models.VModels;

namespace WebAPI.Infrastructure.Interfaces
{
    public interface IRoleMasterRepository
    {
        public List<VMRoleMaster> GetRoles(PageModel pageModel);
        public int SaveRoles(VMRoleMaster roleMaster, int UserID);
        public List<VMRoleAccess> GeteRoleRights(int RoleID);
        public int SetRoleRights(List<VMRoleAccess> vMRoles, int RoleID, int UserID);
    }
}
