﻿using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Infrastructure.Models;
using WebAPI.Infrastructure.VModels;

namespace WebAPI.Infrastructure.Interfaces
{
    public interface IUserMasterRepository
    {
        public List<VMUserMaster> GetUsers();
        public int SaveUser(UserMaster user);
        public int DeleteUser(int id);
    }
}