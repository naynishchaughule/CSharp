using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BuildingCSharpApplications
{    
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Building C# Applications");
            ReadCommandLineArgs();
            Car obj = new SUV("CRV");
            Console.WriteLine(((SUV)obj).GetName());
            Car objnew = new Car("accord");
            Console.ReadLine();
        }


        public static void ReadCommandLineArgs()
        {
            foreach (string item in System.Environment.GetCommandLineArgs())
                Console.WriteLine(item);            
        }
    }
}
