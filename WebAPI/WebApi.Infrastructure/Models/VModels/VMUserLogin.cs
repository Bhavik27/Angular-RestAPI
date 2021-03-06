using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Infrastructure.Models.VModels
{
    public class VMUserLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }


    public class VMUserLoginRespose {
        public int RoleID { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }

    }


}
