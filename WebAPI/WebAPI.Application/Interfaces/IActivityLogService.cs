using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Infrastructure.Models.VModels;

namespace WebAPI.Application.Interfaces
{
    public interface IActivityLogService
    {
        public List<VMActivityLog> GetActivityLogs(PageModel pageModel);
    }
}
