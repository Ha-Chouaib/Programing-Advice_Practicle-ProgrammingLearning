using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_SetEquals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
            HashSet<int> set2 = new HashSet<int> { 1, 2, 3 };
            HashSet<int> set3 = new HashSet<int> { 3, 4, 5 };
            Console.WriteLine($"set1 = set2: [ {set1.SetEquals(set2)} ]");
            Console.WriteLine($"set1 = set3: [ {set1.SetEquals(set3)} ]");
        }
    }
}
