using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<bool> mySet = new Stack<bool>();
            Stack<int> myStack = new Stack<int>();
            int[,] arr = new int[4, 4];
            arr[0, 0] = 1; arr[0, 1] = 2; arr[0, 2] = 3; arr[0, 3] = 4;
            arr[1, 0] = 2; arr[1, 1] = 1; arr[1, 2] = 4; arr[1, 3] = 3;
            arr[2, 0] = 4; arr[2, 1] = 3; arr[2, 2] = 2; arr[2, 3] = 1;
            arr[3, 0] = 3; arr[3, 1] = 4; arr[3, 2] = 1; arr[3, 3] = 2;
            
            for (int i = 0; i <= arr.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= arr.GetUpperBound(1) ; j++)
                {
                    if (myStack.Contains(arr[i, j]))
                    {
                        mySet.Push(false);
                        break;
                    }
                    else
                    {
                        myStack.Push(arr[i, j]);                        
                    }
                    if (j == arr.GetUpperBound(1))
                    {
                        myStack.Clear();
                    } 
                }
            }

            for (int i = 0; i <= arr.GetUpperBound(1); i++)
            {
                for (int j = 0; j <= arr.GetUpperBound(0); j++)
                {
                    if (myStack.Contains(arr[i, j]))
                    {
                        mySet.Push(false);
                        break;
                    }
                    else
                    {
                        myStack.Push(arr[i, j]);
                    }
                    if (j == arr.GetUpperBound(1))
                    {
                        myStack.Clear();
                    }
                }
            }

            if (mySet.Contains(false))
            {
                Console.Write("incorrect");
            }
            else
            {
                Console.Write("correct");
            }
            Console.ReadLine();
        }
    }
}
