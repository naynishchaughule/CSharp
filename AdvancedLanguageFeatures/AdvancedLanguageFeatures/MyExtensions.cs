using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedLanguageFeatures
{
    //extending is not inheriting: extension methods do not have direct access to the members of the type they are extending
    //rule1: class should be static
    static class MyExtensions
    {
        //rule2: this should be first (and only the first) parameter of the method
        public static void ShowAssemblyDetails(this Object obj)
        {
            Console.WriteLine("\n" + (obj.GetType()).Assembly.FullName);
        }

        //It is always the case that the first parameter of an extension
        //method represents the type being extended.
        public static Double GetSquare(this Double x)
        {
            return x * x;
        }
    }
}
