using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fruit
{
    //there can be multiple secondary modules
    //*.netmodule
    public class Mango
    {
        public String Name { get; set; }
        public Double Price { get; set; }

        public Mango() : this ("ratnagiri", 4.5)
        {
                    
        }

        public Mango(String name, Double price)
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