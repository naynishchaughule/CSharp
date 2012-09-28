using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqOverview
{
    public static class ExtendingInt
    {
        public static bool IsEven(this int value)
        {
            if (value % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
