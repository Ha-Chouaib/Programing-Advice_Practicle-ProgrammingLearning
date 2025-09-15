using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_IntersectWith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //[1]Find common numbers between two sets of integers.
            HashSet<int> set1 = new HashSet<int> { 1, 2, 3, 4, 5 };
            HashSet<int> set2 = new HashSet<int> { 4, 5, 6, 7 };

            Console.WriteLine($"[1] The Common Numbers Between set1:[{string.Join(" , ", set1)}] And set2:[{string.Join(" , ", set2)}] ");
            set1.IntersectWith(set2);
            Console.WriteLine($"=> {string.Join(" , ", set1)}");

            //[2]Find common hobbies between two people (HashSet<string>).
            HashSet<string> hobbiesPerson1 = new HashSet<string>
                            {
                                "Reading",
                                "Swimming",
                                "Gaming",
                                "Traveling",
                                "Cooking"
                            };
                            
            HashSet<string> hobbiesPerson2 = new HashSet<string>
                            {
                                "Photography",
                                "Gaming",
                                "Cooking",
                                "Hiking",
                                "Traveling"
                            };
            Console.WriteLine($"\n[2] The Common Hobbies Between Person1:[{string.Join(" , ", hobbiesPerson1)}] And Person2:[{string.Join(" , ", hobbiesPerson2)}] ");
            hobbiesPerson1.IntersectWith(hobbiesPerson2);
            Console.WriteLine($"=> {string.Join(" , ", hobbiesPerson1)}");

            //[3]Find common letters between two words by turning them into sets of chars.
            HashSet<char> L1 = new HashSet<char>("Swimming");
            HashSet<char> L2 = new HashSet<char>("Gaming");

            Console.WriteLine($"\n[3]The Intersection Between [Swimming] And [Gaming]");
            L1.IntersectWith(L2);
            Console.WriteLine($"=> {string.Join(" , ", L1)}");





        }


    }
}
