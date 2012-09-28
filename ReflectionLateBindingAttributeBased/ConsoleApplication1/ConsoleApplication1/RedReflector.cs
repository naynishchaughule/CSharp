using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ConsoleApplication1
{
    class RedReflector
    {
        public void ListMethods(Type t)
        {
            /*System.Reflection.MethodInfo[] arr = t.GetMethods();
            foreach (MethodInfo item in arr)
            {
                Console.WriteLine(item.Name);
            }*/
            Console.WriteLine("\n");
            Console.WriteLine("t.GetMethods()");
            var linq = from item in t.GetMethods()
                       select item;
            foreach(MethodInfo item in linq)
            {
                Console.WriteLine(item.ReturnType + " " + item.Name);
                Console.WriteLine("Params:-");
                foreach (ParameterInfo x in item.GetParameters())
                {
                    Console.WriteLine(x.ParameterType + " " +x.Name);
                }
                Console.WriteLine("----------");
            }
            Console.WriteLine("\n");
        }

        public void ListFields(Type t)
        {
            var linq = from item in t.GetFields()
                       select item.Name;
            foreach (String item in linq)
            {
                Console.WriteLine(item);
            }
        }

        public void ListProperties(Type t)
        {
            var linq = from item in t.GetProperties()
                       select item.Name;
            foreach (String item in linq)
            {
                Console.WriteLine(item);
            }
        }

        public void ListInterfaces(Type t)
        {
            var linq = from item in t.GetInterfaces()
                       select item;
            foreach (Type item in linq)
            {
                Console.WriteLine(item.Name);
            }
        }

        public void ListStats(Type t)
        {
            Console.WriteLine("Type Stats:");
            Console.WriteLine("IsAbstract {0}", t.IsAbstract);
            Console.WriteLine("IsSealed {0}", t.IsSealed);
            Console.WriteLine("IsGenericTypeDefinition {0}", t.IsGenericTypeDefinition);
            Console.WriteLine("BaseType {0}", t.BaseType);
            Console.WriteLine("IsClass {0}", t.IsClass);
        }
    }
}
