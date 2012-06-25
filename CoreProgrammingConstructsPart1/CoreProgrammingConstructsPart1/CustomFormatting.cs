using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreProgrammingConstructsPart1
{
    class CustomFormatting : ICustomFormatter
    {
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            return "naynish $ " + format + ((NewApplicationObject)arg).Display() + formatProvider.GetFormat(new Int32().GetType());
        }
    }
}
