using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Interfaces;

namespace WebAPI.Controllers
{
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        private IDashboardService _service;
        public DashBoardController(IDashboardService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("api/[controller]/GetChartData")]
        public async Task<IActionResult> GetChartData()
        {
            var data = Task.FromResult(_service.GetChartData());
            return Ok(data.Result);
        }

    }
}
