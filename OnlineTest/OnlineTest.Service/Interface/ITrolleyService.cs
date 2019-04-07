using OnlineTest.Service.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Service.Interface
{
    public interface ITrolleyService
    {
        Task<decimal> CalculateTotal(string token, Trolley trolley);
    }
}
