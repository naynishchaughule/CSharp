using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningEncapsulatedClassTypes
{
    partial class Placement
    {
        public void DisplayPlacementStats()
        {
            Console.WriteLine("officer {0} company {1}", this.PlacementOfficer, this.Company);
        }
    }
}
