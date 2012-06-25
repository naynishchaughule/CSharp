using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace StructuredExceptionHandling
{
    class MyCustomHashTable
    {
        public static Hashtable ht = new Hashtable();
        public void Add(Object key, Object value)
        {
            //You can see a list of exceptions thrown by any member
            //just hover your mouse over the member i.e. like the below Add() method
            ht.Add(key, value);        
        }
    }
}
