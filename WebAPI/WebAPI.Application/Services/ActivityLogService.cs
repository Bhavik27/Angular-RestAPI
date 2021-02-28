using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Application.Interfaces;
using WebAPI.Infrastructure.Interfaces;
using WebAPI.Infrastructure.Models;
using WebAPI.Infrastructure.Models.VModels;

namespace WebAPI.Application.Services
{
    public class ActivityLogService : IActivityLogService
    {
        private readonly IActivityLogRepository _repository;
        public ActivityLogService(IActivityLogRepository repository)
        {
            _repository = repository;
        }
        public List<VMActivityLog> GetActivityLogs(PageModel pageModel)
        {
            var data = _repository.GetActivityLogs(pageModel);
            return data;
        }
    }
}
