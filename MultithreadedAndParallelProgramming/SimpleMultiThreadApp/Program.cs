using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SimpleMultiThreadApp
{
    class Program
    {
        //blocking the current thread and waiting for the secondary thread to finish
        public static AutoResetEvent waitHandle = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Thread th = Thread.CurrentThread;
            th.Name = "Primary Thread";
            Console.WriteLine("{0} is executing Main()", Thread.CurrentThread.Name);
            Printer p = new Printer();
            //return void and take no arguments
            //Thread secondary = new Thread(new ThreadStart(p.PrintNumbers));
            //secondary.Name = "Secondary Thread";
            //secondary.Start();
            MessageBox.Show("busy");

            AddParams ap = new AddParams();
            ap.AddToParamsList(45); ap.AddToParamsList(86);
            Thread dependent = new Thread(new ParameterizedThreadStart(p.Add));
            dependent.IsBackground = true;
            dependent.Start(ap);
            waitHandle.WaitOne();
            Console.WriteLine("final output");
            Console.ReadLine();
        }
    }
}
