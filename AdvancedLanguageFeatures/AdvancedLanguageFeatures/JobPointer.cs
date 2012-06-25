using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedLanguageFeatures
{
    unsafe class JobPointer
    {
        public Int32 Id;
        public String Keyword;
        public Double Remuneration;

        public JobPointer() : this (6784, "ASP.NET", 85000)
        {

        }

        public JobPointer (Int32 id, String key, Double salary)
	    {
            Id = id; Keyword = key; Remuneration = salary;
	    }

        public override string ToString()
        {
            return String.Format("Employee Id: {0}, Keyword: {1}, Remuneration: {2}",Id, Keyword, Remuneration);
        }
    }
}
