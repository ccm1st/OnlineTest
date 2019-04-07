using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OnlineTest.Model;
using OnlineTest.Service.Interface;

namespace OnlineTest.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly string _token;
        private readonly string _name;

        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _token = configuration["token"];
            _name = configuration["name"];
        }

        [HttpGet]
        public UserResponse Get()
        {
            var user =  _userService.GetUser(_name);
            return new UserResponse
            {
                Name = user.Name,
                Token = _token
            };
        }

    }
}
