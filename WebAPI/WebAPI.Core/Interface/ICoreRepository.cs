using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Core.Interface
{
    public interface ICoreRepository
    {
        public byte[] EncryptString(String str, byte[] Key, byte[] IV);
    }
}
