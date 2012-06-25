using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    class Draw
    {
        double startPoint;

        public double StartPoint
        {
            get { return startPoint; }
            set { startPoint = value; }
        }

        public Draw() : this (10)
        {

        }

        public Draw(double x)
        {
            StartPoint = x;
        }

        public override string ToString()
        {
            return String.Format("Starting Point {0}", startPoint);
        }
    }
}
