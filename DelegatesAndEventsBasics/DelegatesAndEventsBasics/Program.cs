using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegatesAndEventsBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            ListenerPart1 lp1 = new ListenerPart1();
            ListenerPart2 lp2 = new ListenerPart2();
            Publisher p = new Publisher();
            p.Fire();
            Console.ReadLine();
        }
    }
}
