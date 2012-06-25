using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegatesEventsAndLambdas
{
    class Fruit
    {
        public String Name { get; set; }

        public Fruit(String name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return String.Format("{0}", Name);
        }
    }

    class Mango : Fruit
    {
        public String Location { get; set; }
        public Mango(String name, String location) : base (name)
        {
            Location = location;
        }

        public override string ToString()
        {
            return base.ToString() + String.Format(" Location {0}", Location); ;
        }
    }
}
