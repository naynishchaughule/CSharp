using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace The_Philosophy
{
    internal class MyMath
    {
        public static double Add(params double[] arr)
        {
            double sum = 0;
            foreach (double item in arr)
                sum += item;
            return sum;
        }

        public static void AttachToDelegate(DateTime dt)
        {
            Console.WriteLine("delegate invoked {0}", dt.Month);
        }

        public static void GetMonth(DateTime dt)
        {
            Console.WriteLine("delegate invoked and Month: {0}", dt.Month);
        }

        public void InternalInstanceMethod()
        {
            Console.WriteLine("instance method of MyMath");
        }

        public ulong MyNonCLS()
        {
            ulong i = (ulong)10.89;
            return i;
        }
    }
}
