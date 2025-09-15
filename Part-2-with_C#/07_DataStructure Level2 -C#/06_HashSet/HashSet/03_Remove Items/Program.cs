using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Remove_Items
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> fruits = new HashSet<string> { "Apple", "Banana", "Cherry" };

            Console.WriteLine($"HashSet Item Conut= {fruits.Count}");
            foreach (string fruit in fruits)
            {
                Console.WriteLine(fruit);
            }

            fruits.Remove("Apple");
            Console.WriteLine($"\nHashSet Item Conut After Removing Apple= {fruits.Count}");

            foreach (string fruit in fruits)
            {
                Console.WriteLine(fruit);
            }

            fruits.Clear();
            Console.WriteLine($"\nHashSet Item Conut After Clearing The Whole Set= {fruits.Count}");

        }
    }
}
