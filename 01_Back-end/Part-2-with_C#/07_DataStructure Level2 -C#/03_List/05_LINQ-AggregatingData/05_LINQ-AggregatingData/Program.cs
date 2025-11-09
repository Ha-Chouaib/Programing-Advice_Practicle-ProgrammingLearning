using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_LINQ_AggregatingData
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> Numbers = new List<int> { 1,2,3,4,5,6,7,8,9,10};


            //Aggregation Operations
            Console.WriteLine($"Sum: {Numbers.Sum()}");
            Console.WriteLine($"Average: {Numbers.Average()}");
            Console.WriteLine($"Minimum: {Numbers.Min()}");
            Console.WriteLine($"Maximum: {Numbers.Max()}");
            Console.WriteLine($"Count: {Numbers.Count()}");
        }
    }
}
