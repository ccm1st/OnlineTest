using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineTest.Service.Domain
{
    public class ShopperHistory
    {
        public int CustomerId { get; set; }
        public List<Product> Products { get; set; }
    }
}
