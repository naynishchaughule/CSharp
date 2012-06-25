using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnderstandingObjectLifetime
{
    class Product
    {
        int id;
        string name;
        double cost;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }        

        public string Name
        {
            get { return name; }
            set { name = value; }
        }       

        public double Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        public Product(int id, string name, double cost)
        {
            Id = id;
            Name = name;
            Cost = cost;
        }
    }
}
