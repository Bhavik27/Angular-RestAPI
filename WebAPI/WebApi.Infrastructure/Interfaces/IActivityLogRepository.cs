using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Infrastructure.Models;

namespace WebAPI.Infrastructure.Interfaces
{
    public interface IActivityLogRepository
    {
        public void SetActivityLog(ActivityLog log);
    }
}
