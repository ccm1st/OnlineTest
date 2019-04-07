using OnlineTest.Service.Domain;
using OnlineTest.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineTest.Service.Implementation.Service
{
    public class UserService : IUserService
    {
        public User GetUser(string name)
        {
            return new User
            {
                Name = name
            };
        }
    }
}
