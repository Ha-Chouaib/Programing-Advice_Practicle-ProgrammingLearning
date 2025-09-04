using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_ConvertListToArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <int> numbers = new List <int> { 1,2,3,4,5,6};

            //converting the List To Array
            int[] numbers_Array = numbers.ToArray();

            Console.WriteLine($"Array Elements: {string.Join(",", numbers_Array)}");

            //Convert The Array To List
            int[] newNumbers_Array = { 1,2,3,47,99,3,393};


            List<int> Numbers_List = new List<int>(newNumbers_Array);
            Console.WriteLine($"List Elements: {string.Join(",", Numbers_List)}");

        }
    }
}
