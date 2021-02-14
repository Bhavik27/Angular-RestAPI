using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Infrastructure.Models;
using WebAPI.Infrastructure.Models.VModels;

namespace WebAPI.Application.Services
{
    public interface IUserMasterService
    {
        public List<VMUserMaster> GetUsers();
        public int SaveUser(UserMaster user);
        public int DeleteUser(int id);
        public int Authenticate(VMUserLogin userLogin);
    }
}
