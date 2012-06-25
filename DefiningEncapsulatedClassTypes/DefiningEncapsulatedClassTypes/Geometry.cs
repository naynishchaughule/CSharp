using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningEncapsulatedClassTypes
{
    public abstract class Geometry
    {
        public abstract void Area();
        //nested type
        protected enum SolidColor
        {
            blue,
            white,
            green
        }
    }
}
