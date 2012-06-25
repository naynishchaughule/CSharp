using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    class SortByPrice : IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            return String.Compare(((ComparableFruit)x).Price.ToString(), ((ComparableFruit)y).Price.ToString());
        }
    }
}
