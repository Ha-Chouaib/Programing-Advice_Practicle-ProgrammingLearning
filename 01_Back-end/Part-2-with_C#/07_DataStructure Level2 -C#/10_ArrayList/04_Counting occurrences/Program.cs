using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Counting_occurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrayList = new ArrayList { 1, 2, 3, 2, 4, 2, 5 };

            int targetNumber = 2;

            var count = arrayList.Cast<int>().Count(num => num == targetNumber);

            Console.WriteLine($"Number of occurrences of {targetNumber} in the ArrayList: {count}");
            Console.ReadKey();
        }
    }
}
