using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Services;
using WebAPI.Infrastructure.Models;
using WebAPI.Infrastructure.VModels;

namespace WebAPI.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IUserMasterService _service;
        public HomeController(IUserMasterService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("api/[controller]/GetUsers")]
        public async Task<ActionResult> GetUsers()
        {
            var result = await Task.FromResult(_service.GetUsers());
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
    }
}
