using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritanceAndPolymorphism
{
    class Apple : Fruit 
    {
        //overridden members can be sealed so that it is no overridden further
        //sealed public override void ShowFruitDetails()
        public override void ShowFruitDetails()
        {
            Console.WriteLine("apple called");
        }

        //hiding the Display() method of the Fruit class
        //shadowing, completely opposite of overriding
        //two options, mark Display() in base as virtual and overridde the same in the sub class
        //but with this option i may not have access to modify the base class as it can be a dll
        //the second option is to hide the Display() in base by marking the sub class method as new
        //in short we are overridding the base class's method without marking it as virtual in the base class
                
        //Doing so explicitly states that the derived type’s implementation is intentionally designed to effectively ignore the parent’s version
        //You can also apply the new keyword to any member type inherited from a base class (field, constant, static member, or property).
        public new void Display()
        {
            //can call the base class's implementation of display by using base keyword
            base.Display();
            Console.WriteLine("display in Apple");
        }
    }
}
