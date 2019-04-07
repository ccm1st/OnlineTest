using OnlineTest.Service.Domain;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Service.Interface
{
    public interface ITrolleyAPI
    {
        [Post("/api/resource/trolleyCalculator?token={token}")]
        Task<decimal> Calculate(string token, [Body] Trolley trolley);
    }
}
