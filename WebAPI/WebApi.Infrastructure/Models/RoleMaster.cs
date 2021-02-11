using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebAPI.Infrastructure.Models
{
    public class RoleMaster
    {
        [Key]
        public int RoleId { get; set; }
        public string Role { get; set; }
        public int ViewAccess { get; set; }
        public int EditAccess { get; set; }
        public int DeleteAccess { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}
