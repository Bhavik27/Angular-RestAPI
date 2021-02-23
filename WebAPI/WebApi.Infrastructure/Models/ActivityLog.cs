using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebAPI.Infrastructure.Models
{
    public class ActivityLog
    {
        [Key]
        public int ActivityLogId { get; set; }
        public string Activity { get; set; }
        public string ActivityType { get; set; }
        public int ActivityBy { get; set; }
        public DateTime? ActivityTime { get; set; }
    }
}
