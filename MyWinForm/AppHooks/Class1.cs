using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace AppHooks
{
    public interface MyApplicationInterface
    {
        void DisplayMessage();
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class MyCustomAttributes : System.Attribute
    {
        public string Url { get; set; }
    }
}
