using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCustomLibrary
{
    public class MyCustomExceptionHandlingMechanism : System.ApplicationException
    {
        public void ShowExceptionDetails()
        {
            Console.WriteLine(this.Message);
            Console.WriteLine(this.Source);
            Console.WriteLine(this.TargetSite);
            Console.WriteLine(this.StackTrace);
            
        }
    }
}
