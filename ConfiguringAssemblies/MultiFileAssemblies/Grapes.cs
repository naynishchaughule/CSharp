using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fruit
{
    //primary module (can be *.dll/*.exe)
    public class Grapes
    {
        public String Name { get; set; }
        public Double Price { get; set; }

        public Grapes() : this("kashmir", 1.67)
        {

        }

        public Grapes(String name, Double price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return String.Format("Fruit name: {0}, price: {1}", Name, Price);
        }
    }
}