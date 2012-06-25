using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedLanguageFeatures
{
    unsafe struct MyPoint
    {
        public int x;
        public int y;
        public override string ToString()
        {
            return string.Format("({0}, {1})", x, y);
        }
    }

    public unsafe struct Node
    {
        public Int32 Value;
        public Node* Left;
        public Node* Right;
    }

    public struct Node2
    {
        public Int32 Value;
        public unsafe Node2* Left;
        public unsafe Node2* Right;
    }

    public unsafe class WorkingWithPointers
    {
        public void Basics()
        {
            Int32* p1;
            Int32 memVal;
            p1 = &memVal;
            //pointer indirection
            *p1 = 90;
            Console.WriteLine(*p1);
            Console.WriteLine(memVal);
            Console.WriteLine((int)&memVal);
        }

        public unsafe void Square(Int32* x)
        {
            *x *= *x;
            Console.WriteLine("\nSquare: {0}", *x);
        }

        public void Swap(Int32* x, Int32* y)
        {            
            Int32 temp;
            temp = *x;
            *x = *y;
            *y = temp;
            Console.WriteLine("{0} {1}", *x, *y);
        }
    }
}
