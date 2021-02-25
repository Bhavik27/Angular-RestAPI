using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebAPI.Infrastructure.Models
{
    public class ModuleMaster
    {
        [Key]
        public int  ModuleId  { get; set; }
        public string ModuleName { get; set; }
        public int IsView { get; set; }
        public int IsCreate { get; set; }
        public int IsUpdate { get; set; }
        public int IsDelete { get; set; }
    }
}
