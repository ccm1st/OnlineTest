using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OnlineTest.Model;
using OnlineTest.Service.Domain;
using OnlineTest.Service.Interface;

namespace OnlineTest.Controllers
{
    [Route("api/[controller]")]
    public class TrolleyController : Controller
    {
        private readonly ITrolleyService _trolleySerivce;
        private readonly string _token;

        public TrolleyController(ITrolleyService trolleyService, IConfiguration configuration)
        {
            _trolleySerivce = trolleyService;
            _token = configuration["token"];
        }

        [HttpPost("trolleytotal")]
        public async Task<IActionResult> Calculate([FromBody] Trolley trolley)
        {
            // validation and exception has not been implemented as this is only time with time contraints. 
            // usually you would have at least 3 paths, model error, remote api error, unexpected error. 
            decimal total = await _trolleySerivce.CalculateTotal(_token, trolley);
            return Ok(total);
        }

    }
}
