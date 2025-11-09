using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ExceptWith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //[1]From a set of all fruits, remove fruits that are in a “favorites” set.
            HashSet<string> allFruits = new HashSet<string>
                            {
                                "Apple",
                                "Banana",
                                "Orange",
                                "Mango",
                                "Grapes",
                                "Strawberry",
                                "Pineapple",
                                "Watermelon"
                            };
                            
           HashSet<string> favoriteFruits = new HashSet<string>
                            {
                                "Mango",
                                "Strawberry",
                                "Banana"
                            };
            Console.WriteLine($"[1] All Fruits :[{string.Join(" , ", allFruits)}] || Favprite Fruits:[{string.Join(" , ", favoriteFruits)}] ");
            allFruits.ExceptWith(favoriteFruits);
            Console.WriteLine($"=> Removed The Favorite Fruits From The AllFruits Set: {string.Join(" | ", allFruits)}");


            //[2]From a set of numbers 1–10, remove numbers that are in another set {2, 4, 6, 8}.
            HashSet<int> set1 = new HashSet<int> { 1, 2, 3, 4, 5,7,8,9,10 };
            HashSet<int> set2 = new HashSet<int> { 2, 4, 6, 8 };

            Console.WriteLine($"\n[2] Set1 :[{string.Join(" , ", set1)}] || Set2:[{string.Join(" , ", set2)}] ");
            set1.ExceptWith(set2);
            Console.WriteLine($"=> Removed The set2 Items  From The Set1: {string.Join(" | ", set1)}");

            //[3]From a set of courses taken, exclude the set of courses already passed.

            var coursesTaken = new HashSet<string>
                               {
                                   "Mathematics",
                                   "Physics",
                                   "Chemistry",
                                   "Biology",
                                   "Computer Science",
                                   "History",
                                   "Philosophy"
                               };

            var coursesPassed = new HashSet<string>
                                {
                                    "Mathematics",
                                    "History",
                                    "Biology"
                                };

            Console.WriteLine($"\n[3] courses Taken :[{string.Join(" , ", coursesTaken)}] || courses Passed:[{string.Join(" , ", coursesPassed)}] ");
            coursesTaken.ExceptWith(coursesPassed);
            Console.WriteLine($"=> Exculd The Passed courses From The courses Taken: {string.Join(" | ", coursesTaken)}");




        }
    }
}
