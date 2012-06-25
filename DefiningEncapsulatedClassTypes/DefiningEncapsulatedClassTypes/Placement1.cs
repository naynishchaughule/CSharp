using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningEncapsulatedClassTypes
{
    //The only requirement when defining partial types is that the 
    //type’s name (Placement in this case) is identical and defined within the same .NET namespace
    partial class Placement
    {
        //runtime will generate a private backing field
        public string Company { get; set; }
        string placementOfficer;

        public string PlacementOfficer
        {
            get { return placementOfficer; }
            set { placementOfficer = value; }
        }

        public Placement(string officer, string company)
        {
            placementOfficer = officer;
            Company = company;
        }
    }
}
