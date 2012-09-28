using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqOverview
{
    class LinqToObjects
    {
        static void Main(string[] args)
        {
            object[] arr = new object[] { "naynish", 10, 23.45, 'T', DateTime.Now};
            var result = from item in arr.OfType<int>()
                         let value = item.GetType().Name                         
                         orderby value ascending
                         select new { item, value };

            var result1 = arr.OrderBy(fi => fi.GetType().Name).Select(item => new { item, value = item.GetType().Name });

            foreach (var item in result1)
            {
                Console.WriteLine("{0} {1}", item, item.value);
            }

            string name = "aaadsfgsdkjfsdlfshdfhsdwpoopdelwjhgwyeio";
            //var myResult = from item in name
            //               group item by item into groupedLetters
            //               select new { groupedLetters, Count = groupedLetters.Count() };

            var myVowels = from item in name
                           where item == 'a' || item == 'e' || item == 'i' || item == 'o' || item == 'u'
                           group item by item into groupedVowels
                           select new { Group = groupedVowels, Count = groupedVowels.Count<char>() };

            foreach (var item in myVowels)
            {
                foreach (var item1 in item.Group)
                {
                    Console.Write("{0} ", item1);                    
                }
                Console.WriteLine(item.Count);
            }
            //foreach (var item in myResult)
            //{
            //    foreach (var item1 in item.groupedLetters)
            //    {
            //        Console.Write("{0} ", item1);
            //    }
            //    Console.WriteLine("{0}", item.Count);
            //}
            Console.ReadLine();         
        }
    }
}
