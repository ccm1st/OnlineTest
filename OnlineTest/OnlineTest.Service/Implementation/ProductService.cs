using OnlineTest.Service.Domain;
using OnlineTest.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Service.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductAPI _productAPI;
        private readonly IShopperHistoryAPI _shopperHistoryAPI;

        public ProductService(IProductAPI productAPI, IShopperHistoryAPI shopperHistoryAPI)
        {
            _productAPI = productAPI;
            _shopperHistoryAPI = shopperHistoryAPI;
        }

        /// <summary>
        /// Return product and sort it based on the sort option
        /// </summary>
        /// <param name="sortOption">define how products should be sort</param>
        /// <param name="token">token to access the api</param>
        /// <returns>sorted product</returns>
        public async Task<List<Product>> GetProducts(string sortOption, string token)
        {

            var option = ParseOption(sortOption);
            var products = await _productAPI.GetProducts(token);

            List<Product> result;
            if (option == SortOption.Recommended)
            {
                result = await SortByPopularity(token, products);
            }
            else
            {
                result = SortByProductAttribute(option, products);
            }

            return result;
        }

        private static List<Product> SortByProductAttribute(SortOption option, List<Product> products)
        {
            List<Product> result;
            // it's safe to ignored invalid and other valid options as it's been handle prior to this. 
            switch (option)
            {
                case SortOption.Low:
                    result = products.OrderBy(a => a.Price).ToList();
                    break;
                case SortOption.High:
                    result = products.OrderByDescending(a => a.Price).ToList();
                    break;
                case SortOption.Ascending:
                    result = products.OrderBy(a => a.Name).ToList();
                    break;
                case SortOption.Descending:
                default:
                    result = products.OrderByDescending(a => a.Name).ToList();
                    break;
            }

            return result;
        }

        private async Task<List<Product>> SortByPopularity(string token, List<Product> allProducts)
        {
            var shopperHistory = await _shopperHistoryAPI.GetShopperHistory(token);

            var purchasedProducts = shopperHistory.SelectMany(a => a.Products);

            var popularProducts = allProducts.GroupJoin(purchasedProducts, product => product.Name, pp => pp.Name,
                (product, matchedPurchase) =>
                {
                    int count = matchedPurchase == null ? 0 : matchedPurchase.Count();

                    return new
                    {
                        Product = product,
                        Popularity = count
                    };
                }
            );

            return popularProducts.OrderByDescending(a => a.Popularity).Select(a => a.Product).ToList();
        }

        private SortOption ParseOption(string sortOption)
        {
            SortOption result;

            if (Enum.TryParse(sortOption, true, out result))
            {
                return result;
            }
            throw new InvalidCastException("the sort option is invalid");
        }
    }
}
