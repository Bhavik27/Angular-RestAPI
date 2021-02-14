using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Infrastructure.Models.VModels
{
    public class VMRoleMaster
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int TotalRecords { get; set; }
    }
}
