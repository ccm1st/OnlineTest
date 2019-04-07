using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineTest.Service
{
    /// <summary>
    /// Product sorting option
    /// </summary>
    public enum SortOption
    {
        // Low to High Price
        Low,

        // High to Low Price
        High,

        // A - Z sort on the Name
        Ascending,

        // Z - A sort on the Name
        Descending,

        // this will call the "shopperHistory" resource to get a list of customers orders and needs to return based on popularity
        Recommended,
    }
}
