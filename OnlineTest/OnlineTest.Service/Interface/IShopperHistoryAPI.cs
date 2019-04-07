using OnlineTest.Service.Domain;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Service.Interface
{
    public interface IShopperHistoryAPI
    {
        [Get("products?token={token}")]
        Task<List<ShopperHistory>> GetShopperHistory(string token);
    }
}
