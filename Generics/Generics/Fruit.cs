using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics
{
    class Fruit
    {        
        public String Name { get; set; }
        public Double Price { get; set; }
        public static IComparer<Fruit> SortByPrice 
        { 
            get 
            {
                return new SortFruitsByPrice();
            } 
        
        }

        public Fruit(String name, Double price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
           return String.Format("Fruit Name: {0}, Price: {1}", Name, Price);
        }
    }
}
