using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shopping;
using MathLibrary;

namespace ShoppingCartClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Cart c = new Cart();
            Product p1 = new Product();
            Product p2 = new Product(023781, "mouse", 19, 1200);
            c.Add(p1); c.Add(p2);
            Console.WriteLine("my cart total: {0}", c.CartTotal());
            Basics b = new Basics();
            Console.WriteLine(b.Add(45.34, 23.13));
            Console.ReadLine();
        }
    }
}
