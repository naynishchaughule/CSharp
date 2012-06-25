using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCustomLibrary
{
    public class Display<T>
    {
        public static void DisplayStrings(params T[] args)
        {
            foreach (var item in args)
                Console.WriteLine(item.ToString());
        }
    }
}
