using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleApp
{
    class Program
    {
        static Project[] pArr = new Project[10];
        static int pCounter = 0;
        static Task[] taskArr = new Task[10];
        static int taskCounter = 0;
        public static List<Employee> EmployeeCollection = new List<Employee>();

        static void Main(string[] args)
        {            
            SoftwareDeveloper sd1 = new SoftwareDeveloper(48090, "naynish", "chaughule");
            EmployeeCollection.Add(sd1);
            SoftwareDeveloper sd2 = new SoftwareDeveloper(48091, "tripti", "panjabi");
            EmployeeCollection.Add(sd2);
            
            //setting up a project
            SetUpProject(110, "dhp", new DateTime(2012, 01, 01), DateTime.Now.Add(new TimeSpan(90, 0, 0, 0)));
            SetUpProject(110, "motorola", new DateTime(2012, 01, 01), DateTime.Now.Add(new TimeSpan(90, 0, 0, 0)));

            //setting up tasks
            SetUpTask(1890, "rent calculation", new DateTime(2012, 02, 07), DateTime.Now.Add(new TimeSpan(90, 0, 0)), 20, 16);            
            SetUpTask(1891, "LR/LD", new DateTime(2012, 03, 07), DateTime.Now.Add(new TimeSpan(90, 0, 0)), 20, 16);
            SetUpTask(1892, "system testing", new DateTime(2012, 03, 07), DateTime.Now.Add(new TimeSpan(90, 0, 0)), 20, 16);

            //adding tasks to the project
            pArr[0].AddTask(taskArr[0]);
            pArr[0].AddTask(taskArr[1]);
            pArr[1].AddTask(taskArr[2]);

            //assigning project to the employee
            sd1.AssignProject(pArr[0]);
            sd2.AssignProject(pArr[1]);
            
            //calculating the total budget for the project
            Console.WriteLine("Total budget of project {0} = {1:C}", pArr[0].PName, pArr[0].ProjectBudget());
            Console.WriteLine("No. of employees in project {0} = {1}", pArr[0].PName, pArr[0].ProjectEmployeeCount());
            Console.WriteLine();
            //list all the tasks of an employee
            Console.WriteLine("All tasks of {0}", sd2.Fname);
            sd2.ListAllMyTasks();
            Console.WriteLine();
            UtilityClass ucObj = new UtilityClass();
            ucObj.SalaryOfEachEmployeeInProject(pArr[1]);

            Console.WriteLine();
            Console.ReadLine();
        }

        public static void SetUpProject(int pID, string pName, DateTime pStartDate, DateTime pEndDate)
        {            
            pArr[pCounter] = new Project(pID, pName, pStartDate, pEndDate);
            pCounter++;
        }

        public static void SetUpTask(int taskId, string taskName, DateTime taskStartDate, DateTime taskEndDate, double hoursAllocated, double dollarsPerHour)
        {
            taskArr[taskCounter] = new Task(taskId, taskName, taskStartDate, taskEndDate,hoursAllocated, dollarsPerHour);
            taskCounter++;
        }
    }
}
