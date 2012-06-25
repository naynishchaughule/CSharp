using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedLanguageFeatures
{
    class EmployeeDictionary : IEnumerable
    {
        public static Dictionary<String, Employee> customEmployeeDictionary = new Dictionary<string, Employee>();

        public Employee this[String index]
        {
            get { return customEmployeeDictionary[index]; }
            set { customEmployeeDictionary[index] = value; }
        }

        public static Employee GetValue(String key)
        {
            if (customEmployeeDictionary.ContainsKey(key))
            {
                return customEmployeeDictionary[key];
            }
            else
            {
                return null;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return customEmployeeDictionary.GetEnumerator();
        }
    }
}
