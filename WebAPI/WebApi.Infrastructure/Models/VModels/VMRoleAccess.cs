using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Infrastructure.Models.VModels
{
    public class VMRoleAccess
    {
        public int RoleAccessId { get; set; }
        public int RoleId { get; set; }
        public string ModuleName { get; set; }
        public int ViewAccess { get; set; }
        public int CreateAccess { get; set; }
        public int UpdateAccess { get; set; }
        public int DeleteAccess { get; set; }
        public int IsView { get; set; }
        public int IsCreate { get; set; }
        public int IsUpdate { get; set; }
        public int IsDelete { get; set; }
    }
}
