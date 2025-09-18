using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Array_Copying
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Original array
            int[] original = { 1, 2, 3, 4, 5 };


            // Array to hold the copy
            int[] copy = new int[5];


            // Copying array
            Array.Copy(original, copy, original.Length);


            // Displaying the copied array
            Console.WriteLine("Copied Array:");
            foreach (int element in copy)
            {
                Console.WriteLine(element);
            }
            Console.ReadKey();
        }
    }
}
