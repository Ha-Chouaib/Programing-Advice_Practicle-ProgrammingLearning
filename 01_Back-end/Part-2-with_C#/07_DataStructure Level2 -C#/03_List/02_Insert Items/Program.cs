using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Insert_Items
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> Numbers = new List<int> { 1,2,3,4,5,6,7,8,9,10};

            Console.WriteLine($"Initial List Items: {string.Join(",",Numbers)}");

            // Insert To The end
            Numbers.Add(11);
            Console.WriteLine($"\nAdd [11] At The End: {string.Join(",",Numbers)}");

            //To Insert An Item To A Specific Position
            Numbers.Insert(0, 0);
            Console.WriteLine($"\nInsert [0] to The beginning: {string.Join(",",Numbers)}");

            //Insert a Block Of Items In A specific Position
            Numbers.InsertRange(5, new List<int> { 50, 90 });
            Console.WriteLine($"\nInsert a block of numbers At Index[5]: {string.Join(",",Numbers)}");
        }
    }
}
