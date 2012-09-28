using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Common;

namespace ObjectModel
{
    class Program
    {       
        public static void Main()
        {
            NorthwindDataContext context = new NorthwindDataContext();
            //Table<Product> ProductTable = context.GetTable<Product>();
            context.Log = Console.Out;
            var result1 = from item in context.Categories
                          where item.CategoryID == 48090
                          select item;
            foreach (var item in result1)
            {
                Console.WriteLine(item.CategoryName);
            }
            Console.WriteLine("---------------------------------------------------");
            
            var result2 = from item in context.Products
                          where item.CategoryID == 48090
                          select new { ProductID = item.ProductID, ProductName = item.ProductName };
            foreach (var item in result2)
            {
                Console.WriteLine(item.ProductID + " " + item.ProductName);
            }
            DbCommand cmd = context.GetCommand(result2);
            Console.WriteLine(cmd.CommandText);
            Console.ReadLine();
        }
    }
}
