using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shopping
{
    public class Cart
    {
        Dictionary<Int32, Product> myCart = new Dictionary<Int32, Product>();

        public void Add(Product p)
        {
            myCart.Add(p.ProductId, p);
        }

        public void Remove(Product p)
        {
            myCart.Remove(p.ProductId);
        }

        public Double CartTotal()
        {
            Double sum = 0;
            if (myCart.Count > 0)
            {
                foreach (KeyValuePair<Int32, Product> item in myCart)
                {
                    sum += item.Value.ProductPrice;
                }
            }
            return sum;
        }
    } 
}