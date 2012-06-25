using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shopping
{
    public class Product
    {
        public Int32 ProductId { get; set; }
        public String ProductName { get; set; }
        public Double ProductPrice { get; set; }
        public Int32 StockCount { get; set; }

        public Product()
            : this(000679, "lays classic chips", 1.45, 2500)
        {

        }

        public Product(Int32 productId, String productName, Double productPrice, Int32 stockCount)
        {
            ProductId = productId; ProductName = productName; ProductPrice = productPrice;
            StockCount = stockCount;
        }

        public override string ToString()
        {
            return String.Format("Product details:\nId: {0}, Name: {1}, Price: {2}, Count: {3}", ProductId, ProductName, ProductPrice, StockCount);
        }
    } 
}