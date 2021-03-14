using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebAPI.Application.Services;
using WebAPI.Infrastructure.Models;
using WebAPI.Infrastructure.Models.VModels;

namespace WebAPI.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserMasterService _service;
        private readonly IConfiguration _configuration;
        public UserController(IUserMasterService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("api/[controller]/GetUsers")]
        public async Task<ActionResult> GetUsers(PageModel pageModel)
        {
            var result = await Task.FromResult(_service.GetUsers(pageModel));
            return Ok(result);
        }

        [HttpPost]
        [Route("api/[controller]/SaveUser")]
        public async Task<ActionResult> SaveUser(VMUserMaster vMUser)
        {
            int UserID = int.Parse(((ClaimsIdentity)this.User.Identity).Claims.FirstOrDefault(c => c.Type == "UserID").Value);
            var result = await Task.FromResult(_service.SaveUser(vMUser, UserID));
            return Ok(result);
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteUser/{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            int UserID = int.Parse(((ClaimsIdentity)this.User.Identity).Claims.FirstOrDefault(c => c.Type == "UserID").Value);
            var result = await Task.FromResult(_service.DeleteUser(id, UserID));
            return Ok(result);
        }

        [HttpPost]
        [Route("api/[controller]/Authenticate")]
        public async Task<ActionResult> Authenticate(VMUserLogin userLogin)
        {
            byte[] Key = Convert.FromBase64String(_configuration.GetSection("Encryption").GetSection("Key").Value);
            byte[] IV = Convert.FromBase64String(_configuration.GetSection("Encryption").GetSection("IV").Value);
            var result = await Task.FromResult(_service.Authenticate(userLogin, Key, IV));
            return Ok(result);
        }


        [HttpGet]
        [Route("api/[controller]/ProfileData")]
        public async Task<IActionResult> ProfileData()
        {
            int UserID = int.Parse(((ClaimsIdentity)this.User.Identity).Claims.FirstOrDefault(c => c.Type == "UserID").Value);
            var result = await Task.FromResult(_service.ProfileData(UserID));
            return Ok(result);
        }

        [HttpPost]
        [Route("api/[controller]/UpdateProfile")]
        public async Task<IActionResult> UpdateProfile(VMUserMaster vMUser)
        {
            var result = await Task.FromResult(_service.UpdateProfile(vMUser));
            return Ok(result);
        }

        [HttpPost]
        [Route("api/[controller]/ResetPassword")]
        public async Task<IActionResult> ResetPassword(string MailAddress, string newPassword)
        {
            byte[] Key = Convert.FromBase64String(_configuration.GetSection("Encryption").GetSection("Key").Value);
            byte[] IV = Convert.FromBase64String(_configuration.GetSection("Encryption").GetSection("IV").Value);
            var result = await Task.FromResult(_service.ResetPassword(MailAddress, newPassword, Key, IV));
            return Ok(result);
        }

        [HttpPost]
        [Route("api/[controller]/GetOTP")]
        public async Task<IActionResult> GetOTP(string MailAddress)
        {
            string _Host = _configuration.GetSection("SMTP").GetSection("Host").Value;
            int _Port = int.Parse(_configuration.GetSection("SMTP").GetSection("Port").Value);
            string _UserName = _configuration.GetSection("SMTP").GetSection("UserName").Value;
            string _Password = _configuration.GetSection("SMTP").GetSection("Password").Value;
            var result = await Task.FromResult(_service.GetOTP(_Host, _Port, _UserName, _Password, MailAddress));
            return Ok(result);
        }

        [HttpPost]
        [Route("api/[controller]/CheckOTP")]
        public async Task<IActionResult> CheckOTP(string MailAddress, int OTP)
        {
            var result = await Task.FromResult(_service.CheckOTP(MailAddress, OTP));
            return Ok(result);
        }
    }
}
