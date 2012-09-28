using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    [Serializable]
    class AttributeBased
    {
        public string fname;

        //Attribute as suffix
        [NonSerialized, ObsoleteAttribute("do not use salary")]
        public double salary;
        [NonSerialized]
        public int id;
    }
}
