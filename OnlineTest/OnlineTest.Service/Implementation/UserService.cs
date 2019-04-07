﻿using OnlineTest.Service.Domain;
using OnlineTest.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineTest.Implementation.Service
{
    public class UserService : IUserService
    {
        public User GetUser()
        {
            return new User
            {
                Name = "test"
            };
        }
    }
}