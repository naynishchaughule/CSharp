using System;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace LinqSqlAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            NorthwindDataContext context = new NorthwindDataContext();
            //context.DeferredLoadingEnabled = false;
            //var load = new DataLoadOptions();
            //load.LoadWith<Category>((o) => (o.Products));
            //context.LoadOptions = load;

            //context.ObjectTrackingEnabled = false;

            var result = CompiledQuery.Compile((NorthwindDataContext context1) => (context.Categories.Where((cat) => (cat.CategoryID == 48090)).Select((cat1) => (cat1.CategoryName))));
            foreach (var item in result(context))
            {
                Console.WriteLine(item);
            }            
            Console.ReadLine();
        }
    }
}
