using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedLanguageFeatures
{
    partial class Movie
    {
        public String Name { get; set; }

        public void Configure(string name)
        {
            Name = name;
            ShowDetails();
        }

        //private by default: Header
        //should return only void
        partial void ShowDetails();      
    }
}
