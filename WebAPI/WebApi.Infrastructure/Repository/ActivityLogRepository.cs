using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Infrastructure.context;
using WebAPI.Infrastructure.Interfaces;
using WebAPI.Infrastructure.Models;

namespace WebAPI.Infrastructure.Repository
{
    public class ActivityLogRepository : IActivityLogRepository
    {
        private WebDbContext _context;
        public ActivityLogRepository(WebDbContext context)
        {
            _context = context;
        }

        public void SetActivityLog(ActivityLog log)
        {
            ActivityLog activity = new ActivityLog();
            activity.Activity = log.Activity;
            activity.ActivityBy = 1;
            activity.ActivityTime = DateTime.Now;
            activity.ActivityType = log.ActivityType;
            _context.ActivityLogs.Add(activity);
            _context.SaveChanges();
        }

    }
}
