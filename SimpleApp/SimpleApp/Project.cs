using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleApp
{
    class Project
    {
        private int _pId;
        private string _pName;
        private DateTime _pStartDate;
        private DateTime _pEndDate;
        //project can have one or many tasks
        private List<Task> _tasksInProject = new List<Task>() { };
        public int _employeeCount = 0;

        public int PId
        {
            get { return _pId; }
            set { _pId = value; }
        }       

        public string PName
        {
            get { return _pName; }
            set { _pName = value; }
        }       

        public DateTime PStartDate
        {
            get { return _pStartDate; }
            set { _pStartDate = value; }
        }      

        public DateTime PEndDate
        {
            get { return _pEndDate; }
            set { _pEndDate = value; }
        }      

        internal List<Task> TasksInProject
        {
            get { return _tasksInProject; }
            set { _tasksInProject = value; }
        }

        //sum of the cost of each task
        public Double ProjectBudget()
        {
            double _totalBudget = 0;
            foreach (Task item in TasksInProject)
            {
                _totalBudget += item.AmountBilledToClient();
            }
            return _totalBudget;
        }

        public Project(int pId, string pName, DateTime pStartDate, DateTime pEndDate)
        {
            PId = pId;
            PName = pName;
            PStartDate = pStartDate;
            PEndDate = pEndDate;
        }

        public void AddTask(Task t)
        {
            TasksInProject.Add(t);
        }

        public int ProjectEmployeeCount()
        {
            return _employeeCount;
        }
    }
}
