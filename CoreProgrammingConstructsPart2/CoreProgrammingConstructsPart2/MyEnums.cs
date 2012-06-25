using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreProgrammingConstructsPart2
{
    enum Designation : sbyte
    {
        //System.Enum
        //named constants
        //the first element is set to the value zero
        //need not follow a sequential ordering, need not have unique values
        //System.Int32                
        programmer = 1,
        vicepresident,
        ceo = 10,
        founder = 100
    }

    class MyEnums
    {       
        public static void WorkingWithEnums()
        {
            //Type represents the metadata description of a given .NET entity
            //typeof(int); //gets the System.Type
            //int i = 10;
            //i.GetType(); // gets the System.Type of the current instance
            Designation e = Designation.ceo;
            switch (e)
            {
                case Designation.founder:                   
                case Designation.ceo:
                    //extract name and value
                    string s = Designation.ceo.ToString();
                    Console.WriteLine("Employee.ceo called {0} {1} {2}", s, (sbyte)Enum.Parse(typeof(Designation), "ceo"), Enum.GetUnderlyingType(typeof(Designation)));
                    Console.WriteLine("free fall founder {0}", (sbyte)Designation.founder);
                    Console.WriteLine("enum formatting "+ System.Enum.Format(typeof(Designation), Designation.ceo, "x"));
                    System.Array arr;
                    arr = Enum.GetValues(typeof(Designation));
                    for (int i = 0; i < arr.Length; i++)
                    {
                        Console.WriteLine("{0}", (sbyte)arr.GetValue(i));
                    }
                                        
                    for (int i = 0; i < System.Enum.GetValues(typeof(DayOfWeek)).Length; i++)
                    {
                        Console.WriteLine("iterate over any enum {0}", (DayOfWeek)i);
                    }

                    for (int i = 0; i < System.Enum.GetValues(typeof(ConsoleColor)).Length; i++)
                    {
                        Console.WriteLine("iterating ConsoleColor enum {0}", (ConsoleColor)i);
                    }

                    break;
                case Designation.vicepresident:
                    break;
                case Designation.programmer:
                    break;
                default:
                    break;
            }
        }
    }
}
