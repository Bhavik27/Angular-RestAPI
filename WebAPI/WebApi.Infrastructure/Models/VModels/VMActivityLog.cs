using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Infrastructure.Models.VModels
{
    public class VMActivityLog
    {
        public int ActivityLogId { get; set; }
        public string ActivityOn { get; set; }
        public string ActivityType { get; set; }
        public string ActivityByName { get; set; }
        public DateTime? ActivityTime { get; set; }
        public int TotalRecords { get; set; }
    }
}
