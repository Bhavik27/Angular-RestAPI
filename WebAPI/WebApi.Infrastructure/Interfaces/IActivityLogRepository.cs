﻿using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Infrastructure.Models;
using WebAPI.Infrastructure.Models.VModels;

namespace WebAPI.Infrastructure.Interfaces
{
    public interface IActivityLogRepository
    {
        public void SetActivityLog(ActivityLog log, int UserId);
        public List<VMActivityLog> GetActivityLogs(PageModel pageModel);
    }
}
