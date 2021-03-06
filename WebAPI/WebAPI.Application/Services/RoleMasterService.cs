using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Application.Interfaces;
using WebAPI.Infrastructure.Interfaces;
using WebAPI.Infrastructure.Models;
using WebAPI.Infrastructure.Models.VModels;

namespace WebAPI.Application.Services
{
    public class RoleMasterService : IRoleMasterService
    {
        private IRoleMasterRepository _repository;
        public RoleMasterService(IRoleMasterRepository repository)
        {
            _repository = repository;
        }

        public List<VMRoleMaster> GetRoles(PageModel pageModel)
        {
            var data = _repository.GetRoles(pageModel);
            return data;
        }

        public int SaveRoles(VMRoleMaster roleMaster, int UserID)
        {
            var data = _repository.SaveRoles(roleMaster, UserID);
            return data;
        }

        public List<VMRoleAccess> GeteRoleRights(int RoleID)
        {
            var data = _repository.GeteRoleRights(RoleID);
            return data;
        }

        public int SetRoleRights(List<VMRoleAccess> vMRoles, int RoleID, int UserID)
        {
            var data = _repository.SetRoleRights(vMRoles, RoleID, UserID);
            return data;
        }
    }
}
