using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebAPI.Infrastructure.Models
{
    public class UserOTP
    {
        [Key]
        public int Id { get; set; }
        public int OTP { get; set; }
        public DateTime? CreatedTime { get; set; }
        public int UserID { get; set; }
    }
}
