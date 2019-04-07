using OnlineTest.Service.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineTest.Service.Interface
{
    public interface IUserService
    {
        User GetUser(string name);
    }
}
