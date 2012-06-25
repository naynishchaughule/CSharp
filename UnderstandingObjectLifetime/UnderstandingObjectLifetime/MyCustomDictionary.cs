using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnderstandingObjectLifetime
{
    class MyCustomDictionary
    {        
        public static Dictionary<Object, Object> myDictionary = new Dictionary<object, object>();        
        static List<Object> values = new List<object>();

        public static Object GetValue(Object key)
        {
            Object val = 0;
            if (myDictionary.ContainsKey(key))
            {
                myDictionary.TryGetValue(key, out val);
            }
            return val;
        }

        //not the most effeccient way
        public static List<Object> GetKey(Object value)
        {           
            if (myDictionary.ContainsValue(value))
            {                
                foreach(KeyValuePair<Object, Object> item in myDictionary)
                {
                    if (item.Value.ToString() == value.ToString())
                    {
                        values.Add(item.Key);                       
                    }
                }
            }
            return values;
        }        
    }
}
