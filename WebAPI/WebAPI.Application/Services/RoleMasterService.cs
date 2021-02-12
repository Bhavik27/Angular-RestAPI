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

        public List<RoleMaster> GetRoles()
        {
            var data = _repository.GetRoles();
            return data;
        }

        public int SaveRoles(VMRoleMaster roleMaster)
        {
            var data = _repository.SaveRoles(roleMaster);
            return data;
        }
    }
}
