using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Checking_for_Existence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> fruits = new HashSet<string> { "Apple","Banana","Cherry"};

            if (fruits.Contains("Banana"))
                Console.WriteLine("The HashSet Contains Banana");
            else
                Console.WriteLine("Does not Conatain The Banana");

            if (fruits.Contains("Orange"))
                Console.WriteLine("The HashSet Contains Orange");
            else
                Console.WriteLine("Does not Conatain The Orange");
        }
    }
}
