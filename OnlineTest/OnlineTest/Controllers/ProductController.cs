using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OnlineTest.Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineTest.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly string _token;

        public ProductController(IProductService productService, IConfiguration configuration)
        {
            _productService = productService;
            _token = configuration["token"];
        }

        // GET: api/<controller>
        [HttpGet("sort")]
        public async Task<IActionResult> Get(string sortOption)
        {
            var result = await _productService.GetProducts(sortOption, _token);
            return Ok(result);
        }
    }
}
