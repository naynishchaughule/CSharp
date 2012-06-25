using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics
{
    //C# compiler will check Type Parameter constraints at compile time
    //T should be a class and should support a default constructor
    //T should be a derived class of Product and should implement the IComparable<Double> interface
    class TypeParameterConstraints<T> where T : Product, IComparable<SatisfyingConstraints>, new()
    {
        public void Show(T obj)
        {
            Console.WriteLine("\ntype of T: {0}", typeof(T));
            Console.WriteLine(obj);
        }
    }

    //this class satisfies all the type parameter constraints of class TypeParameterConstraints<T>
    class SatisfyingConstraints : Product, IComparable<SatisfyingConstraints>
    {
        Double x;

        public Double X
        {
            get { return x; }
            set { x = value; }
        }

        public SatisfyingConstraints()
        {

        }

        public SatisfyingConstraints(Double x)
        {
            X = x;
        }

        public int CompareTo(SatisfyingConstraints other)
        {
            if (this.X < other.X)
            {
                return -1;                     
            }
            else if (this.X > other.X)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return String.Format("\nvalue of x: {0} in SatisfyingConstraints", X);
        }
    }
}
