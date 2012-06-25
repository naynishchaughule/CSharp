using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegatesAndEventsBasics
{
    class ListenerPart1
    {
        public ListenerPart1()
        {            
            Publisher.MyCustomEvent += new MyCustomDelegates.DelegateMath(p_MyCustomEvent);
            Publisher.obj += new MyCustomDelegates.DelegateNaynish(p_MyCustomEvent);
        }

        double p_MyCustomEvent(params double[] args)
        {
            double sum = 0;
            foreach (double item in args)
            {
                sum += item;
            }
            Console.WriteLine("p_MyCustomEvent");
            return sum;
        }       
    }
}
