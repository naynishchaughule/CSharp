using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics
{
    class GenericStructure<T>
    {
        T p1, p2;

        public T P2
        {
            get { return p2; }
            set { p2 = value; }
        }

        public T P1
        {
            get { return p1; }
            set { p1 = value; }
        }

        public GenericStructure(T x, T y)
        {
            P1 = x;
            P2 = y;
        }

        public void Reset()
        {
            P1 = default(T);
            P2 = default(T);
        }

        public override string ToString()
        {
            return String.Format("\nPoint: x: {0}, y: {1}", P1, P2);
        }
    }
}
