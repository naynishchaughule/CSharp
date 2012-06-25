using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreProgrammingConstructsPart1
{
    //old application object
    class Program
    {
        public static System.Diagnostics.Process p;
        public static int Main()
        {
            Console.WriteLine("core constructs");            
            p = System.Diagnostics.Process.GetCurrentProcess();
            return 0;         
        }
    }
}
