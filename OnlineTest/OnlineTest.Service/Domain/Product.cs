using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineTest.Service.Domain
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Quantity { get; set; }

        public override bool Equals(object obj)
        {
            var product = obj as Product;
            return product != null &&
                   Name == product.Name;
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }
    }
}
