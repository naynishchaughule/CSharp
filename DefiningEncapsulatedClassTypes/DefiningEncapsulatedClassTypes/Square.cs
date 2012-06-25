using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningEncapsulatedClassTypes
{
    //public or internal
    public class Square : Geometry
    {
        public int side;
        public Square(int side)
        {
            this.side = side;
        }

        //virtual or abstract members cannot be private
        public override void Area()
        {
            Console.WriteLine("Area of a square {0}", side * side);
            Console.WriteLine("Color {0}", SolidColor.blue);
        }
    }
}
