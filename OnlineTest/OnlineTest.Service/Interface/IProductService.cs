using OnlineTest.Service.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Service.Interface
{
    public interface IProductService
    {
        /// <summary>
        /// Return product and sort it based on the sort option
        /// </summary>
        /// <param name="sortOption">define how products should be sort</param>
        /// <param name="token">token to access the api</param>
        /// <returns>sorted product</returns>
        Task<List<Product>> GetProducts(string sortOption, string token);
    }
}
