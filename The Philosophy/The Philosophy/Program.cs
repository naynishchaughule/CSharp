using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCustomLibrary;        
using VisualBasicCrossLanguageProgramming;
[assembly: System.CLSCompliant(true)]

namespace The_Philosophy
{
    public enum ColorCoding
    {
        blue = 11,
        red = 12,
        white = 13
    }

    public delegate void MyDelegateType(DateTime dt);
    
    public class Program
    {
        public static int Main(string[] args)
        {
            DateTime dt = DateTime.Now;
            MyDelegateType del = new MyDelegateType(MyMath.AttachToDelegate);
            //multi-cast delegate, attaching multiple methods
            del += new MyDelegateType(MyMath.GetMonth);
            //delegates and anonymous methods, use the delegate keyword
            del += delegate
            {
                Console.WriteLine("anonymous method called");
            };           
            del.Invoke(dt);

            Console.WriteLine("hello world!");
            var result = from i in args
                         select i;

            foreach (var item in result)
                Console.WriteLine(item);
            
            double x = 10, y = 20, temp;
            Console.WriteLine("x: {0}, y:{1}", x, y);
            temp = y;
            y = x;
            x = temp;
            Console.WriteLine("x: {0}, y:{1}", x, y);
            Display<double>.DisplayStrings(x, y);

            Console.WriteLine("Sum: {0:C}", MyMath.Add(10.345, 344.67, 89, 234.900, -20));

            try
            {
                throw new MyCustomExceptionHandlingMechanism();
            }
            catch (MyCustomExceptionHandlingMechanism e)
            {
                e.ShowExceptionDetails();          
            }

            DevelopmentEnvironment devEnv = new DevelopmentEnvironment();
            devEnv.ShowMyEnvironment();
            
            TestClass crossLanguage = new TestClass();
            crossLanguage.MyFunc();

            MyMath myObj = new MyMath();
            myObj.InternalInstanceMethod();

            Console.WriteLine("name {0}, value {1}", ColorCoding.blue.GetType().Name, Convert.ToInt32(System.Enum.Parse(ColorCoding.blue.GetType(),"red")));
            Console.ReadLine();
            return System.Environment.ExitCode = 0;
        }
    }
}

