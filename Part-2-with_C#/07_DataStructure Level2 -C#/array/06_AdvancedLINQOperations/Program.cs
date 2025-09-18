using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_AdvancedLINQOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Array of people with Name and Age
        var people = new[]
        {
            new { Name = "Alice", Age = 30 },
            new { Name = "Bob", Age = 25 },
            new { Name = "Charlie", Age = 35 },
            new { Name = "Diana", Age = 30 },
            new { Name = "Ethan", Age = 25 }
        };


            // Grouping people by Age, then ordering within each group
            var groupedByAge = people.GroupBy(p => p.Age)
                                     .Select(group => new
                                     {
                                         Age = group.Key,
                                         People = group.OrderBy(p => p.Name)
                                     });


            // Displaying the results
            foreach (var group in groupedByAge)
            {
                Console.WriteLine($"Age Group: {group.Age}");
                foreach (var person in group.People)
                {
                    Console.WriteLine($" - {person.Name}");
                }
            }
            // Array of numbers
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };


            // Filtering to get only even numbers
            var evenNumbers = numbers.Where(n => n % 2 == 0);


            // Aggregating - calculating the sum of even numbers
            int sumOfEvenNumbers = evenNumbers.Sum();


            // Displaying the results
            Console.WriteLine("Even Numbers:");
            foreach (var num in evenNumbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine($"\nSum of Even Numbers: {sumOfEvenNumbers}");

            // Array of employees
            var employees = new[]
            {
            new { Id = 1, Name = "Alice", DepartmentId = 2 },
            new { Id = 2, Name = "Bob", DepartmentId = 1 }
        };


            // Array of departments
            var departments = new[]
            {
            new { Id = 1, Name = "Human Resources" },
            new { Id = 2, Name = "Development" }
        };


            // Joining employees with departments and projecting the result
            var employeeDetails = employees.Join(departments,
                                                 e => e.DepartmentId,
                                                 d => d.Id,
                                                 (e, d) => new { e.Name, Department = d.Name });


            // Displaying the results
            foreach (var detail in employeeDetails)
            {
                Console.WriteLine($"Employee: {detail.Name}, Department: {detail.Department}");
            }

            Console.ReadKey();
        }
    }
}
