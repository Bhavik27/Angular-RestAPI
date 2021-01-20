using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Infrastructure.Models;

namespace WebAPI.Application.Services
{
    public interface IUserMasterService
    {
        public  List<UserMaster> GetUsers();
    }
}
