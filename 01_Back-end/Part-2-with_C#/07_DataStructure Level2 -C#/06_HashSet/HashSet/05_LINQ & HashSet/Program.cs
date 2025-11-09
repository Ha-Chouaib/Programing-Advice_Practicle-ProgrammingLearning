using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_LINQ___HashSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating and populating a HashSet of integers
            HashSet<int> numbers = new HashSet<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };


            // Using LINQ to filter out even numbers
            var evenNumbers = numbers.Where(n => n % 2 == 0);


            // Displaying the even numbers
            Console.WriteLine("Even Numbers:");
            foreach (var number in evenNumbers)
            {
                Console.WriteLine(number);
            }


            // Using LINQ to find numbers greater than 5
            var numbersGreaterThanFive = numbers.Where(n => n > 5);


            // Displaying the numbers greater than 5
            Console.WriteLine("\nNumbers Greater Than 5:");
            foreach (var number in numbersGreaterThanFive)
            {
                Console.WriteLine(number);
            }
            Console.ReadKey();

        }
    }
}
