using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Services;
using WebAPI.Infrastructure.Models;

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
    }
}
