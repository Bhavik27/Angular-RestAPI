using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Interfaces;
using WebAPI.Infrastructure.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MasterController : ControllerBase
    {
        private IRoleMasterService _service;
        public MasterController(IRoleMasterService service)
        {
            _service = service;
        }


        [HttpGet]
        [Route("GetRoles")]
        public async Task<ActionResult> GetRoles()
        {
            var data = Task.FromResult(_service.GetRoles());
            return Ok(data.Result);
        }
    }
}
