using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedLanguageFeatures
{
    class Factorial
    {
        Double fact = 1;
        Int32 first = 1, second = 1, recFirst = 1, recSecond = 1;

        public Double Calculate(Double f)
        {            
            fact *= f;
            if (f - 1 > 1)
                Calculate(f - 1);
            return fact;
        }

        public void Fibonacci()
        {
            Int32 temp;
            Console.Write("1 "); Console.Write("1 ");
            for (int i = 0; i < 10; i++)
            {                
                temp = first + second;
                Console.Write(temp + " ");
                first = second;
                second = temp;
            }
        }

        public void FibonacciRecursion(out Int32 x)
        {
            x = recFirst + recSecond;
            if (x < 100)
            Console.Write(x + " ");
            recFirst = recSecond;            
            recSecond = x;
            if (x < 100)
                FibonacciRecursion(out x);
        }
    }
}
