using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics
{
    class EmployeeObjectCollection : IEnumerable
    {
        //as you can see we have implemented only a few members of the type safe custom collection
        //production level collection will have numerous such members
        //its tedious to write all the type safe members
        //underlying data structure
        Hashtable htEmployee = new Hashtable();

        //now my Add is prototyped to accept only Employee objects
        //if you try to pass in any other type then you will receive a compile time error
        public void Add(Employee e)
        {
            htEmployee.Add(e.Id, e);            
        }

        public void Clear()
        {
            htEmployee.Clear();
        }

        public void Remove(Employee e)
        {
            htEmployee.Remove(e.Id);
        }

        public Employee GetValue(int e)
        {
            Employee temp = new Employee();
            if (htEmployee.ContainsKey(e))
            {
                foreach (DictionaryEntry item in htEmployee)
                {
                    if (e.ToString() == item.Key.ToString())
                    {
                        temp = (Employee)item.Value;
                    }                    
                }
            }
            return temp;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return htEmployee.GetEnumerator();
        }
    }
}
