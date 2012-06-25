using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathLibrary;
using Assemblies.Ambiguity;
//alias for a type’s fully qualified name
using Dummy = Assemblies.Ambiguity.Basics;
using EmployeeInformation;
using Fruit;
using System.Reflection;

namespace ConfiguringAssemblies
{
    class Program
    {
        static void Main(string[] args)
        {            
            Assembly asm = Assembly.Load("Fruit");
            MathLibrary.Basics obj = new MathLibrary.Basics();
            Console.WriteLine("Sum: {0}", obj.Add(10.24, 45.91));
            Dummy d = new Dummy();
            Console.WriteLine("Difference: {0}", d.Add(20, 10.45));

            VicePresident vp = new VicePresident() { Id = 48090, Fname = "naynish p. chaughule", Salary = 85000 };
            vp.Display();

            Mango mng = new Mango();
            Console.WriteLine(mng);
            Console.ReadLine();
        }        
    }
}
