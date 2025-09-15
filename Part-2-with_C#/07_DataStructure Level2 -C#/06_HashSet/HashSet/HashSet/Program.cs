using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> fruits = new HashSet<string>();

            fruits.Add("Apple");
            fruits.Add("Banana");
            fruits.Add("Cherry");

            //Here The HashSet Will be Ignore all Duplicated Items And Keep Just One.
            fruits.Add("Apple");
            fruits.Add("Apple");
            fruits.Add("Apple");

            foreach (string item in fruits)// No Indexing On HashSet Must Use ForEach To Iterate it 
            { 
                Console.WriteLine(item);
            }
        }
    }
}
