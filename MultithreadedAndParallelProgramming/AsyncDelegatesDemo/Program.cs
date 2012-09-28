using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace AsyncDelegatesDemo
{
    delegate int BinaryOp(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main() thread id: {0}", Thread.CurrentThread.ManagedThreadId);
            BinaryOp opCode = new BinaryOp(Add);
            //AsyncCallback delegate
            opCode.BeginInvoke(30, 40, new AsyncCallback(AddComplete), null);
            Console.ReadLine();
        }

        private static int Add(int x, int y)
        {
            Console.WriteLine("Add(int, int) thread id: {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            return x + y;
        }

        private static void AddComplete(IAsyncResult iAsyncResult)
        {
            Console.WriteLine("AddComplete called!");
             AsyncResult aRes = (AsyncResult)iAsyncResult;
             BinaryOp opCode = (BinaryOp)aRes.AsyncDelegate;
             Console.WriteLine("Sum {0}", opCode.EndInvoke(iAsyncResult));
        }
    }
}
