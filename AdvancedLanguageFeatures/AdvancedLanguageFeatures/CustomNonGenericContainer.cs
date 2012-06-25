using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedLanguageFeatures
{
    class CustomNonGenericContainer
    {
        public static ArrayList employeeArrayList = new ArrayList();

        public Employee this[int index]
        {
            get { return (Employee)employeeArrayList[index]; }
            set { employeeArrayList[index] = value; }
        }
    }
}
