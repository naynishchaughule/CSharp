using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;

namespace CILAndDynamicAssemblies
{
    class Program
    {
        static void Main(string[] args)
        {
            //peverify.exe checks for semantics
            /*comments are ignored*/
            String msg = "Hello World!";
            int i = 10;
            Console.WriteLine(msg + " " + i + "\n");
            AppDomain curAppDomain = Thread.GetDomain();
            CreateMyAssembly(curAppDomain);
            Assembly a = Assembly.Load("MyAssembly");
            Type t = a.GetType("MyAssembly.HelloWorld");
            object[] ctorArgs = new object[1];
            ctorArgs[0] = "Naynish P. Chaughule - Tripti Panjabi";
            object objHello = Activator.CreateInstance(t, ctorArgs);            
            MethodInfo mi = t.GetMethod("SayHello");
            mi.Invoke(objHello, null);

            MethodInfo msgMethod = t.GetMethod("GetMsg");
            msgMethod.Invoke(objHello, null);
            Console.ReadLine();
        }

        static void CreateMyAssembly(AppDomain curAppDomain)
        {
            //general assembly characteristics
            AssemblyName asmName = new AssemblyName();
            asmName.Name = "MyAssembly";
            Version v = new Version("2.0.0.0");
            asmName.Version = v;

            AssemblyBuilder assembly = curAppDomain.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.Save);
            ModuleBuilder module = assembly.DefineDynamicModule("MyAssembly", "MyAssembly.dll");

            TypeBuilder helloWorldClass = module.DefineType("MyAssembly.HelloWorld", TypeAttributes.Public);
            FieldBuilder msgField = helloWorldClass.DefineField("theMessage", typeof(string), FieldAttributes.Private);

            ConstructorBuilder constructor = helloWorldClass.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, new Type[]{typeof(string)});
            ILGenerator constructorIL = constructor.GetILGenerator();
            constructorIL.Emit(OpCodes.Ldarg_0);

            Type objectClass = typeof(object);
            ConstructorInfo superConstructor = objectClass.GetConstructor(new Type[0]);
            constructorIL.Emit(OpCodes.Call, superConstructor);
            constructorIL.Emit(OpCodes.Ldarg_0);
            constructorIL.Emit(OpCodes.Ldarg_1);
            constructorIL.Emit(OpCodes.Stfld, msgField);
            constructorIL.Emit(OpCodes.Ret);

            helloWorldClass.DefineDefaultConstructor(MethodAttributes.Public);

            MethodBuilder getMsgMethod = helloWorldClass.DefineMethod("GetMsg", MethodAttributes.Public, typeof(string), null);
            ILGenerator methodIL = getMsgMethod.GetILGenerator();
            methodIL.Emit(OpCodes.Ldarg_0);
            methodIL.Emit(OpCodes.Ldfld, msgField);
            methodIL.Emit(OpCodes.Ret);

            MethodBuilder sayHiMethod = helloWorldClass.DefineMethod("SayHello", MethodAttributes.Public, null, null);
            methodIL = sayHiMethod.GetILGenerator();
            methodIL.EmitWriteLine("Hello from the HelloWorld class!");
            methodIL.Emit(OpCodes.Ret);

            helloWorldClass.CreateType();
            assembly.Save("MyAssembly.dll");
        }
    }
}
