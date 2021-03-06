using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Infrastructure.Models;
using WebAPI.Infrastructure.Models.VModels;

namespace WebAPI.Infrastructure.Interfaces
{
    public interface IUserMasterRepository
    {
        public List<VMUserMaster> GetUsers(PageModel pageModel);
        public int SaveUser(UserMaster user, int UserID);
        public int DeleteUser(int id, int UserID);
        public UserMaster Authenticate(VMUserLogin userLogin);
        public void SaveToken(string Token, int UserID);
    }
}
