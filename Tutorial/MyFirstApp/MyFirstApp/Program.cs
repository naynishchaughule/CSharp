using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyClassLibrary;
using System.Collections;

namespace MyFirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MyClassLibrary.Math obj = new MyClassLibrary.Math();            
            Console.WriteLine("Sum: {0}, Random: {1}", obj.Add(4, 5), 56);

            Employee.OrgID = 48090;

            Employee emp1 = new Employee(34, 67);
            Employee emp3 = new Employee(90, 67);

            Employee emp2 = new Employee(56, 465);
            Console.WriteLine(emp1);
            Console.WriteLine(emp2);
            Console.WriteLine(emp2);


            Dictionary<int, Employee> myDictionary = new Dictionary<int, Employee>();
            myDictionary.Add(emp1.Id, emp1);
            myDictionary.Add(emp2.Id, emp2);
            myDictionary.Add(emp3.Id, emp3);

            Console.WriteLine("dictionary " + myDictionary[emp3.Id]);

            foreach (KeyValuePair<int, Employee> item in myDictionary)
            {
                Console.WriteLine(item.Key + "    " + item.Value);
            }

            Stack<Employee> myStack = new Stack<Employee>();
            myStack.Push(emp1);            
            myStack.Pop();

            Queue<Employee> myQueue = new Queue<Employee>();
            myQueue.Enqueue(emp1);

            Hashtable ht = new Hashtable();
            ht.Add(emp1.Id, emp1);
            
            Console.ReadLine();
        }
    }    
}
