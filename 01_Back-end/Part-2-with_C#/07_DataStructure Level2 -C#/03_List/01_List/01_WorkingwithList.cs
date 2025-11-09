using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> Numbers = new List<int>(); 

            Numbers.Add(1);
            Numbers.Add(2);
            Numbers.Add(3);
            Numbers.Add(4);
            Numbers.Add(5);

            Console.WriteLine($"Number Of List Items: {Numbers.Count}");

            Console.WriteLine($"Item 1: {Numbers[0]}");
            Console.WriteLine($"Item 2: {Numbers[1]}");
            Console.WriteLine($"Item 3: {Numbers[2]}");
            Console.WriteLine($"Item 4: {Numbers[3]}");
            Console.WriteLine($"Item 5: {Numbers[4]}");

            Numbers[1] = 300;
            Console.WriteLine("Changing Item 2's Value:" + Numbers[1]);

            

        }
    }
}
