using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace LinqOverview
{
    class ExtensionMethods
    {
        static void Main(string[] args)
        {
            var items = Enumerable.Range(1, 10);
            //var reverse = Enumerable.Reverse(items);
            var reverse = items.Reverse<int>();
            foreach (var item in reverse)
	        {
		        Console.Write("{0} ", item);        
	        }
            //string.Format("{0} {1}", index, prod)
            var products = GetProducts().Select((prod, index) => prod);
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            var result1 = GetProducts().Where<Products>((prod) => prod.ProductID == 601222).Select<Products, Products>((prod1) => prod1);
            var result2 = result1.SingleOrDefault<Products>();
            Console.WriteLine(result2);
            //foreach (var item in result2)
            //{
            //    Console.WriteLine(item);
            //}

            var result3 = GetProducts().Single<Products>((prod) => (prod.ProductID == 651284));
            Console.WriteLine(result3);

            var result4 = GetProducts().Last<Products>();
            Console.WriteLine(result4);

            //var result5 = products.Single<Products>();
            //Console.WriteLine(result5);
            Console.WriteLine("---");
            var result5 = GetProducts().Where<Products>((prod, index) => prod.UnitsInStock > 80 & index < 3).Select<Products, Products>( (prod
                => prod));
            foreach (var item in result5)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            var result6 = GetProducts().Where<Products>((prod) => prod.CategoryID==48090).Select( (prod) => prod);
            var result7 = result6.Any<Products>((prod) => prod.UnitsInStock == 891);
            Console.WriteLine(result7);

            Console.WriteLine("Start with A:");
            var result8 = GetProducts().Where<Products>( (prod) => prod.ProductName.StartsWith("a"));
            foreach (var item in result8)
            {
                Console.WriteLine(item);
            }

            Products p2 = new Products() { CategoryID = 1, ProductID = 601222, ProductName = "hello", UnitPrice = 4.5M, UnitsInStock = 45 };
            var result9 = result8.Contains<Products>(p2, new ProductsComparer());
            Console.WriteLine("Contains {0}", result9);

            Console.WriteLine();
            var result10 = GetProducts().Where<Products>((prod) => (prod.CategoryID==48090)).Select<Products, string>((prod) => (prod.ProductName)).ToArray<string>();
            string delimit = string.Join(",", result10);
            Console.WriteLine("Concat: {0}", delimit);

            Console.WriteLine();
            var result11 = GetProducts().Where<Products>((prod) => (prod.CategoryID == 65985)).Select<Products, Products>((prod) => (prod));
            Dictionary<int, Products> myDictionary = result11.ToDictionary<Products, int>((prod) => (prod.ProductID));
            foreach (KeyValuePair<int,Products> item in myDictionary)
            {
                Console.WriteLine("{0} {1}", item.Key, item);
            }

            Console.WriteLine();
            var result12 = (GetProducts().Where<Products>((prod) => (prod.CategoryID == 48090)).Select<Products, String>((prod) => (prod.ProductName))).Skip<string>(2).Take<string>(3);
            foreach (var item in result12)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            var result13 = GetProducts().Where<Products>((prod) => (prod.CategoryID == 48090)).Select<Products, int>((prod) => (prod.UnitsInStock)).Sum<int>((item) => (item));            
            Console.WriteLine("Sum of 48090: {0}", result13);

            Console.WriteLine();
            var result14 = GetProducts().GroupBy<Products, int>((prod) => (prod.CategoryID)).OrderBy((grp) => (grp.Key)).Select((groupedProducts) =>  groupedProducts);
            foreach (var item in result14)
            {
                foreach(var item1 in item)
                {
                    Console.WriteLine("{0}", item1);
                }
                Console.WriteLine(item.Count());
            }

            Console.WriteLine();
            var p100 = GetProducts().Where<Products>((prod) => (prod.CategoryID == 65985));
            var avg = p100.Average<Products>((stock) => (stock.UnitPrice));
            var sumSquares = p100.Aggregate(0, (decimal current, Products item) => current + (decimal)(Math.Pow((double)(item.UnitPrice - avg),2)));
            decimal variance = sumSquares / p100.Count();
            var stdDeviation = Math.Pow((double)variance, 0.5);
            Console.WriteLine("Std. deviation {0}", stdDeviation);
            Console.ReadLine();
        }

        static IEnumerable<Products> GetProducts()
        {
            DataContext context = new DataContext(@"Data Source=localhost\sqlexpress; Integrated Security=SSPI; Initial Catalog=Northwind");
            return context.GetTable<Products>();
        }
    }
}
