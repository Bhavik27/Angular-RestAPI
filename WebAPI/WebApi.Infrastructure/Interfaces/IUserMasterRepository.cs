using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Infrastructure.Models;

namespace WebAPI.Infrastructure.Interfaces
{
    public interface IUserMasterRepository
    {
        public List<UserMaster> GetUsers();
    }
}
