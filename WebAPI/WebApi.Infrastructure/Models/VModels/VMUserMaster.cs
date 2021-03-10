using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Infrastructure.Models.VModels
{
    public class VMUserMaster
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int IsActive { get; set; }
        public string Gender { get; set; }
        public string MailId { get; set; }
        public int Role { get; set; }
        public int TotalRecords { get; set; }
    }
}
