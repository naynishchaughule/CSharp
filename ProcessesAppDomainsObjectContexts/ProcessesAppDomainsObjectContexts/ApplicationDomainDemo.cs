using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ProcessesAppDomainsObjectContexts
{
    class ApplicationDomainDemo
    {
        public static void DefaultAppDomain()
        {
            AppDomain ad = AppDomain.CurrentDomain;
            Console.WriteLine("\n"+ ad.FriendlyName + " " + ad.BaseDirectory + " " + ad.IsDefaultAppDomain());
        }

        public static void ListAllAssembliesInAppDomain()
        {
            AppDomain ad = AppDomain.CurrentDomain;
            Console.WriteLine("\nAssemblies in the default App Domain");
            //foreach (Assembly item in ad.GetAssemblies())
            //{
            //    Console.WriteLine(item.GetName().Name);
            //}    

            var assemblies = from item in ad.GetAssemblies()
                             select item;
            foreach (Assembly item in assemblies)
            {
                Console.WriteLine(item.GetName().Name);
            }
        }

        public static void InitDAD()
        {
            AppDomain ad = AppDomain.CurrentDomain;
            AssemblyName asmName = new AssemblyName();
            asmName.Name = @"G:\naynish\Pro C# 2010 and the .NET 4 Platform\ReflectionLateBindingAttributeBased\ConsoleApplication1\ConsoleApplication1\bin\Debug\MathLibrary.dll";            
            ad.AssemblyLoad += new AssemblyLoadEventHandler(ad_AssemblyLoad);
            Assembly.LoadFrom(asmName.ToString());
        }

        static void ad_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {
            Console.WriteLine("{0} has been loaded!", args.LoadedAssembly.GetName().Name); 
        }
    }
}
