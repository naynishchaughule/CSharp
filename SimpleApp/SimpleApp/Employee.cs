using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleApp
{
    abstract class Employee
    {
        private int _empId;
        private string _fname;
        private string _lname;
        private string _address;
        private string _designation;
        private double _salary;        
        //employee can be assigned to one or many projects
        private List<Project> _projectAssigned = new List<Project>() { };        

        public int EmpId
        {
            get { return _empId; }
            set { _empId = value; }
        }        

        public string Fname
        {
            get { return _fname; }
            set { _fname = value; }
        }        

        public string Lname
        {
            get { return _lname; }
            set { _lname = value; }
        }        

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }        

        public string Designation
        {
            get { return _designation; }
            set { _designation = value; }
        }        

        public double Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }   

        internal List<Project> ProjectAssigned
        {
            get { return _projectAssigned; }
            set { _projectAssigned = value; }
        }

        public Employee(int empId, string fname, string lname, string address, string designation, double salary)
        {
            EmpId = empId;
            Fname = fname;
            Lname = lname;
            Address = address;
            Designation = designation;
            Salary = salary;
        }

        public void AssignProject(Project p)
        {            
            ProjectAssigned.Add(p);
            p._employeeCount++;
        }

        public void ListAllMyTasks()
        {
            foreach (Project item in this.ProjectAssigned)
	        {
                foreach (Task t in item.TasksInProject)
	            {
                    Console.WriteLine(t.TaskName);
	            } 
	        }
        }
    }
}
