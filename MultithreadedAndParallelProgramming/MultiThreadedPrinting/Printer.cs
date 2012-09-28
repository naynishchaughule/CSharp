using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.Remoting.Contexts;

namespace MultiThreadedPrinting
{
    //locks down all instance member code of the object for thread safety
    [Synchronization]
    class Printer : System.ContextBoundObject
    {
        int intVal = 10;
        int i = 189;
        //lock token
        private object obj = new object();
        public void PrintNumbers()
        {
            Monitor.Enter(obj);
            try
            {
                Console.WriteLine("{0} is executing PrintNumbers()", Thread.CurrentThread.Name);
                for (int i = 0; i < 10; i++)
                {
                    Console.Write("{0} ", i);
                    Thread.Sleep(100);
                }                
                Console.WriteLine();
            }
            finally
            {
                Monitor.Exit(obj);
            }
        }

        public void AddOne()
        {
            int newVal = Interlocked.Increment(ref intVal);
            //Console.WriteLine(intVal++);
            Console.WriteLine(newVal);
            Thread.Sleep(2000);             
        }

        public void SafeAssignment()
        {
            Interlocked.Exchange(ref i, 100);
            Interlocked.CompareExchange(ref i, 500, 100);
            Console.WriteLine(i);
        }
    }
}
