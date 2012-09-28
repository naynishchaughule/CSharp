using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqOverview
{
    class Course
    {
        public string Title;
        public int Year;
        public string Author;

        public Course(string Title, int Year, string Author)
        {
            this.Title = Title; this.Year = Year; this.Author = Author;
        }
    }
}
