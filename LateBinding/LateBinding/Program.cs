using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace LateBinding
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly a = null;
            try
            {
                a = Assembly.Load("SimpleEmployee, Version = 1.0.0.0");                
            }
            catch(FileNotFoundException fe)
            {
                Console.WriteLine(fe.Message);
            }
            if (a != null)
            {
                CreateUsingLateBinding(a);
            }
            Console.ReadLine();
        }

        static void CreateUsingLateBinding(Assembly asm)
        {
            try
            {
                //late binding
                Type emp1 = asm.GetType("SimpleEmployee.Employee");
                Object obj = Activator.CreateInstance(emp1);
                Console.WriteLine(obj);
                Console.WriteLine("Late Binding Successful!");
                MethodInfo mi = emp1.GetMethod("CalculateSalary");
                Console.WriteLine(mi.Invoke(obj, null));
                MethodInfo newSal = emp1.GetMethod("CalculateNewSalary");
                Console.WriteLine("new salary {0}", newSal.Invoke(obj, new Object[] {85000, 20000}));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
