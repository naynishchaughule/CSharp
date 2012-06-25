using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; //System.Text.StringBuilder
using System.Numerics;

namespace CoreProgrammingConstructsPart1
{
    class Hierarchy
    {
        public void Print()
        {
            System.Int32 i = new System.Int32();
            i = 23;
            Console.WriteLine(i.GetHashCode());
            Console.WriteLine(i.GetType());
            Console.WriteLine(i.GetTypeCode());
            Console.WriteLine(i.ToString());
            if (i.CompareTo(20) < 0)
                Console.WriteLine("{0} < 20", i);
            else if (i.CompareTo(20) == 0)
                Console.WriteLine("i equals 20");
            else
                Console.WriteLine("i > 20");
            Console.WriteLine(System.Int32.MinValue);
            Console.WriteLine(System.Int32.MaxValue);
            Console.WriteLine(System.Double.Epsilon);
            Console.WriteLine(System.Double.PositiveInfinity);
            Console.WriteLine(System.Double.NegativeInfinity);
            Console.WriteLine(System.Boolean.FalseString);
            Console.WriteLine(System.Boolean.TrueString);

            Console.WriteLine(System.Char.IsDigit('1'));
            Console.WriteLine(System.Char.IsLetter('9'));
            Console.WriteLine(System.Char.IsWhiteSpace("naynish chaughule", 7));
            Console.WriteLine(System.Char.IsPunctuation('?'));

            //parsing
            double d = System.Double.Parse("90.35");
            Console.WriteLine(d);
            System.Int64 longVar = Convert.ToInt64("43654703826562");
            Console.WriteLine(longVar);

            Console.WriteLine(System.Guid.NewGuid());            
            System.DateTime dt = new DateTime(2012, 6, 04);
            Console.WriteLine(dt.ToLongDateString());
            Console.WriteLine(DateTime.Now.ToLongTimeString());
            Console.WriteLine(dt.DayOfWeek);
            Console.WriteLine(dt.AddMonths(5).ToLongDateString());
            Console.WriteLine("{0} {1} {2}", dt.Date, dt.DayOfYear, dt.IsDaylightSavingTime());

            TimeSpan ts = new TimeSpan(24, 30, 30);
            Console.WriteLine(dt.Add(ts).ToLongDateString());
            Console.WriteLine(ts.Subtract(new TimeSpan(2,30, 45)));
            NumericsDemo();
            WorkingWithStrings();
        }

        private static void NumericsDemo()
        {
            string number = "348570017366840014432749057365242527839493752";
            //immutable
            BigInteger bi = BigInteger.Parse(number);            
            Console.WriteLine(bi);
            Console.WriteLine(BigInteger.Multiply(bi, BigInteger.Parse("547568686780928252435283950598635635262738")));
            Console.WriteLine(bi.IsEven);
            Console.WriteLine(bi.IsPowerOfTwo);

            Complex ci = new Complex(354.67, 89.90);
            Console.WriteLine(ci.Magnitude);
        }

        private static void WorkingWithStrings()
        {
            Console.WriteLine("naynish".Length);
            Console.WriteLine(String.Compare("nash", "hello"));
            Console.WriteLine("hello world!".Contains("world"));
            String s1 = "jquery", s2 = "java";
            Console.WriteLine(String.Equals(s1, s2));
            Console.WriteLine("microsoft".Insert(1, "xbox"));
            Console.WriteLine("amazon".PadLeft(7));
            Console.WriteLine(s1.Remove(4));
            Console.WriteLine(s1.Replace("ery", "str"));
            foreach (var item in "learning C# 4.0 and the .NET platform".Split(new char[] { ' ' }))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("hello".Trim(new char[] {'h', 'e'}));
            Console.WriteLine("new line".ToUpper());
            Console.WriteLine("new line".ToLower());
            //+
            string newS = "king " + " of " + " good times";
            Console.WriteLine(newS);
            Console.WriteLine(String.Concat("programming", " guru"));
            Console.WriteLine(@"G:\naynish\Pro C# 2010 and the .NET 4 Platform\CoreProgrammingConstructsPart1\CoreProgrammingConstructsPart1\bin\Debug");
            //== redefined to compare the values and not the objects in memory
            Console.WriteLine("hello" == "world");
            //loads new string on the managed heap; old string will b garbage collected
            string s5 = "My old string";
            s5 = "New string value";
            //modifying object’s internal character data
            //initially hold a string of 16 characters or fewer
            
            //If you append more characters than the specified limit, the StringBuilder object will copy its data
            //into a new instance and grow the buffer by the specified limit.
            StringBuilder sb = new StringBuilder("using System.Text.StringBuilder", 8);
            sb.Append(" working with data structures");
        }
    }
}

