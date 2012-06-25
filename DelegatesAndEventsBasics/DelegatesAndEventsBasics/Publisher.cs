using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegatesAndEventsBasics
{
    class Publisher
    {
        public static event MyCustomDelegates.DelegateMath MyCustomEvent;
        public static MyCustomDelegates.DelegateNaynish obj;
        public Publisher()
        {
            MyCustomEvent += new MyCustomDelegates.DelegateMath(this.SimpleHandler);
             obj = new MyCustomDelegates.DelegateNaynish(SimpleHandler);

        }

        public void Fire()
        {            
            MyCustomEvent(10.32, 24.543, 2467.33);            
        }

        double SimpleHandler(params double[] args)
        {            
            foreach (double item in args)
            {
                Console.Write("{0} ", item);
            }
            return 34.78;
        }  
    }
}
