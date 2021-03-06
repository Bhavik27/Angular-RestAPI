using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Infrastructure.Models;
using WebAPI.Infrastructure.Models.VModels;

namespace WebAPI.Application.Services
{
    public interface IUserMasterService
    {
        public List<VMUserMaster> GetUsers(PageModel pageModel);
        public int SaveUser(UserMaster user, int UserID);
        public int DeleteUser(int id, int UserID);
        public VMUserLoginRespose Authenticate(VMUserLogin userLogin, byte[] Key, byte[] IV);
    }
}
