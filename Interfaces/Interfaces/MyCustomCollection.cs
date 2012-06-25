using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    class MyCustomCollection : IEnumerable
    {
        //underlying collection
        private Dictionary<Object, Object> note = new Dictionary<object, object>();

        public MyCustomCollection()
        {
            note.Add("001", 45.67);
            note.Add("002", 345.26);
            note.Add("003", 13.89);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return note.GetEnumerator();
        }

        //named iterator: return type is IEnumerable
        public IEnumerable DisplayJustValues()
        {
            return note.Values;
        }

        //named iterator and just using an internal foreach
        public IEnumerable UsingForeachInternally()
        {
            foreach (KeyValuePair<Object, Object> item in note)
            {
                yield return item;
            }
        }
    }
}
