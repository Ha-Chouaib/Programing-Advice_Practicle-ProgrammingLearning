using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_LINQ_with_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Array of numbers
            int[] numbers = { 1, 2, 3, 4, 5 };


            // Using LINQ to filter and transform data
            var evenSquares = numbers.Where(n => n % 2 == 0).Select(n => n * n);


            // Displaying results
            Console.WriteLine("Squares of even numbers:");
            foreach (var num in evenSquares)
            {
                Console.WriteLine(num);
            }
            Console.ReadKey();
        }
    }
}
