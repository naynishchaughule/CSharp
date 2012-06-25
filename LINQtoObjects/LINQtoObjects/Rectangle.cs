using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQtoObjects
{
    class Rectangle
    {
        public Point TopLeft { get; set; }
        public Point BottomRight { get; set; }

        public Rectangle() : this (new Point(24, 43), new Point(56, 69))
        {

        }

        public Rectangle(Point topLeft, Point bottomRight)
        {
            TopLeft = topLeft; BottomRight = bottomRight;
        }

        public override string ToString()
        {
            return String.Format("Rectangle TopLeft: {0},\nBottomRight: {1}", TopLeft, BottomRight);
        }
    }
}
