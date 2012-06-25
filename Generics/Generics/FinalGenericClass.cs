using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics
{
    class FinalGenericClass<A, B, C, D> where A : new ()
        where B : class //any class
        where C : IComparer<Fruit> //type(class/struct) that implements IComparer<Fruit>
        where D : Product //derived classes of Product
    {
        public void Show()
        {
            Console.WriteLine("FinalGenericClass<A, B, C, D>");            
        }
    }

    //derived generic class follows the constraints placed on the generic base class
    class FinalGenericDerivedClass<A, T> : FinalGenericClass<Double, String, ImplementIComparer, SatisfyingConstraints>
        where A : class
        where T : new ()
    {
        public override string ToString()
        {
            return String.Format("FinalGenericDerivedClass<A, T> type of A: {0}, type of T: {1}", typeof(A), typeof(T));
        }
    }

    class FinalNonGenericDerivedClass : FinalGenericClass<Int32, Product, ImplementIComparer, SatisfyingConstraints>
    {
    }
}
