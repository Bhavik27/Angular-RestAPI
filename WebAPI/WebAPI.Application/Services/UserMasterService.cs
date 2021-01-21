using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Application.Services;
using WebAPI.Infrastructure.VModels;
using WebAPI.Infrastructure.Interfaces;
using WebAPI.Infrastructure.Models;

namespace WebAPI.Application.Interfaces
{
    public class UserMasterService : IUserMasterService
    {
        private IUserMasterRepository _repository;
        public UserMasterService(IUserMasterRepository repository)
        {
            _repository = repository;
        }

        List<VMUserMaster> IUserMasterService.GetUsers()
        {
            var data = _repository.GetUsers();
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
    }
}
