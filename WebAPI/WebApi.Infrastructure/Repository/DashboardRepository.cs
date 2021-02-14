using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAPI.Infrastructure.context;
using WebAPI.Infrastructure.Interfaces;
using WebAPI.Infrastructure.Models;

namespace WebAPI.Infrastructure.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private WebDbContext _context;
        public DashboardRepository(WebDbContext context)
        {
            _context = context;
        }
        public DashboardModel GetChartData()
        {
            var data = _context.UserMasters.ToList();
            if (data.Count > 0)
            {
                DashboardModel model = (from d in data
                                        group d by 1 into grp
                                        select new DashboardModel
                                        {
                                            Male = grp.Sum(x => x.Gender == "M" ? 1 : 0),
                                            Female = grp.Sum(x => x.Gender == "F" ? 1 : 0),
                                            Other = grp.Sum(x => x.Gender == "O" ? 1 : 0),
                                        }).FirstOrDefault();
                return model;
            }
            else
            {
                return new DashboardModel
                {
                    Male = 0,
                    Female = 0,
                    Other = 0
                };
            }
        }

    }
}
