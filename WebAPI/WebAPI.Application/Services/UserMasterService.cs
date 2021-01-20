using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Application.Services;
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
        public  List<UserMaster> GetUsers()
        {
            var data =  _repository.GetUsers();
            return data;
        }
    }
}
