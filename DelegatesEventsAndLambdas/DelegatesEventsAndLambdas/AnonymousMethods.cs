using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegatesEventsAndLambdas
{
    class AnonymousMethods
    {
        public String msg { get; set; }
        public delegate void MyAnonymous(Object sender, EventArgs e);
        public event MyAnonymous eveA;

        public void DoSomeWork()
        {
            eveA.Invoke(this, new EventInformation("hello world!"));
        }

        public override string ToString()
        {
            return String.Format("Anonymous methods...{0}", msg);
        }
    }
}
