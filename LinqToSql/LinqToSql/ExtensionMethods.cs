using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToSql
{
    public static class ExtensionMethods
    {
        public static string ConvertToEuro(this decimal value)
        {
            value = value * 0.7959M;
            return String.Format("Euro {0}", value);
        }
    }
}
