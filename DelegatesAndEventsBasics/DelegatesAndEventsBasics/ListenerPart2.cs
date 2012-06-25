using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegatesAndEventsBasics
{
    class ListenerPart2
    {
        public ListenerPart2()
        {            
            Publisher.MyCustomEvent += new MyCustomDelegates.DelegateMath(this.BasicEventModel);
            Publisher.obj += new MyCustomDelegates.DelegateNaynish(BasicEventModel);
            Delegate[] arr = Publisher.obj.GetInvocationList();

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }

            for (int i = 0; i < arr.Length; i++)
			{
                if (i == 0)
                    Publisher.obj -= (MyCustomDelegates.DelegateNaynish)arr[1];  
			}
        }

        double BasicEventModel(params double[] args)
        {
            double product = 1;
            foreach (double item in args)
            {
                product *= item;
            }
            
            Console.WriteLine("BasicEventModel fired");
            return product;
        }
    }
}
