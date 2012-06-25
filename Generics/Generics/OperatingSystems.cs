using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics
{
    class OperatingSystems : IComparer<OperatingSystems>
    {
        public String Name { get; set; }
        public Double Cost { get; set; }

        public OperatingSystems()
        {

        }

        public OperatingSystems(String name, Double cost)
        {
            Name = name; Cost = cost;
        }

        //if I implement IComparer<OperatingSystems> here then I just get one sort order
        //the method Compare(OperatingSystems x, OperatingSystems y) will clash even if we implement the interface explicitly
        public int Compare(OperatingSystems x, OperatingSystems y)
        {
            return String.Compare(x.Cost.ToString(), y.Cost.ToString());
        }

        public override string ToString()
        {
            return String.Format("\nOS Name: {0}, Cost: {1}", Name, Cost);
        }
    }
}
