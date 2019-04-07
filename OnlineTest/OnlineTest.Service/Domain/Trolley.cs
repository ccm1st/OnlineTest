using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineTest.Service.Domain
{
    /// <summary>
    /// Represents the trolley input from excercise 3
    /// </summary>
    public class Trolley
    {
        public List<TrolleyProduct> Products { get; set; }
        public List<Special> Specials { get; set; }
        public List<TrolleyQuantity> Quantities { get; set; }
    }
}
