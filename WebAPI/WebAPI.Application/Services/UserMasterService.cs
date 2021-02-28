using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Application.Services;
using WebAPI.Infrastructure.Interfaces;
using WebAPI.Infrastructure.Models;
using WebAPI.Infrastructure.Models.VModels;

namespace WebAPI.Application.Interfaces
{
    public class UserMasterService : IUserMasterService
    {
        private IUserMasterRepository _repository;
        public UserMasterService(IUserMasterRepository repository)
        {
            _repository = repository;
        }

        List<VMUserMaster> IUserMasterService.GetUsers(PageModel pageModel)
        {
            var data = _repository.GetUsers(pageModel);
            return data;
        }

        int IUserMasterService.SaveUser(UserMaster user)
        {
            int data = _repository.SaveUser(user);
            return data;
        }

        int IUserMasterService.DeleteUser(int id)
        {
            int data = _repository.DeleteUser(id);
            return data;
        }

        public int Authenticate(VMUserLogin userLogin)
        {
            int data = _repository.Authenticate(userLogin);
            return data;
        }
    }
}
