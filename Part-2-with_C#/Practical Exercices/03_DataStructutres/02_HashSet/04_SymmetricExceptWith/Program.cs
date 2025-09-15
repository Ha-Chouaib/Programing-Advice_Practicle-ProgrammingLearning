using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_SymmetricExceptWith
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //[1]Find elements that are unique to either Set A or Set B (but not both)
            var setA = new HashSet<int> { 1, 2, 3, 4, 5, 6 };
            var setB = new HashSet<int> { 4, 5, 6, 7, 8, 9 };

            Console.WriteLine($"[1] set A :[{string.Join(" , ", setA)}] || set B:[{string.Join(" , ", setB)}] ");
            setA.SymmetricExceptWith(setB);
            Console.WriteLine($"=> Unique numbers in A or B: {string.Join(" | ", setA)}");

            //[2]Compare two sets of employees from two departments and find employees not in common.

            var deptA = new HashSet<string> { "Ali", "Sara", "Omar", "Khalid" };
            var deptB = new HashSet<string> { "Sara", "Khalid", "Mona", "Hana" };

            Console.WriteLine($"\n[2] deptA :[{string.Join(" , ", deptA)}] || dep B:[{string.Join(" , ", deptB)}] ");
            deptA.SymmetricExceptWith(deptB);
            Console.WriteLine($"=>  Not In Common Employees from Dept A & B: {string.Join(" | ", deptA)}");


            //[3]From two sets of numbers, get numbers that are present in one set but not in the other.
            var numSet1 = new HashSet<int> { 100, 200, 300, 400 };
            var numSet2 = new HashSet<int> { 300, 400, 500, 600 };

            Console.WriteLine($"\n[3] numSet1 :[{string.Join(" , ", numSet1)}] || numSet2 :[{string.Join(" , ", numSet2)}] ");
            numSet1.SymmetricExceptWith(numSet2);
            Console.WriteLine($"=>  Not In Common Numbers: {string.Join(" | ", numSet1)}");
        }
    }
}
