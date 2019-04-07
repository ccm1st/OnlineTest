using Moq;
using OnlineTest.Service.Domain;
using OnlineTest.Service.Implementation;
using OnlineTest.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OnlineTest.Service.UnitTest
{
    public class ProductServiceTest
    {
        private readonly Mock<IProductAPI> _mockProductAPI;
        private readonly Mock<IShopperHistoryAPI> _mockShopperHistoryAPI;
        public ProductServiceTest()
        {
            _mockProductAPI = new Mock<IProductAPI>();
            _mockShopperHistoryAPI = new Mock<IShopperHistoryAPI>();
        }

        [Theory]
        [MemberData(nameof(PricingLowToHigh))]
        [MemberData(nameof(PricingHighToLow))]
        public async Task GetProducts_GivenSortOptionForPrice_ProductsOrderedByPrice(string sortOption, List<Product> input, List<Product> expected)
        {
            // arrange
            _mockProductAPI.Setup(p => p.GetProducts(It.IsAny<string>())).ReturnsAsync(input);
            ProductService sut = new ProductService(_mockProductAPI.Object, _mockShopperHistoryAPI.Object);

            // act
            var actual = await sut.GetProducts(sortOption, It.IsAny<string>());

            // assert
            Assert.Equal(actual, expected);
        }

        [Theory]
        [MemberData(nameof(NameAscending))]
        [MemberData(nameof(NameDescending))]
        public async Task GetProducts_GivenSortOptionForName_ProductsOrderedByName(string sortOption, List<Product> input, List<Product> expected)
        {
            // arrange
            _mockProductAPI.Setup(p => p.GetProducts(It.IsAny<string>())).ReturnsAsync(input);
            ProductService sut = new ProductService(_mockProductAPI.Object, _mockShopperHistoryAPI.Object);

            // act
            var actual = await sut.GetProducts(sortOption, It.IsAny<string>());

            // assert
            Assert.Equal(actual, expected);
        }


        [Theory]
        [MemberData(nameof(PopularProducts))]
        public async Task GetProducts_GivenSortOptionForPopularity_ProductsOrderedByPopularity(string sortOption, List<Product> input, List<ShopperHistory> shopperHistory, List<Product> expected)
        {
            // arrange
            _mockProductAPI.Setup(p => p.GetProducts(It.IsAny<string>())).ReturnsAsync(input);
            _mockShopperHistoryAPI.Setup(s => s.GetShopperHistory(It.IsAny<string>())).ReturnsAsync(shopperHistory);
            ProductService sut = new ProductService(_mockProductAPI.Object, _mockShopperHistoryAPI.Object);

            // act
            var actual = await sut.GetProducts(sortOption, It.IsAny<string>());

            // assert
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> PopularProducts()
        {
            var popularProducts = new List<Product>
           {
                new Product
                {
                    Name = "p1",
                    Price = 1,
                    Quantity =1,
                },

                new Product
                {
                    Name = "r3",
                    Price = 3,
                    Quantity =3,
                },

                new Product
                {
                    Name = "q2",
                    Price = 2,
                    Quantity = 2,
                },
           };

            var history = new List<ShopperHistory>()
            {
                new ShopperHistory
                {
                    CustomerId= 12,
                    Products = new List<Product>
                    {
                        new Product
                        {
                            Name = "r3",
                            Price = 3,
                            Quantity =3,
                        },

                        new Product
                        {
                            Name = "p1",
                            Price = 1,
                            Quantity =1,
                        },
                    },
                },

                new ShopperHistory
                {
                    CustomerId= 12,
                    Products = new List<Product>
                    {
                        new Product
                        {
                            Name = "p1",
                            Price = 1,
                            Quantity =1,
                        },
                    },
                },
            };

            var allData = new List<object[]>
            {
                new object[] { "recommended", GetProductSet(), history, popularProducts },
            };

            return allData;
        }

        public static IEnumerable<object[]> NameDescending()
        {
            var sortByDescending = new List<Product>
           {
                 new Product
                {
                    Name = "r3",
                    Price = 3,
                    Quantity =3,
                },

                new Product
                {
                    Name = "q2",
                    Price = 2,
                    Quantity = 2,
                },

                new Product
                {
                    Name = "p1",
                    Price = 1,
                    Quantity =1,
                },
           };

            var allData = new List<object[]>
            {
                new object[] { "descending", GetProductSet(), sortByDescending },
            };

            return allData;
        }

        public static IEnumerable<object[]> NameAscending()
        {
            var sortedByPriceLowToHigh = new List<Product>
            {
                 new Product
                {
                    Name = "p1",
                    Price = 1,
                    Quantity =1,
                },

                new Product
                {
                    Name = "q2",
                    Price = 2,
                    Quantity = 2,
                },

                new Product
                {
                    Name = "r3",
                    Price = 3,
                    Quantity =3,
                },
            };

            var allData = new List<object[]>
            {
                new object[] { "ascending", GetProductSet(), sortedByPriceLowToHigh },
            };

            return allData;
        }

        public static IEnumerable<object[]> PricingHighToLow()
        {
            var sortedByPriceHighToLow = new List<Product>
           {
                 new Product
                {
                    Name = "r3",
                    Price = 3,
                    Quantity =3,
                },

                new Product
                {
                    Name = "q2",
                    Price = 2,
                    Quantity = 2,
                },

                new Product
                {
                    Name = "p1",
                    Price = 1,
                    Quantity =1,
                },
           };

            var allData = new List<object[]>
            {
                new object[] { "high", GetProductSet(), sortedByPriceHighToLow },
            };

            return allData;
        }

        public static IEnumerable<object[]> PricingLowToHigh()
        {
            var sortedByPriceLowToHigh = new List<Product>
            {
                 new Product
                {
                    Name = "p1",
                    Price = 1,
                    Quantity =1,
                },

                new Product
                {
                    Name = "q2",
                    Price = 2,
                    Quantity = 2,
                },

                new Product
                {
                    Name = "r3",
                    Price = 3,
                    Quantity =3,
                },
            };

            var allData = new List<object[]>
            {
                new object[] { "low", GetProductSet(), sortedByPriceLowToHigh },
            };

            return allData;
        }

        public static List<Product> GetProductSet()
        {
            return new List<Product>
              {

                new Product
                {
                    Name = "q2",
                    Price = 2,
                    Quantity = 2,
                },

                new Product
                {
                    Name = "p1",
                    Price = 1,
                    Quantity =1,
                },


                new Product
                {
                    Name = "r3",
                    Price = 3,
                    Quantity =3,
                }
              };
        }
    }
}
