using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Overlaps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // [1]Check if two sets of numbers have at least one element in common
            var overlapSet1 = new HashSet<int> { 10, 20, 30 };
            var overlapSet2 = new HashSet<int> { 25, 30, 40 };

            if (overlapSet1.Overlaps(overlapSet2))
                Console.WriteLine("\nYes overlapSet1 is Overlaps the overlapSet2 ");
            else
                Console.WriteLine("\nNo overlapSet1 Overlaps the overlapSet2 ");

            //[2] Check if two sets of programming languages ({"C#", "Python"} and {"Java", "Python"}) overlap
            var langs1 = new HashSet<string> { "C#", "Python" };
            var langs2 = new HashSet<string> { "Java", "Python" };
            if (langs1.Overlaps(langs2))
                Console.WriteLine("\nYes langs1 is Overlaps the langs2 ");
            else
                Console.WriteLine("\nNo langs1 Overlaps the langs2 ");
        }
    }
}
