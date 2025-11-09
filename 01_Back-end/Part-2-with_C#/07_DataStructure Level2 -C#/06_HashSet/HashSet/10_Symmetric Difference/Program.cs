using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Symmetric_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {

            HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
            HashSet<int> set2 = new HashSet<int> { 3, 4, 5 };

            set1.SymmetricExceptWith(set2);// Like UnionWith But + ExceptWith => Merge tow Sets And Remove The common Items from set1

            foreach (int i in set1)
            {
                Console.WriteLine(i);
            }
        }
    }
}
