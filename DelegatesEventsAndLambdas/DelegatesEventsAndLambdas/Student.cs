using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegatesEventsAndLambdas
{
    class Student
    {
        public static void Reg()
        {
            Events.e += new Events.Notify<string>(PlacementInfo);                             
        }

        //attach this handler to the event
        public static void PlacementInfo(String s)
        {
            Console.WriteLine("Students, {0}", s);
        }
    }
}
