using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritanceAndPolymorphism
{
    //containing class
    class OuterClass
    {
        int privMem = 50;
        InnerClass obj = new InnerClass();
        // A public nested type can be used by anybody.
        // A private nested type can only be used by members of the containing class.
        //private by default
        //helper for the outer class, not intended for use by the outside world.
        //contained class
       
        
        
                    class InnerClass
                    {
                        public int i = 10;
                        private int point = 100;
                        OuterClass obOuter = new OuterClass();
                        public void ShowInnerClass()
                        {
                            //can access the private members of the outer class
                            Console.WriteLine(obOuter.privMem);
                            Console.WriteLine();
                        }
                    }        



        public void Display()
        {
            //cannot access the private members of the inner class
            //obj.point = 250;
            obj.i = 20;
            Console.WriteLine(obj.i);
        }
    }
}
