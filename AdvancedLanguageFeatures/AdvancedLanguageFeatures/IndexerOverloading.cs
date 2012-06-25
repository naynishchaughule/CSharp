using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedLanguageFeatures
{
    class IndexerOverloading : IEnumerable
    {
        public static Hashtable ht = new Hashtable();

        public Employee this[int index]
        {
            get { return (Employee)ht[index]; }
            set { ht[index] = value; }
        }

        public object this[String index]
        {
            get { return (Employee)ht[index]; }
            set { ht[index] = value; }
        }

        public IEnumerator GetEnumerator()
        {
            return ht.GetEnumerator();
        }
    }
}
