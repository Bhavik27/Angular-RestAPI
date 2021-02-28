using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAPI.Infrastructure.context;
using WebAPI.Infrastructure.Interfaces;
using WebAPI.Infrastructure.Models;
using WebAPI.Infrastructure.Models.VModels;

namespace WebAPI.Infrastructure.Repository
{
    public class ActivityLogRepository : IActivityLogRepository
    {
        private WebDbContext _context;
        public ActivityLogRepository(WebDbContext context)
        {
            _context = context;
        }

        public void SetActivityLog(ActivityLog log, int UserId)
        {
            var data = _context.UserMasters.Where(x => x.UserId == UserId).FirstOrDefault();
            ActivityLog activity = new ActivityLog();
            activity.ActivityOn = data.UserId;
            activity.ActivityBy = 1;
            activity.ActivityTime = DateTime.Now;
            activity.ActivityType = log.ActivityType;
            _context.ActivityLogs.Add(activity);
            _context.SaveChanges();
        }


        public List<VMActivityLog> GetActivityLogs(PageModel pageModel)
        {

            var data = (from activity in _context.ActivityLogs
                        join user in _context.UserMasters on activity.ActivityBy equals user.UserId
                        //where activity.ActivityBy > 0
                        select new
                        {
                            ActivityOn = activity.ActivityBy,
                            ActivityByName = activity.ActivityBy,
                            ActivityLogId = activity.ActivityLogId,
                            ActivityTime = activity.ActivityTime,
                            ActivityType = activity.ActivityType
                        }).ToList();
            int totalRecords = data.Count;
            var data2 = (from d in data
                         select new VMActivityLog
                         {
                             ActivityOn = _context.UserMasters.Where(x=>x.UserId == d.ActivityOn)
                                            .Select(x => x.UserName).FirstOrDefault(),
                             ActivityByName = _context.UserMasters.Where(x => x.UserId == d.ActivityByName)
                                            .Select(x => x.UserName).FirstOrDefault(),
                             ActivityLogId = d.ActivityLogId,
                             ActivityTime = d.ActivityTime,
                             ActivityType = d.ActivityType,
                             TotalRecords = totalRecords
                         }).ToList();

            if (pageModel.SortOrder == "desc")
            {
                data2 = PagingUtils.OrderDesc<VMActivityLog>(data2.AsQueryable<VMActivityLog>(), pageModel).ToList();
            }
            else
            {
                data2 = PagingUtils.OrderAsc<VMActivityLog>(data2.AsQueryable<VMActivityLog>(), pageModel).ToList();
            }
            return data2;
        }

    }
}
