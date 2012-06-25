using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreProgrammingConstructsPart2
{
    struct Point
    {
        public int x, y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void DisplayPoint()
        {
            Console.WriteLine("Point {0} {1}", x, y);
        }
    }
}
