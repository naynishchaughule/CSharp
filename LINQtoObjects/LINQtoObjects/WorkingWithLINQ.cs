using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQtoObjects
{
    class WorkingWithLINQ
    {
        Dictionary<Int32, Rectangle> myDictionary = new Dictionary<int, Rectangle>();

        public void Add()
        {
            myDictionary.Add(001, new Rectangle(new Point(10.34, 90.34), new Point(23.12, 16.23)));
            myDictionary.Add(002, new Rectangle(new Point(10.34, 90.34), new Point(34.34, 39.47)));
            myDictionary.Add(003, new Rectangle(new Point(10.34, 90.34), new Point(47.29, 34.25)));
            myDictionary.Add(004, new Rectangle(new Point(10.34, 90.34), new Point(27.24, 18.36)));
            myDictionary.Add(005, new Rectangle(new Point(10.34, 90.34), new Point(27.46, 26.38)));
            myDictionary.Add(006, new Rectangle(new Point(10.34, 90.34), new Point(23.43, 24.23)));
        }

        public List<KeyValuePair<Int32, Rectangle>> Basics()
        {
            List<KeyValuePair<Int32, Rectangle>> temp = new List<KeyValuePair<int,Rectangle>>();
            //deferred execution: IEnumerable<T>, T is the type of the subset/resultset
            System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<Int32,Rectangle>> result = 
                         from item in myDictionary
                         where item.Key == 003
                         select item;
            
            foreach (var item in result)
            {                
                temp.Add(item);
            }
            return temp;
        }
    }
}
