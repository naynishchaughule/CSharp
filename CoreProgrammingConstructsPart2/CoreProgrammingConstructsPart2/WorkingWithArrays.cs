using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreProgrammingConstructsPart2
{
    class WorkingWithArrays
    {
        public void SimpleArrays()
        {
            //System.Array
            //array initialization syntax, new keyword and size
            int[] intArr = new int[5] { 1, 23, 78, 93, 26};
            string[] arr = new string[] { "nash", "tripz", "purab", "jay"};
            double[] doubleArr = new double[3];
            System.Boolean[] b = new Boolean[] { true, true, false};
            System.Boolean[] b1 = { false, true, false};
            //implicitly typed local arrays
            var a = new [] { 20, 30, 40, 50};
            var stringArr = new[] { "hello", "world", "!"};
            System.Object[] objectArr = new System.Object[] { 10, 34.56, true, "object array"};
            foreach (double item in doubleArr)
            {
                Console.WriteLine(item);
            }

            foreach (System.Object item in objectArr)
            {
                Console.WriteLine("{0} {1}", item, item.GetType());
            }

            //multidimensional arrays
            //each row is of the same length
            int[,] rectArr = new int [3,4];
            int dimensions = rectArr.Rank; //2 (zero based)
            int cols = rectArr.GetUpperBound(--dimensions); 
            int rows = rectArr.GetUpperBound(--dimensions);            

            for (int i = 0; i <= rows; i++)
            {
                for (int j = 0; j <= cols; j++)
                {
                    rectArr[i, j] = i * j;
                }
            }

            for (int i = 0; i <= rows; i++)
            {
                for (int j = 0; j <= cols; j++)
                {
                    Console.Write(rectArr[i, j] + "  ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n");
            //jagged arrays, an array of arrays
            int[][] jaggedArray = new int[3][];
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                jaggedArray[i] = new int[i + 7];
            }

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    jaggedArray[i][j] = i * j;
                }
            }

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + "     ");
                }
                Console.WriteLine();
            }

            SystemArrayFunctionality();
        }

        static void SystemArrayFunctionality()
        {
            Console.WriteLine();
            int[] arr = new int[] { 110, 12, 40, 9};
            System.Array.Clear(arr, 2, 2);
            foreach (int item in arr)
            {
                Console.WriteLine(item);
            }
            int[] myCopy = arr;
            foreach (int item in myCopy)
            {
                Console.Write(item + " ");
            }
            
            Console.WriteLine();
            foreach (int item in myCopy.Reverse<int>())
            {
                Console.Write(item + " ");
            }
            int[] arrSort = new int[] { 110, 12, 40, 9};
            System.Array.Sort(arrSort);
            Console.WriteLine("\n");
            foreach (int item in arrSort)
            {
                Console.Write(item + " ");
            }
        }
    }
}
