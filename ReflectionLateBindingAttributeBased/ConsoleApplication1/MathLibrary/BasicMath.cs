using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLibrary
{
    public class BasicMath
    {
        public double Add(object x, object y)
        {
            return Convert.ToDouble(x) + Convert.ToDouble(y);
        }

        public class Trigonometry
        {
            public string Display()
            {
                return "Trigonometry.Display() called!";
            }
        }
    }
}
