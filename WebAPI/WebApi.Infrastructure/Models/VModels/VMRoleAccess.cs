using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Infrastructure.Models.VModels
{
    public class VMRoleAccess
    {
        public int RoleAccessId { get; set; }
        public int RoleId { get; set; }
        public int ViewAccess { get; set; }
        public int AddAccess { get; set; }
        public int InsertAccess { get; set; }
        public int DeleteAccess { get; set; }
    }
}
