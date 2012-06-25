using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyExtensionsLibrary
{
    public static class MyCustomExtensions
    {
        public static void ShowMyAssembly(this Object obj)
        {
            Console.WriteLine("\n" + obj.GetType().Assembly);
            Console.WriteLine(obj.GetType().DeclaringType);
            Console.WriteLine(obj.GetType().Attributes);                      
        }
    }
}
