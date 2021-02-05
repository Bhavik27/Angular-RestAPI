using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Application.Interfaces;
using WebAPI.Infrastructure.Interfaces;
using WebAPI.Infrastructure.Models.VModels;

namespace WebAPI.Application.Services
{
    public class DashboardService : IDashboardService
    {
        private IDashboardRepository _repository;
        public DashboardService(IDashboardRepository repository)
        {
            _repository = repository;
        }
        public DashboardModel GetChartData()
        {
            var data = _repository.GetChartData();
            return data;
        }
    }
}
