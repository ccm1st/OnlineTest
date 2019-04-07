using OnlineTest.Service.Domain;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Service.Interface
{
    public interface IProductAPI
    {
        [Get("/api/resource/products?token={token}")]
        Task<List<Product>> GetProducts(string token);
    }
}
