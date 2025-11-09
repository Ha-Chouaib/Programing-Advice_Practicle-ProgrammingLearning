using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_RemoveElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> Numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine($"\nList Items: {string.Join("||", Numbers)}");

            //Remove Item By Value
            Numbers.Remove(3);
            Console.WriteLine($"\nAfter Removing [3]->(By Value): {string.Join("||",Numbers)}");

            //Remove Item By Index
            Numbers.RemoveAt(5);
            Console.WriteLine($"\nAfter Removing the Item In Index[5]: {string.Join("||", Numbers)}");

            //Remove Items By Condition
            Numbers.RemoveAll(n=> n <= 5);
            Console.WriteLine($"\nAfter Removing All Items With Condition [n <= 5]): {string.Join("||", Numbers)}");

            // Clear The Whole List
            Numbers.Clear();
            Console.WriteLine($"\nAfter Clearing the list [ List Count: { Numbers.Count}]");
        }
    }
}
