using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQtoObjects
{
    class ProductInfo
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public Double Price { get; set; }
        public Int32 StockCount { get; set; }

        public override string ToString()
        {
            return String.Format("Product Id: {0}, Name: {1}, Price: {2:C}, StockCount: {3}", 
                Id, Name, Price, StockCount);
        }
    }
}
