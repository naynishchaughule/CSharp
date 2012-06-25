using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLibrary
{
    public class Basics
    {
        public Basics()
        {
            System.Windows.Forms.MessageBox.Show("version 3.0.0.0");
        }

        public Double Add(Double x, Double y)
        {
            return x + y;
        }

        public Double Subtract(Double x, Double y)
        {
            return x - y;
        }
    }
}

namespace Assemblies
{
    namespace Ambiguity
    {
        public class Basics
        {
            public Double Add(Double x, Double y)
            {
                return x - y;
            }
        }
    }
}