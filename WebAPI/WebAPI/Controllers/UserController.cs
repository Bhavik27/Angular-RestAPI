using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Services;
using WebAPI.Infrastructure.Models;
using WebAPI.Infrastructure.Models.VModels;

namespace WebAPI.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserMasterService _service;
        public UserController(IUserMasterService service)
        {
            _service = service;
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
            var result = await Task.FromResult(_service.SaveUser(userMaster));
            return Ok(result);
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteUser/{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var result = await Task.FromResult(_service.DeleteUser(id));
            return Ok(result);
        }

        [HttpPost]
        [Route("api/[controller]/Authenticate")]
        public async Task<ActionResult> Authenticate(VMUserLogin userLogin)
        {
            var result = await Task.FromResult(_service.Authenticate(userLogin));
            return Ok(result);
        }
    }
}
