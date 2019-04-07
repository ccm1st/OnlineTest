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

        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _token = configuration["token"];
        }

        [HttpGet]
        public UserResponse Get()
        {
            var user =  _userService.GetUser();
            return new UserResponse
            {
                Name = user.Name,
                Token = _token
            };
        }

    }
}
