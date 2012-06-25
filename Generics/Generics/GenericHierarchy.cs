using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics
{
    //rule 1: if a non-generic class extends a generic class, the derived class must specify a type parameter
    //rule 2: if the generic base class defines generic virtual or abstract methods, the derived type must
    //override the generic methods using the specified type parameter
    //generic class
    //default constructor constraint
    class GenericHierarchy<T> where T : new ()
    {
        public virtual void Display(T x)
        {
            Console.WriteLine("Value of x: {0}", x);
        }
    }

    //non-generic class
    class Derived : GenericHierarchy<Int32>
    {
        public override void Display(Int32 x)
        {
            base.Display(x);
        }
    }

    //rule 3: if the derived type is generic as well, the child class can (optionally) reuse the type
    //placeholder in its definition. However, be aware that any constraints (see next section) placed on the
    //base class must be honored by the derived type, as in this example

    class GenericDerived<T, U> : GenericHierarchy<Int32> where T : new ()
    {
        public void DisplayValues(T x, U y)
        {
            Console.WriteLine("Value of x: {0}, y: {1}", x, y);
        }
    }
}
