using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedLanguageFeatures
{
    class TwoDimensionalProblem : IEnumerable
    {
        public static Int32[,] twoArr = new Int32[3,4];

        public Int32 this[int x, int y]
        {
            get { return twoArr[x, y]; }
            set { twoArr[x, y] = value; }
        }
        
        public IEnumerator GetEnumerator()
        {
            return twoArr.GetEnumerator();
        }
    }
}