using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

namespace MultithreadedAndParallelProgramming
{
    delegate int BinaryOp(int x, int y);
    class Program
    {
        static bool isDone = false;
        static void Main(string[] args)
        {
            BinaryOp opCode = new BinaryOp(Add);
            Console.WriteLine("Threading!");
            Thread t = System.Threading.Thread.CurrentThread;
            Console.WriteLine(t.IsAlive);
            AppDomain ad = Thread.GetDomain();
            Console.WriteLine(ad.FriendlyName);
            System.Runtime.Remoting.Contexts.Context ctx = Thread.CurrentContext;

            Console.WriteLine("\nMain() thread id: {0}", Thread.CurrentThread.ManagedThreadId);
            //Console.WriteLine("waits till Add completes, delegate sum: {0}", opCode.Invoke(10, 30));
            //IAsyncResult iAsync = opCode.BeginInvoke(10, 50, null, null);
            //the called thread informs the primary thread that it hascompleted
            IAsyncResult iAsync = opCode.BeginInvoke(10, 50, new AsyncCallback(AddComplete), "author: naynish c");
            Console.WriteLine("Add called async");
            //keeps on asking if the call is complete
            Console.WriteLine("Check if Add is complete {0}", iAsync.IsCompleted);
            //waits for 200 milliseconds and asks if the call is complete
            iAsync.AsyncWaitHandle.WaitOne(200);
            Console.WriteLine("Check if Add is complete {0}", iAsync.IsCompleted);
            //Console.WriteLine("Sum: {0}", opCode.EndInvoke(iAsync));
            Console.WriteLine("Check if Add is complete {0}", iAsync.IsCompleted);
            ThreadProperties.Basics();
            Console.ReadLine();
        }

        private static int Add(int x, int y)
        {
            Console.WriteLine("\nAdd(int, int) thread id: {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            return x + y;
        }

        static void AddComplete(IAsyncResult itfAR)
        {
            Console.WriteLine("AddComplete() invoked on thread {0}.",
            Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Your addition is complete");
            isDone = true;
            BinaryOp op = (BinaryOp)(((AsyncResult)itfAR).AsyncDelegate);
            Console.WriteLine("Add complete {0}", op.EndInvoke(itfAR));
            string msg = (string)itfAR.AsyncState;
            Console.WriteLine(msg);
        }
    }
}
