using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqOverview
{
    public class MyFileInfo
    {
        public string Name { get; set; }
        public long Length { get; set; }
        public DateTime CreationTime { get; set; }

        public MyFileInfo(string Name)
        {
            this.Name = Name;
        }

        public override string ToString()
        {
            return String.Format("Name: {0}, Length: {1}, Creation Time: {2}", Name, Length, CreationTime);
        }
    }
}
