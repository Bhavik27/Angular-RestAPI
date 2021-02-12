using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Infrastructure.Models;
using WebAPI.Infrastructure.Models.VModels;

namespace WebAPI.Application.Interfaces
{
    public interface IRoleMasterService
    {
        public List<RoleMaster> GetRoles();

        public int SaveRoles(VMRoleMaster roleMaster);
    }
}
