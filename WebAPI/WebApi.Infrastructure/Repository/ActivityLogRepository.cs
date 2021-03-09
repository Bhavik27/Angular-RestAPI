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

        public void SetActivityLog(ActivityLog log, int ModifiedId, int ModiferId)
        {
            ActivityLog activity = new ActivityLog();
            if (log.ActivityFor == "User")
            {
                var data = _context.UserMasters.Where(x => x.UserId == ModifiedId).FirstOrDefault();
                activity.ActivityOn = data.UserId;
                activity.ActivityBy = ModiferId;
                activity.ActivityTime = DateTime.Now;
                activity.ActivityType = log.ActivityType;
                activity.ActivityFor = log.ActivityFor;
            }
            if (log.ActivityFor == "Role")
            {
                var data = _context.RoleMasters.Where(x => x.RoleId == ModifiedId).FirstOrDefault();
                activity.ActivityOn = data.RoleId;
                activity.ActivityBy = ModiferId;
                activity.ActivityTime = DateTime.Now;
                activity.ActivityType = log.ActivityType;
                activity.ActivityFor = log.ActivityFor;
            }
            _context.ActivityLogs.Add(activity);
            _context.SaveChanges();
        }


        public List<VMActivityLog> GetActivityLogs(PageModel pageModel)
        {

            var data = (from activity in _context.ActivityLogs
                        join user in _context.UserMasters on activity.ActivityBy equals user.UserId
                        join role in _context.RoleMasters on user.Role equals role.RoleId
                        //where activity.ActivityBy > 0
                        select new
                        {
                            ActivityOn = activity.ActivityOn,
                            ActivityByName = activity.ActivityBy,
                            ActivityLogId = activity.ActivityLogId,
                            ActivityTime = activity.ActivityTime,
                            ActivityType = activity.ActivityType,
                            ActivityFor = activity.ActivityFor
                        }).ToList();
            int totalRecords = data.Count;

            var data2 = (from d in data
                         select new VMActivityLog
                         {
                             ActivityOn = (d.ActivityFor == "Role") ? _context.RoleMasters
                                                                                    .Where(x => x.RoleId == d.ActivityOn)
                                                                                    .Select(x => x.RoleName).FirstOrDefault()
                                                                    : _context.UserMasters
                                                                                    .Where(x => x.UserId == d.ActivityOn)
                                                                                    .Select(x => x.UserName).FirstOrDefault(),
                             ActivityByName = _context.UserMasters.Where(x => x.UserId == d.ActivityByName)
                                            .Select(x => x.UserName).FirstOrDefault(),
                             ActivityLogId = d.ActivityLogId,
                             ActivityTime = d.ActivityTime,
                             ActivityType = d.ActivityType,
                             ActivityFor = d.ActivityFor,
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
