using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Infrastructure.Models.VModels;

namespace WebAPI.Application.Interfaces
{
    public interface IDashboardService
    {
        public DashboardModel GetChartData();
    }
}
