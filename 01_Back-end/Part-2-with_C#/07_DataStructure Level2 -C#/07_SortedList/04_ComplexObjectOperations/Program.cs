using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_ComplexObjectOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            SortedList<int, Employee> employees = new SortedList<int, Employee>()
            {
                { 1, new Employee("Alice", "HR", 50000) },
                { 2, new Employee("Bob", "IT", 70000) },
                { 3, new Employee("Charlie", "HR", 52000) },
                { 4, new Employee("Daisy", "IT", 80000) },
                { 5, new Employee("Ethan", "Marketing", 45000) }
            };

            var Query= employees.Where(e => e.Value.Department == "IT").OrderByDescending(e => e.Value.Salary).Select(e => e.Value.Name);

            Console.WriteLine("IT Departement Employees Sorted By Salary (descending):");
            foreach (var name in Query) Console.WriteLine(name);
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }


        public Employee(string name, string department, decimal salary)
        {
            Name = name;
            Department = department;
            Salary = salary;
        }
    }
}
