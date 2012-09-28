using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CachedFactorial
{
    class Program
    {
        static Dictionary<ulong, ulong> myDictionary = new Dictionary<ulong, ulong>();
        static void Main(string[] args)
        {
            bool status = true;            
            while(status)
            {
                Console.Write("Enter a number: ");
                ulong myVar = Convert.ToUInt64(Console.ReadLine());
                ulong result = CalculateCachedFactorial(myVar);
                myDictionary.Add(myVar, result);
                Console.WriteLine("Factorial of {0} is {1}", myVar, result);
                Console.Write("Do you wish to continue(y/n): ");
                String statusCode = Console.ReadLine();
                if (statusCode == "n")
                    status = false;
            }
        }

        static ulong CalculateCachedFactorial(ulong myVar)
        {            
            if (myDictionary.ContainsKey(myVar) && myVar > 1)
            {
                myVar = myDictionary[myVar];
                return myVar;
            }
            else if (myVar > 1)
            {
                myVar = myVar * CalculateCachedFactorial(myVar - 1);
            }
            return myVar;
        }
    }
}
