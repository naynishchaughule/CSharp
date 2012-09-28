using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFirstApp
{
    class Employee : System.Object
    {
        public int Id;
        public static int OrgID;
        public int DeptID;
        public Employee()
        {

        }

        public Employee(int id, int deptid)
        {
            Id = id;
            DeptID = deptid;
        }

        public override string ToString()
        {
            return String.Format("Employee Id: {0}, OrgID: {1}, DeptId: {2}", Id, OrgID, DeptID);
        }
    }
}
