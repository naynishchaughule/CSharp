using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningEncapsulatedClassTypes
{
    public class Rectangle : Geometry
    {
        int length, height;
        public Rectangle(int length, int height)
        {
            this.length = length;
            this.height = height;
        }

        public override void Area()
        {
            Console.WriteLine("Area of a rectangle {0}", length * height);
            Console.WriteLine("Color {0}", SolidColor.green);
        }
    }
}
