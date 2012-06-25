using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQtoObjects
{
    static class StringBuilderExtension
    {
        public static StringBuilder ExtensionMethod(this StringBuilder str)
        {
            return str.Append("naynish p. chaughule");
        }
    }
}
