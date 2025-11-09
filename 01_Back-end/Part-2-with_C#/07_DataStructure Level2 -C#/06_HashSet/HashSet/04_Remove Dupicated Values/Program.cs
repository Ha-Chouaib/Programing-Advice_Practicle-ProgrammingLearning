using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Remove_Dupicated_Values
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3 ,4,4,4,3,4,5};

            HashSet<int> ToUniqueNums = new HashSet<int>(arr);
            foreach (int i in ToUniqueNums)
            {
                Console.WriteLine(i);
            }
        }
    }
}
