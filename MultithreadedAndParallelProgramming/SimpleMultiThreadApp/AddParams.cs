using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleMultiThreadApp
{
    class AddParams
    {
        public List<int> myList = null;

        public AddParams()
        {
            myList = new List<int>();
            myList.Add(10);
            myList.Add(20);
        }

        public void AddToParamsList(int x)
        {
            myList.Add(x);
        }
    }
}
