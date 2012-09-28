using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SimpleMultiThreadApp
{
    class Printer
    {
        public void PrintNumbers()
        {
            Console.WriteLine("{0} is executing PrintNumbers()", Thread.CurrentThread.Name);
            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0} ", i);
                Thread.Sleep(500);
            }
            Console.WriteLine();
        }

        public void Add(object obj)
        {
            if (obj is AddParams)
            {
                int sum = 0;
                foreach (var item in ((AddParams)obj).myList)
	            {
                    sum = sum + item;
	            }
                Thread.Sleep(3000);
                Console.WriteLine("sum is {0}", sum);
                Program.waitHandle.Set();
            }
        }
    }
}
