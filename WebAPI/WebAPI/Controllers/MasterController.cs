using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Interfaces;
using WebAPI.Infrastructure.Models.VModels;

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
            var data = await Task.FromResult(_service.GetRoles());
            return Ok(data);
        }

        [HttpPost]
        [Route("SaveRoles")]
        public async Task<ActionResult> SaveRoles(VMRoleMaster roleMaster)
        {
            var data = await Task.FromResult(_service.SaveRoles(roleMaster));
            return Ok(data);
        }

        [HttpPost]
        [Route("GeteRoleRights")]
        public async Task<ActionResult> GeteRoleRights(VMRoleMaster roleMaster)
        {
            var data = await Task.FromResult(_service.GeteRoleRights(roleMaster));
            return Ok(data);
        }
    }
}
