using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_SetEquals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //[1]Check if two sets of integers {1, 2, 3} and {3, 2, 1} are equal.
            
            var eqSet1 = new HashSet<int> { 1, 2, 3 };
            var eqSet2 = new HashSet<int> { 3, 2, 1 };

            if (eqSet1.SetEquals(eqSet2))
                Console.WriteLine("\nYes eqSet1 == eqSet2 ");
            else
                Console.WriteLine("\nNo eqSet1 != eqSet2 ");





            // [2]Check if two sets of names (with duplicates in the source lists) are equal after converting them to HashSet.
            var eqNames1 = new HashSet<string>(new List<string> { "Ali", "Sara", "Omar", "Sara" });
            var eqNames2 = new HashSet<string>(new List<string> { "Omar", "Sara", "Ali" });


            if (eqNames1.SetEquals(eqNames2))
                Console.WriteLine("\nYes eqNames1 == eqNames2 ");
            else
                Console.WriteLine("\nNo eqNames1 != eqNames2 ");


        }
    }
}
