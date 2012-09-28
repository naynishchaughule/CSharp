using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ProcessesAppDomainsObjectContexts
{
    class CustomAppDomains
    {
        public static void ListAllAssembliesInAppDomain()
        {
            AppDomain ad = AppDomain.CreateDomain("nash");
            Console.WriteLine("\nCreating new custom App Domain and loading an exe");
            foreach (Assembly item in ad.GetAssemblies())
            {
                Console.WriteLine(item.GetName().Name);
            }
            Assembly asm = ad.Load("SimpleEXE");
            var coll = from item in ad.GetAssemblies()
                       select item;
            Console.WriteLine("--Assemblies in {0}", ad);
            foreach (Assembly item in coll)
            {
                Console.WriteLine(item.GetName().Name);
            }
            Console.ReadLine();
            ad.DomainUnload += new EventHandler(ad_DomainUnload);            
            AppDomain.Unload(ad);

        }

        static void ad_DomainUnload(object sender, EventArgs e)
        {
            Console.WriteLine("\nDomain unloaded!");
        }
    }
}
