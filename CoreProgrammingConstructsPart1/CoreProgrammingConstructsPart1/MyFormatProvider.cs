using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreProgrammingConstructsPart1
{
    class MyFormatProvider : IFormatProvider
    {
        public object GetFormat(Type formatType)
        {
            return " DHP";
        }
    }
}
