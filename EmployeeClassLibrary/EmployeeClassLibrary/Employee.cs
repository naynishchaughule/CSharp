using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeClassLibrary
{
    public abstract class Employee
    {
        public Int32 Id { get; set; }
        public String Fname { get; set; }
        public String Lname { get; set; }
        public String Designation { get; set; }
        public String Phone { get; set; }
        public String Address { get; set; }
        public Double Salary { get; set; }

        public Employee(Int32 id, String fname, String lname, String designation, String phone, String address, Double salary)
        {
            Id = id; Fname = fname; Lname = lname; Designation = designation; Phone = phone; Address = address; Salary = salary;
        }

        public override string ToString()
        {
            return String.Format("Employee details:\nId: {0}, Fname: {1}, Lname: {2}\nDesignation: {3}\nPhone: {4}, Address: {5}\nSalary: {6}",
                Id, Fname, Lname, Designation, Phone, Address, Salary);
        }
    }
}
