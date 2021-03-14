using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Infrastructure.Models;
using WebAPI.Infrastructure.Models.VModels;

namespace WebAPI.Infrastructure.Interfaces
{
    public interface IUserMasterRepository
    {
        public List<VMUserMaster> GetUsers(PageModel pageModel);
        public int SaveUser(UserMaster user, int UserID);
        public int DeleteUser(int id, int UserID);
        public UserMaster Authenticate(VMUserLogin userLogin);
        public VMUserMaster ProfileData(int UserID);
        public int UpdateProfile(VMUserMaster vMUser);
        public int ResetPassword(string MailAddress, string newPassword);
        public VMUser GetUser( string ToMailAddress);
        public int CheckOTP(string MailAddress, int OTP);
    }
}
