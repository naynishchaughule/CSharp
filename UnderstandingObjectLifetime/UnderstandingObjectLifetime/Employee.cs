using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnderstandingObjectLifetime
{
    class Employee
    {
        int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public Employee() : this (10)
        {

        }

        public Employee(int id)
        {
            Id = id;
        }
    }
}
