using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnderstandingObjectLifetime
{
    class ShoppingCart
    {
        private SortedDictionary<Object, Object> sortedDictionary = new SortedDictionary<object, object>();

        public SortedDictionary<Object, Object> SortedDictionary
        {
            get { return sortedDictionary; }
            set { sortedDictionary = value; }
        }
    }
}
