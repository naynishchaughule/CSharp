using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace DynamicTypesDLR
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new List<Int32>();
            a.Add(90);
            dynamic t = "naynish";
            //RuntimeBinderException
            try
            {
                Console.WriteLine(t.ToUpper());
            }
            catch(Microsoft.CSharp.RuntimeBinder.RuntimeBinderException e)
            {
                Console.WriteLine(e.Message);
            }

            Assembly myAsm = Assembly.Load("NewTest");
            Type Employee = myAsm.GetType("Amazon.Employee");
            //dynamic emp1 = Activator.CreateInstance(Employee);
            dynamic emp1 = myAsm.CreateInstance("Amazon.Employee");
            //MethodInfo emp1MI = Employee.GetMethod("CalculateBonus");
            //Console.WriteLine("Bonus of {0} is {1}", emp1, emp1MI.Invoke(emp1, null));
            //emp1.CalculateBonus();
            Console.WriteLine("Employee {0}", emp1);

            dynamic math = Assembly.Load("MathLibrary").CreateInstance("MathLibrary.SimpleMath");
            Console.WriteLine("Sum {0}", math.Add(10, 20));
            Console.ReadLine();
        }
    }
}
