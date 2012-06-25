using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedLanguageFeatures
{
    partial class Movie
    {
        //implementation
        partial void ShowDetails()
        {
            Console.WriteLine(Name);
        }
    }
}
