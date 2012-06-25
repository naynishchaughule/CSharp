using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreProgrammingConstructsPart2
{
    struct StructDoctor
    {
        public Hospital hp;
        public int docID;
        public string docName;

        //reserved
        //public StructDoctor()
        //{

        //}

        public StructDoctor(Hospital hp, int docID, string docName)
        {
            this.hp = hp;
            this.docID = docID;
            this.docName = docName;
        }
    }
}
