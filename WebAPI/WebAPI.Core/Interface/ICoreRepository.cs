using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Infrastructure.Models;

namespace WebAPI.Core.Interface
{
    public interface ICoreRepository
    {
        public byte[] EncryptString(String str, byte[] Key, byte[] IV);

        public string TokenGenerator(UserMaster user);
    }
}
