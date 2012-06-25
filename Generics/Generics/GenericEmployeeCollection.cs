using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics
{
    //type parameters for generic class
    class GenericEmployeeCollection<T>
    {
        public Dictionary<System.Int32, T> myGenDictionary = new Dictionary<int, T>();
        
        //Type parameters for members (methods and properties) are used when they are enclosed within non-generic Types
        //this is just a demo
        public void ShowListEntries<T>(params T[] arr)
        {
            List<T> myGenList = new List<T>();
            foreach (T item in arr)
            {
                myGenList.Add(item);
            }

            foreach (T item in myGenList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
