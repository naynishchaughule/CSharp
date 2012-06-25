using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics
{
    class Product : IComparer<Product>
    {
        public Int32 PId { get; set; }
        public String PName { get; set; }
        public Double PPrice { get; set; }

        public Product()
        {

        }

        public Product(int id, string name, double price)
        {
            PId = id; PName = name; PPrice = price;
        }

        public override string ToString()
        {
            return String.Format("Product details, Id: {0}, Name: {1}, Price: {2}", PId, PName, PPrice);
        }

        public int Compare(Product x, Product y)
        {
            if (x.PPrice < y.PPrice)
            {
                return -1;
            }
            else if (x.PPrice == y.PPrice)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
