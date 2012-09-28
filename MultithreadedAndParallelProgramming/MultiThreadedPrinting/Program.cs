using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreadedPrinting
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread[] thArray = new Thread[10];
            Printer pObj = new Printer();
            for (int i = 0; i < 10; i++)
            {
                thArray[i] = new Thread(new ThreadStart(pObj.SafeAssignment));
                thArray[i].Name = "Thread " + i;
            }
            foreach (Thread item in thArray)
            {
                item.Start();
            }
            Console.ReadLine();
        }
    }
}
