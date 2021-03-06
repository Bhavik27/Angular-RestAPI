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
        public async Task<ActionResult> SaveUser(UserMaster userMaster)
        {
            int UserID = int.Parse(((ClaimsIdentity)this.User.Identity).Claims.FirstOrDefault(c => c.Type == "UserID").Value);
            var result = await Task.FromResult(_service.SaveUser(userMaster, UserID));
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
    }
}
