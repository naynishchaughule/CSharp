using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedLanguageFeatures
{
    class UsingDataTable
    {
        public static DataTable dt = new DataTable("Collection");
        public static void WorkingWithDataTables()
        {            
            dt.Columns.Add("firstname"); dt.Columns.Add("lastname"); dt.Columns.Add("salary");
            dt.Rows.Add("naynish", "chaughule", 85000);
            dt.Rows.Add("tripti", "panjabi", 65000);
            dt.Rows.Add("jay", "bhatt", 69000);
        }
    }
}
