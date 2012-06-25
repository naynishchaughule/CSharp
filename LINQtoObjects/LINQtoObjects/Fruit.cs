using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQtoObjects
{
    class Fruit
    {
        public String Name { get; set; }
        public Double Price { get; set; }

        public Fruit()
        {

        }

        public override string ToString()
        {
            return String.Format("Fruit, Name: {0}, Price: {1}", Name, Price);
        }
    }
}
