using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics
{
    class SortFruitsByPrice : IComparer<Fruit>
    {
        public int Compare(Fruit x, Fruit y)
        {
            return String.Compare(x.Price.ToString(), y.Price.ToString());
        }
    }
}
