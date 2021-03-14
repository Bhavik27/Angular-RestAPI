using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Infrastructure.Models;
using WebAPI.Infrastructure.Models.VModels;

namespace WebAPI.Core.Interface
{
    public interface ICoreRepository
    {
        public byte[] EncryptString(String str, byte[] KEY, byte[] IV);
        public string TokenGenerator(UserMaster user);
        public int MailSender(string Host, int Port, string HostUserName, string HostPassword, VMUser vMUser);

    }
}
