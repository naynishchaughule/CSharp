using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritanceAndPolymorphism
{
    sealed class KashmirApple : Apple
    {
        public override void ShowFruitDetails()
        {
            Console.WriteLine("Kashmir apple called");
        }
    }
}
