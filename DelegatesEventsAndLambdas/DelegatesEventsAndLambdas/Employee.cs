using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegatesEventsAndLambdas
{
    class Employee
    {
        public Employee()
        {

        }

        public void Show()
        {
            Program p1 = new Program();
            Console.WriteLine("Employee.Show() called...");
            BasicDelegate bd1 = new BasicDelegate(Program.ShowHandler1);
            //bd1 += new BasicDelegate(Program.ShowHandler2);            
            bd1 += Program.ShowHandler2;
            bd1 += p1.ShowHandler3;
            //bd1.Invoke();
            //synchronous call: the caller must wait for the call to complete before continuing on its way
            Console.WriteLine("\nGetInvocationList()");
            
            foreach (System.Delegate item in bd1.GetInvocationList())
            {
                //returns a list of static methods pointed by the delegate
                Console.WriteLine(item.Method);              
            }
            Console.WriteLine("\n");
            bd1();
        }
    }
}
