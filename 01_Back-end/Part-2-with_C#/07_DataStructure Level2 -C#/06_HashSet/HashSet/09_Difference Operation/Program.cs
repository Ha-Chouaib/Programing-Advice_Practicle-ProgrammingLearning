using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_Difference_Operation
{
    internal class Program
    {
        static void Main(string[] args)
        {

            HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
            HashSet<int> set2 = new HashSet<int> { 3, 4, 5 };

            set1.ExceptWith(set2);// will Remove The Common Items Between 2 Sets From The Set1

            foreach (int i in set1)
            {
                Console.WriteLine(i);
            }
        }
    }
}
