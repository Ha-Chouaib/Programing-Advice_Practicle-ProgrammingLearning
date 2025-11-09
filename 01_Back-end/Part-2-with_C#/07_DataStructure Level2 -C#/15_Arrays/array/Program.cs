using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaring an integer array
            int[] numbers = new int[5];
             int[] Num = { 1, 2, 3, 4, 5 };
            // Accessing and modifying elements
            Num[0] = 10;


            // Using for loop for iteration
            for (int i = 0; i < Num.Length; i++)
            {
                Console.WriteLine("Element at index " + i + ": " + Num[i]);
            }
            Console.WriteLine();    

            // Initializing an array with values
            string[] names = { "Alice", "Bob", "Charlie" };


            // Display the names
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
            Console.ReadKey();
        }
    }
}
