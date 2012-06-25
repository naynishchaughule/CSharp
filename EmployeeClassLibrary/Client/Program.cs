using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeeClassLibrary;
using System.Configuration;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            VicePresident vp = new VicePresident();
            Console.WriteLine(vp);
            AppSettingsReader r = new AppSettingsReader();
            string data = r.GetValue("naynish", typeof(String)).ToString();
            Console.WriteLine("\nGetting data from app.config");
            Console.WriteLine(data);
            Console.ReadLine();
        }
    }
}
