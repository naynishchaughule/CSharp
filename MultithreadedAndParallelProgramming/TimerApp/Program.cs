using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TimerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main() thread {0}", Thread.CurrentThread.ManagedThreadId);
            TimerCallback tc = new TimerCallback(PrintTime);
            //Timer time = new Timer(tc, "naynish", 4000, 1000);            
            WaitCallback wcb = new WaitCallback(PrintTime);

            for (int i = 0; i < 2; i++)
            {
                ThreadPool.QueueUserWorkItem(wcb, null);             
            }
            Console.ReadLine();
        }

        static void PrintTime(object obj)
        {
            Console.WriteLine("PrintTime() thread {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(DateTime.Now.ToLongTimeString() /*+ " " + obj.ToString()*/);
        }
    }
}
