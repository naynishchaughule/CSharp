using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritanceAndPolymorphism
{
    class Mango : Fruit
    {
        public override void ShowFruitDetails()
        {
            Console.WriteLine("mango called");
        }

        public new void Display()
        {
            Console.WriteLine("display in Mango");
        }

        public void CEO()
        {
            Console.WriteLine("tripti panjabi heads Mango");
        }
    }
}
