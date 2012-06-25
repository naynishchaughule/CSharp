using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritanceAndPolymorphism
{
    class Fruit
    {
        //If a base class wishes to define a method that may be (but does not have to be) overridden 
        //by a subclass, it must mark the method with the virtual keyword

        //default implementation, the sub classes may or may not override
        //virtual methods cannot be sealed because it is the default implementation for the subclasses
        public virtual void ShowFruitDetails()
        {
            Console.WriteLine("fruit called");
        }

        public void Display()
        {
            Console.WriteLine("display in fruit");
        }
    }
}
