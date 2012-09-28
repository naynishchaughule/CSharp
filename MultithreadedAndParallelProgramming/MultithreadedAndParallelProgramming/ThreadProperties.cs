using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultithreadedAndParallelProgramming
{
    class ThreadProperties
    {
        public static void Basics()
        {
            Thread th = Thread.CurrentThread;
            Console.WriteLine("\nThread Basics");
            th.Name = "ThreadNash";
            Console.WriteLine(th.Name);
            Console.WriteLine(th.IsAlive);
            Console.WriteLine(th.Priority);
            Console.WriteLine(th.IsBackground);
            Console.WriteLine(Thread.GetDomain().FriendlyName);
            Console.WriteLine(th.ThreadState);
            Console.WriteLine(Thread.CurrentContext.ContextID + "\n");
        }
    }
}
