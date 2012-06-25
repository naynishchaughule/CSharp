using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    class SortByName : IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            return String.Compare(((ComparableFruit)x).Name, ((ComparableFruit)y).Name);
        }
    }
}
