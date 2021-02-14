using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Infrastructure.Models.VModels;

namespace WebAPI.Infrastructure.Interfaces
{
    public interface IRoleMasterRepository
    {
        public List<VMRoleMaster> GetRoles();
        public int SaveRoles(VMRoleMaster roleMaster);
        public List<VMRoleAccess> GeteRoleRights(VMRoleMaster roleMaster);
    }
}
