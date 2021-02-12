using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Infrastructure.Models;
using WebAPI.Infrastructure.Models.VModels;

namespace WebAPI.Infrastructure.Interfaces
{
    public interface IRoleMasterRepository
    {
        public List<RoleMaster> GetRoles();
        public int SaveRoles(VMRoleMaster roleMaster);
    }
}
