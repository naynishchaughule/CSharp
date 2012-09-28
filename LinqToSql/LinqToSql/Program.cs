using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace LinqToSql
{
    class Program
    {
        static void Main()
        {
            NorthwindDataContext context = new NorthwindDataContext();
            context.Log = Console.Out;
            var result = context.Products.Where<Product>((prod) => (prod.CategoryID == 48090)).Select<Product,Product>((prod) => (prod));
            foreach (var item in result)
            {
                Console.WriteLine("{0} {1}", item.ProductID, item.ProductName);
            }
            DbCommand cmd = context.GetCommand(result);
            Console.WriteLine(cmd.CommandText);
            
            Console.WriteLine("relations");
            var result1 = from item in context.Products
                          where item.Category.CategoryName == "Beverages"
                          select new { Products1 = item, Category1 = item.Category};
            foreach (var item in result1)
            {
                Console.WriteLine("{0} {1}", item.Products1.ProductID, item.Products1.ProductName);
                Console.WriteLine("{0} {1}", item.Category1.CategoryName, item.Category1.CategoryID);
            }

            var result2 = from item in context.Products
                          where item.Category.CategoryID == item.CategoryID
                          select item;
            foreach (var item in result2)
            {
                Console.WriteLine("{0} {1}", item.Category.CategoryName, item.ProductName);
            }

            var result3 = (from item in context.Products
                           select item).Count<Product>((prod) => (prod.CategoryID==48090));

            Console.WriteLine("Count {0}", result3);
            Console.WriteLine("TRY OUT");
            var result4 = context.Products.Where<Product>((prod) => (prod.CategoryID == 48090)).Select<Product,Category>((prod)=>(prod.Category)).Distinct();
            
            foreach (var item in result4)
            {
                Console.WriteLine("{0} {1}", item.CategoryID, item.CategoryName);
            }

            Console.WriteLine("Convert Money");
            var result5 = context.Products.Where<Product>((prod) => (prod.CategoryID == 48090)).Select<Product, decimal>((prod) => (prod.UnitPrice)).Sum<decimal>((d) => (d)).ConvertToEuro();
            Console.WriteLine("Sum: {0}", result5);

            var result6 = from category in context.Categories
                          join products in context.Products
                          on category.CategoryID equals products.CategoryID   
                          group products by products.CategoryID into grouped
                          select grouped.Key;

            //Console.WriteLine(result6.Count());
            foreach (var item in result6)
            {
                Console.WriteLine(item);
            }

            var result7 = from item in context.Products
                          where item.Category.CategoryID == 65985
                          select item;

            foreach (var item in result7)
            {
                Console.WriteLine(item.ProductID + " " + item.ProductName);    
            }

            Console.WriteLine();
            var result8 = from category in context.Categories
                          join products in context.Products
                          on category.CategoryID equals products.CategoryID
                          where category.CategoryID == 48090
                          select products;
            foreach (var item in result8)
            {
                Console.WriteLine("{0}", item.ProductName);
            }

            Console.WriteLine("Modify Data");
            var result9 = from item in context.Products
                          where item.CategoryID == 65985
                          select item;

            foreach (var item in result9)
            {
                Console.WriteLine("{0} {1}", item.ProductName, item.UnitPrice);
            }

            foreach (var item in result9)
            {
                //item.UnitPrice = item.UnitPrice * 0.5M;
            }

            //Category cate1 = new Category() { CategoryID = 825664, CategoryName = "Fruits" };
            //context.Categories.InsertOnSubmit(cate1);

            //var result10 = context.Categories.Where((cat) => (cat.CategoryID == 825664)).Single();
            //result10.CategoryName = "vegetables";          
            //context.Categories.DeleteOnSubmit(result10);

            //Console.WriteLine("Modifying Related Data");
            //var result11 = context.Categories.Where<Category>((cat) => (cat.CategoryID == 48090)).Single<Category>();
            //Product pnew1 = new Product() { CategoryID = 48090, ProductID = 34656, ProductName = "Rice", UnitPrice = 2, UnitsInStock = 27 };
            //result11.Products.Add(pnew1);

            var result12 = context.SelectCategory(48090);
            foreach (var item in result12)
            {
                Console.WriteLine("SP: {0}", item.CategoryName);
            }
            context.SubmitChanges();
            Console.ReadLine();
        }
    }
}
