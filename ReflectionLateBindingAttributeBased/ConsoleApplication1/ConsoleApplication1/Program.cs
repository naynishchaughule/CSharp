using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathLibrary;
using System.Reflection;

namespace ConsoleApplication1
{
    class Program
    {
        static string Fname = "naynish p. chaughule";
        public int myInt { get; set; }
        static void Main(string[] args)
        {
            Console.WriteLine(Fname);            
            BasicMath bm = new BasicMath();
            Console.WriteLine("sum = {0}", bm.Add(10.45, 243.39));
            //different ways to create type instance
            //System.Object
            Type t = bm.GetType();
            System.Reflection.MethodInfo mtInfo = t.GetMethod("Add");
            Console.WriteLine("is Add public {0}", mtInfo.IsPublic);

            //typeof
            Type typo = typeof(BasicMath);

            //you don't need compile time info about the type
            //System.Type.GetType (static method)
            try
            {
                // Obtain type information for a type within an external assembly.
                //fully qualified name of the type, friendly name of the assembly
                Type sysType = System.Type.GetType("MathLibrary.BasicMath, MathLibrary", true, false);

                //Obtain type information for a nested class (add + for nested types)                
                System.Type.GetType("MathLibrary.BasicMath+Trigonometry, MathLibrary", true, false);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            /*“back tick” character (`) followed by a numerical value that represents
            the number of type parameters*/
            //System.Collections.Generic.List<T>
            Type tInfo = System.Type.GetType("System.Collections.Generic.List`1, mscorlib", true, false);
            RedReflector rdr = new RedReflector();            
            rdr.ListMethods(tInfo);
            //rdr.ListProperties(tInfo);
            rdr.ListInterfaces(tInfo);            
            rdr.ListStats(tInfo);

            //dynamically loading assembly
            ExternalAssemblyReflector ear = new ExternalAssemblyReflector();
            //ear.DisplayTypesInAsm(Assembly.LoadFrom(@"G:\naynish\Pro C# 2010 and the .NET 4 Platform\ReflectionLateBindingAttributeBased\ConsoleApplication1\MathLibrary\bin\Debug\MathLibrary.dll"));

            String extPath = @"G:\naynish\Pro C# 2010 and the .NET 4 Platform\ReflectionLateBindingAttributeBased\ConsoleApplication1\SimpleEmployee\bin\Debug\SimpleEmployee.dll";
            AssemblyName asmName = new AssemblyName();                       
            //path including the extension
            asmName.Name = extPath;        
            
            //LoadFrom because the assembly is not in the bin directory of ConsoleApplication1
            ear.DisplayTypesInAsm(Assembly.LoadFrom(asmName.ToString()));   
         
            //loading shared assemblies
            Assembly myAssembly = Assembly.Load(@"System.Windows.Forms, Version = 4.0.0.0, PublicKeyToken = b77a5c561934e089, Culture = """);
            ear.DisplayTypesInSharedAsm(myAssembly);

            AssemblyName customMyAssembly = new AssemblyName();
            customMyAssembly.Name = "CustomLibrary";
            Version v = new Version("1.0.0.0");
            customMyAssembly.Version = v;

            Assembly a = Assembly.Load(customMyAssembly);            
            ear.DisplayTypesInAsm(a);
            AttributeBased ab = new AttributeBased();
            //ab.salary; (error on reflecting over this type using C# compiler)

            //reflect over an attributed type
            AssemblyName name = new AssemblyName();
            name.Name = "AttributedEmployeeLibrary";
            Assembly myAttr = Assembly.Load(name);

            Type tp = myAttr.GetType("AttributedEmployeeLibrary.VicePresident");
            Object myInstance = Activator.CreateInstance(tp);
            MethodInfo info = tp.GetMethod("GetFname");            
            Console.WriteLine(info.Invoke(myInstance, null));

            Object[] custAttr = tp.GetCustomAttributes(false);
            foreach (var item in custAttr)
            {
                Console.WriteLine(item);
            }

            foreach (Type item in myAttr.GetTypes())
            {
                foreach (object item1 in item.GetCustomAttributes(myAttr.GetType("AttributedEmployeeLibrary.EmployeeDescriptionAttribute"), false))
                {
                    Console.WriteLine((myAttr.GetType("AttributedEmployeeLibrary.EmployeeDescriptionAttribute").GetProperty("Description")).GetValue(item1,null));    
                }
            }            
            Console.ReadLine();
        }
    }
}
