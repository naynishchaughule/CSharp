using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ConsoleApplication1
{
    class ExternalAssemblyReflector
    {
        public void DisplayTypesInAsm(Assembly asm)
        {
            Console.WriteLine("\nLoading external assembly dynamically:-");
            Type[] arr = asm.GetTypes();
            foreach (Type item in arr)
            {
                Console.WriteLine(item);
                foreach (MemberInfo mi in item.GetMembers())
                {
                    Console.WriteLine(mi.Name);
                }
                Console.WriteLine("-----\n");
            }
        }

        public void DisplayTypesInSharedAsm(Assembly asm)
        {
            Type[] arr = asm.GetTypes();
            var x = from item in arr
                    where item.IsEnum && item.IsPublic
                    select item;
            foreach (var item in x)
            {
                Console.WriteLine(item);
            }
        }
    }
}
