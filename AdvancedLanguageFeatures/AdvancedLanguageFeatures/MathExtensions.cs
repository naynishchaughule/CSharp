using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyExtensionsLibrary;

namespace AdvancedLanguageFeatures
{
    static class MathExtensions
    {
        public static Double Subtract(this IBasicMath ib, Double x, Double y)
        {
            return x - y;
        }
    }
}
