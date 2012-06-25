using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQtoObjects
{
    class Point
    {
        public Double X { get; set; }
        public Double Y { get; set; }

        public Point() : this (x: 20, y: 78)
        {

        }

        public Point(Double x, Double y)
        {
            X = x; Y = y;
        }

        public override string ToString()
        {
            return String.Format("[Point X: {0}, Y: {1}]", X, Y);
        }
    }
}
