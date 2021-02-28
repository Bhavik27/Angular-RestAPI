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
        public int SaveUser(UserMaster user);
        public int DeleteUser(int id);
        public int Authenticate(VMUserLogin userLogin);
    }
}
