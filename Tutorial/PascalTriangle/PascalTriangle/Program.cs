using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> myStack = new Stack<int>();
            myStack.Push(0); myStack.Push(1); myStack.Push(0);
            Console.WriteLine("       " + 1);
            string s = "      ";
            char[] charArr = s.ToCharArray();
            int myInt = 0;
            Stack<int> myCopy = new Stack<int>();
            
            for (int i = 0; i < 6; i++)
            {
                myCopy.Push(0);
                while (myStack.Count > 1)
                {
                    int x = myStack.Pop();
                    int y = myStack.Pop();
                    int z = x + y;
                    myCopy.Push(z);
                    myStack.Push(y);
                }
                myStack.Clear();
                myCopy.Push(0);
                for (int count = myInt; count < charArr.Length;  count++)
                {
                    Console.Write(charArr[count]);
                }
                myInt++;
                foreach (int item in myCopy)
                {
                    if(item != 0)                    
                    Console.Write(item + "  ");
                    myStack.Push(item);
                }                
                myCopy.Clear();
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
