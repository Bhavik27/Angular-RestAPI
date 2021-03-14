using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Core.Interface;
using WebAPI.Infrastructure.Models;
using WebAPI.Infrastructure.Models.VModels;

namespace WebAPI.Core.Repository
{
    public class CoreRepository : ICoreRepository
    {
        public CoreRepository()
        {

        }

        public byte[] EncryptString(string str, byte[] KEY, byte[] IV)
        {
            byte[] encrypted;
            using (Aes aes = Aes.Create())
            {
                ICryptoTransform encrypter = aes.CreateEncryptor(KEY, IV);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encrypter, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(str);
                        }
                        encrypted = memoryStream.ToArray();
                    }
                }
            }
            return encrypted;

        }

        public string TokenGenerator(UserMaster user)
        {
            string SecurityKey = "my top secret key";
            string Token;
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityKey));

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim("UserID", user.UserId.ToString()),
                    new Claim("RoleID", user.Role.ToString()),
                    new Claim("UserName", user.UserName)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            Token = tokenHandler.WriteToken(securityToken);
            return Token;
        }


        public int MailSender(string Host, int Port, string HostUserName, string HostPassword, VMUser vMUser)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient(Host)
                {
                    Port = Port,
                    Credentials = new NetworkCredential(HostUserName, HostPassword),
                    EnableSsl = true,
                    UseDefaultCredentials=false
                };
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(HostUserName),
                    Subject = "OTP - Admin Panel",
                    Body = "<h2>Hello " + vMUser.UserName + ",</h2>" +
                            "<br><br>Your OTP is : <b>" + vMUser.OTP + "</b>",
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(vMUser.MailId);

                smtpClient.Send(mailMessage);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 0;
            }
        }

    }
}
