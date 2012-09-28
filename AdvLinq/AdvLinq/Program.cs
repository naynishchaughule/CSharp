using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Transactions;

namespace AdvLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            NorthwindDataContext context = new NorthwindDataContext();
            //var result = from item in context.Categories
            //             where item.CategoryID == 48090
            //             select item;
            var result = context.SelectCategory(48090);
            foreach (var item in result)
            {
                Console.WriteLine("{0} {1}", item.CategoryID, item.CategoryName);
            }

            //context.DeferredLoadingEnabled = false;
            var ldOptions = new DataLoadOptions();
            ldOptions.AssociateWith<Category>((c) => (c.Products));
            context.LoadOptions = ldOptions;
            context.ObjectTrackingEnabled = false; // turns DeferredLoadingEnabled to false
            var result1 = context.Categories.Where((prod) => (prod.CategoryID == 65985)).Single();
            foreach (var item in result1.Products)
            {
                Console.WriteLine("{0} {1}",item.ProductID, item.ProductName);
            }

            Console.WriteLine();
            Compile();
            //Query2();
            //DirectExe();
            //Modify();
            //Trans();
            //MyDel();
            //Track();
            CreateDB();
            Console.ReadLine();
        }

        static void CreateDB()
        {
            NorthwindDataContext LinqDBDataContext = new NorthwindDataContext(@"Data Source=.\sqlexpress; Integrated Security=SSPI; Initial Catalog=LinqDB");
            LinqDBDataContext.CreateDatabase();            
        }

        static void Track()
        {
            NorthwindDataContext context = new NorthwindDataContext();
            var result = (from item in context.Categories
                         where item.CategoryID == 65985
                         select item).Single<Category>();
            result.CategoryName = "Malini";
            
            var changeSet = context.GetChangeSet();
            Console.WriteLine("Update Changes: {0}", changeSet.Updates.Count());
            
            ModifiedMemberInfo[] member = context.Categories.GetModifiedMembers(result);
            foreach (var item in member)
            {
                Console.WriteLine("Modified Member: {0}, Org: {1}, Curr: {2}", item.Member.Name, item.OriginalValue, item.CurrentValue);
            }
        }

        static void MyDel()
        {
            NorthwindDataContext context = new NorthwindDataContext();
            var result = (from item in context.Categories
                         where item.CategoryID == 48090
                         select item).Single<Category>();
            context.Categories.DeleteOnSubmit(result);
            context.Products.DeleteAllOnSubmit<Product>(result.Products);
            context.SubmitChanges();
        }

        static void Trans()
        {
            using(var trans = new TransactionScope())
	        {
                try
                {
                    NorthwindDataContext context = new NorthwindDataContext();
                    var category78210 = context.Categories.Where<Category>((cat) => (cat.CategoryID == 78210)).Single<Category>();
                    Product p1 = new Product() { CategoryID = 78210, ProductID = 92618, ProductName = "Clock", UnitPrice = 1000, UnitsInStock = 12 };
                    category78210.Products.Add(p1);
                    trans.Complete();
                }
                catch (Exception)
                {
                    Console.WriteLine("Not Complete");
                }
	        };
        }

        static void Compile()
        {
            NorthwindDataContext context = new NorthwindDataContext();
            Console.WriteLine("Compiled Query");
            foreach (var item in CompiledQueries.prodsIn(context))
            {
                Console.WriteLine("{0} {1} {2}", item.ProductID, item.ProductName, item.UnitPrice);
            }
        }

        static void Query2()
        {
            Console.WriteLine();
            Console.WriteLine("Query2");
            NorthwindDataContext context = new NorthwindDataContext();
            var compQuery = CompiledQuery.Compile((NorthwindDataContext con) => (context.Categories.Where<Category>((cat) => (cat.CategoryID == 48090)).Single<Category>((cat) => (cat.CategoryID == 48090))));

            var result = context.Categories.Where<Category>((cat) => (cat.CategoryID == 48090)).Single<Category>((cat) => (cat.CategoryID == 48090));
            Console.WriteLine("{0} {1}", result.CategoryID, result.CategoryName);
            Console.WriteLine("{0} {1}", compQuery(context).CategoryID, compQuery(context).CategoryName);
            Console.WriteLine("{0} {1}", CompiledQueries.catsIn(context).CategoryID, CompiledQueries.catsIn(context).CategoryName);            
        }

        static void DirectExe()
        {
            Console.WriteLine();
            Console.WriteLine("Direct Exe");
            NorthwindDataContext context = new NorthwindDataContext();
            var result = context.ExecuteQuery<Product>("select * from Products where CategoryID = 48090");
            foreach (var item in result)
            {
                Console.WriteLine("{0} {1}", item.ProductID, item.ProductName);
            }
        }
        static void Modify()
        {
            NorthwindDataContext context = new NorthwindDataContext();
            var result = context.Categories.Where<Category>((cat) => (cat.CategoryID == 48090)).Single<Category>();
            result.CategoryName = "Thurston";
            context.SubmitChanges();
        }
    }
}
