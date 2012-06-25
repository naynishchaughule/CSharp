using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCustomLibrary
{
    public class DevelopmentEnvironment
    {
        public void ShowMyEnvironment()
        {
            Console.WriteLine("System.Environment.Version {0}", System.Environment.Version);
            Console.WriteLine("System.Environment.OSVersion {0}", System.Environment.OSVersion);
            Console.WriteLine("System.Environment.ProcessorCount {0}", System.Environment.ProcessorCount);
            Console.WriteLine("System.Environment.MachineName {0}", System.Environment.MachineName);
            Console.WriteLine("System.Environment.UserName {0}", System.Environment.UserName);
            Console.WriteLine("System.Environment.SystemDirectory {0}", System.Environment.SystemDirectory);
            Console.WriteLine("System.Environment.CurrentDirectory {0}", System.Environment.CurrentDirectory);

        }
    }
}
