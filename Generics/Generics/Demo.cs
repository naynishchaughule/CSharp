using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics
{
    class Demo
    {
        //generic method 
        public void Swap<T>(ref T x, ref T y)
        {
            Console.WriteLine("\nOriginal x: {0}, \ny: {1}", x, y);
            Console.WriteLine("typeof T: {0}", typeof(T));
            T temp;
            temp = x;
            x = y;
            y = temp;            
            Console.WriteLine("new x: {0}, \ny: {1}", x, y);
        }
    }
}
