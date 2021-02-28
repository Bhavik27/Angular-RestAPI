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
        private readonly IRoleMasterService _roleService;
        private readonly IActivityLogService _activityService;
        public MasterController(IRoleMasterService roleService, IActivityLogService activityService)
        {
            _roleService = roleService;
            _activityService = activityService;
        }


        [HttpPost]
        [Route("GetRoles")]
        public async Task<ActionResult> GetRoles(PageModel pageModel)
        {
            var data = await Task.FromResult(_roleService.GetRoles(pageModel));
            return Ok(data);
        }

        [HttpPost]
        [Route("SaveRoles")]
        public async Task<ActionResult> SaveRoles(VMRoleMaster roleMaster)
        {
            var data = await Task.FromResult(_roleService.SaveRoles(roleMaster));
            return Ok(data);
        }

        [HttpGet]
        [Route("GeteRoleRights/{RoleID}")]
        public async Task<ActionResult> GeteRoleRights(int RoleID)
        {
            var data = await Task.FromResult(_roleService.GeteRoleRights(RoleID));
            return Ok(data);
        }

        [HttpPost]
        [Route("SetRoleRights/{RoleID}")]
        public async Task<ActionResult> SetRoleRights(List<VMRoleAccess> vMRoles, int RoleID)
        {
            var data = await Task.FromResult(_roleService.SetRoleRights(vMRoles, RoleID));
            return Ok(data);
        }

        [HttpPost]
        [Route("GetActivityLogs")]
        public async Task<ActionResult> GetActivityLogs(PageModel pageModel)
        {
            var data = await Task.FromResult(_activityService.GetActivityLogs(pageModel));
            return Ok(data);
        }

    }
}
