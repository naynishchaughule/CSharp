using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleApp
{
    class Task
    {
        private int _taskId;
        private string _taskName;
        private DateTime _taskStartDate;
        private DateTime _taskEndDate;
        private double _hoursAllocated;
        private double _dollarsPerHour;

        public int TaskId
        {
            get { return _taskId; }
            set { _taskId = value; }
        }        

        public string TaskName
        {
            get { return _taskName; }
            set { _taskName = value; }
        }        

        public DateTime TaskStartDate
        {
            get { return _taskStartDate; }
            set { _taskStartDate = value; }
        }        

        public DateTime TaskEndDate
        {
            get { return _taskEndDate; }
            set { _taskEndDate = value; }
        }        

        public double HoursAllocated
        {
            get { return _hoursAllocated; }
            set { _hoursAllocated = value; }
        }        

        public double DollarsPerHour
        {
            get { return _dollarsPerHour; }
            set { _dollarsPerHour = value; }
        }

        //each task will have a different pay rate
        public double AmountBilledToClient()
        {
            return HoursAllocated * DollarsPerHour;
        }

        public Task(int taskId, string taskName, DateTime taskStartDate, DateTime taskEndDate, double hoursAllocated, double dollarsPerHour)
        {
            TaskId = taskId;
            TaskName = taskName;
            TaskStartDate = taskStartDate;
            TaskEndDate = taskEndDate;
            HoursAllocated = hoursAllocated;
            DollarsPerHour = dollarsPerHour;
        }
    }
}
