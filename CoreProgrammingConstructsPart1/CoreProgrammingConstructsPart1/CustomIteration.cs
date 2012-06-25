using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreProgrammingConstructsPart1
{
    class CustomIteration
    {
        public int i;
        public Car[] carArr = new Car[3];
        public static int count = 0;
        public CustomIteration(int i, Car obj)
        {
            this.i = i;
            carArr[count] = obj;
            count++;
        }
    }
}
