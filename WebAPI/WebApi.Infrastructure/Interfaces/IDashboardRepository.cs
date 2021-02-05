using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Infrastructure.Models.VModels;

namespace WebAPI.Infrastructure.Interfaces
{
    public interface IDashboardRepository
    {
        public DashboardModel GetChartData();
    }
}
