using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fruit;

namespace ConfiguringAssemblies
{
    class Program
    {
        static void Main(string[] args)
        {
            Mango mng = new Mango();
            Console.WriteLine(mng);
            Console.WriteLine("hello world!");
            Console.ReadLine();
        }
    }
}
