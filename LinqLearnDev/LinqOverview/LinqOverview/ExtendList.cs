using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqOverview
{
    public static class ExtendList
    {
        public static long TotalSize(this List<MyFileInfo> value)
        {
            long sum = 0;
            foreach (MyFileInfo item in value)
            {
                sum = sum + item.Length;
            }
            return sum;
        }
    }
}
