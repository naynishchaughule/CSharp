using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics
{
    class GenericEmployeeType
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public Double Salary { get; set; }

        public GenericEmployeeType(Int32 id, String name, Double salary)
        {
            Id = id; Name = name; Salary = salary;
        }

        public override string ToString()
        {
            return String.Format("Generic Id: {0}, Name: {1}, Salary: {2}", Id, Name, Salary);
        }

        public void Incentives<T>(T Id)
        {            
            Console.WriteLine("Incentives of EMP ID: {0} is {1:C}", this.Id, this.Salary * 0.30);         
        }
    }
}
