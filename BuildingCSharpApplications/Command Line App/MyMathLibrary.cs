using System;
namespace MyMathLibrary
{
    public class MyMathClass
    {
        public static double Add(params double[] args)
        {
            double sum = 0;
            foreach (double item in args)
                sum += item;
            return sum;
        }
    }
}