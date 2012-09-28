using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqOverview
{
    class ProductsComparer : IEqualityComparer<Products>
    {
        public bool Equals(Products x, Products y)
        {
            return x.ProductID.Equals(y.ProductID);
        }

        public int GetHashCode(Products obj)
        {
            return obj.GetHashCode();
        }
    }
}
