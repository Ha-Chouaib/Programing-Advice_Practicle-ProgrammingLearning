using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_SortingList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <int> Numbers = new List<int> { -2,-3,0,11,24,39,99,-40,34,33};

            Numbers.Sort();
            Console.WriteLine($"Default sorting [Ascending]->: {string.Join(" ## ",Numbers)}");

            Numbers.Reverse();
            Console.WriteLine($"[Descending Order]->: {string.Join(" ## ", Numbers)}");

           
            Console.WriteLine($"\nLINQ sorting [Ascending]->: {string.Join(" ## ", Numbers.OrderBy(n => n))}");
            Console.WriteLine($"LING sorting [Descending]->: {string.Join(" ## ", Numbers.OrderByDescending(n => n))}");
        }
    }
}
