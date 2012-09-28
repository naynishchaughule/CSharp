using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.Linq;
using System.Xml.Linq;

namespace LinqOverview
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dInfo = new DirectoryInfo("C:\\");
            var result = from item in dInfo.GetFiles()
                         where item.Length > 10000
                         orderby item.Name
                         select new { Name = item.Name, SizeInBytes = item.Length, CreationTime = item.CreationTime };

            foreach (var item in result)
            {
                Console.WriteLine("Name: {0}, Size in bytes: {1}, Creation time: {2}", item.Name, item.SizeInBytes, item.CreationTime);
                Console.WriteLine();
            }
            int i = 10;
            Console.WriteLine(i.IsEven());

            int[] arr = new int[] { 3, 5, 812, 20, 56, 92, 167, 352, 14, 19, 55, 287, 13, 17, 19 };
            var resultGrouping = from item in arr
                                 group item by item.IsEven() into groupedNumbers
                                 select new { IsEven = groupedNumbers.Key, GroupedNumbers = groupedNumbers };

            foreach (var item in resultGrouping)
            {
                Console.WriteLine("IsEven: {0}", item.IsEven);
                foreach (var t in item.GroupedNumbers)
                {
                    Console.WriteLine(t);
                }
            }

            Console.WriteLine("--------");
            DataContext context = new DataContext(@"Data Source=localhost\sqlexpress; Integrated Security=SSPI; Initial Catalog=Northwind");
            var productTable = context.GetTable<Products>();

            var resultProduct = from item in productTable
                                group item by item.CategoryID into groupedProducts
                                select new { CategoryID = groupedProducts.Key, Count = groupedProducts.Count() };

            foreach (var item in resultProduct)
	        {
		        Console.WriteLine("CategoryID: {0}, Product Count: {1}", item.CategoryID, item.Count);
	        }

            Course[] courses = new Course[] 
            { 
                new Course("title1", 2012, "author1"),
                new Course("title2", 2013, "author2"),
                new Course("title3", 2014, "author3"),
            };

            Console.WriteLine();

            XElement xml = new XElement("Courses",
                from item in courses
                where item.Author.Contains("a")
                select new XElement("Course",
                    new XAttribute("Year", item.Year),
                    new XElement("Title", item.Title),
                    new XElement("Author", item.Author)));

            IEnumerable<XElement> CourseNodes = xml.Descendants("Course");
            foreach (XElement Course in CourseNodes)
                Console.WriteLine((string)Course); 

            Console.ReadLine();
        }      
    }
}
