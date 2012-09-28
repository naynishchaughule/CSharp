using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Now list any assembly/module level attributes.
// Enforce CLS compliance for all public types in this assembly.
[assembly: CLSCompliant(true)]
namespace AttributedEmployeeLibrary
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class EmployeeDescriptionAttribute : System.Attribute
    {
        //compiler warning
        public ulong notCompliant;
        public String Description
        {
            get;
            set;
        }

        public EmployeeDescriptionAttribute()
        {

        }

        public EmployeeDescriptionAttribute(String desc)
        {
            Description = desc;
        }
    }

    [EmployeeDescription(Description = "new Vice President!")]
    public class VicePresident
    {
        private string Fname { get; set; }
        public ulong sal { get; set; }

        public VicePresident()
        {
            Fname = "tripti";
        }

        public VicePresident(string fname)
        {
            Fname = fname;
        }

        public string GetFname()
        {
            return Fname;
        }
    }

    [EmployeeDescription(Description = "Senior Manager JP Morgan")]
    public class Manager
    {
        private string Fname { get; set; }
        public ulong sal { get; set; }

        public Manager()
        {
            Fname = "tripti";
        }

        public Manager(string fname)
        {
            Fname = fname;
        }

        public string GetFname()
        {
            return Fname;
        }
    }
}
