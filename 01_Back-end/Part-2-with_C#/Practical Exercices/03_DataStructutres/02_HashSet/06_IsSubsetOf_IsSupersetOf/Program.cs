using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_IsSubsetOf_IsSupersetOf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //[1]Check if {2, 4} is a subset of {2, 4, 6, 8}.
            var subsetSmall = new HashSet<int> { 2, 4 };
            var subsetLarge = new HashSet<int> { 2, 4, 6, 8 };

            if (subsetSmall.IsSubsetOf(subsetLarge))
                Console.WriteLine("\nYes subsetSmall is a Subset of subsetLarge ");
            else
                Console.WriteLine("\nNo subsetSmall Not a subset of subsetLarge ");


            //Check if {1, 2, 3, 4, 5} is a superset of {2, 3}.

            var superSet = new HashSet<int> { 1, 2, 3, 4, 5 };
            var subSet = new HashSet<int> { 2, 3 };
            if (superSet.IsSupersetOf(subSet))
                Console.WriteLine("\nYes superSet is a [SuperSet] of subSet ");
            else
                Console.WriteLine("\nNo superSet Not a [SuperSet] of subSet ");
        }
    }
}
