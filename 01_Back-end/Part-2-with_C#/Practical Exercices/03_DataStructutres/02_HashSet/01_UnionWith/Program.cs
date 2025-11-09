using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_UnionWith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //[1] Create two sets of integers, find the union (all unique numbers).

            HashSet<int> set1 = new HashSet<int> { 1,2,3,4,5};
            HashSet<int> set2 = new HashSet<int> { 4,5,6,7};

            Console.WriteLine($"[1] Union set1:[{string.Join(" , ",set1) }] With set2:[{string.Join(" , ", set2)}] ");
            set1.UnionWith(set2);
            Console.WriteLine($"=> {string.Join(", ",set1) }");

            //[2]Union two sets of names (students from Class A and Class B).
            HashSet<string> classA = new HashSet<string>
                        {
                            "Ali",
                            "Sara",
                            "Omar",
                            "Lina",
                            "Adam"
                        };
                        
             HashSet<string> classB = new HashSet<string>
                        {
                            "Khalid",
                            "Mona",
                            "Sara",
                            "Adam",
                            "Hana"
                        };

            Console.WriteLine($"\n[2] Union Students Names from ClassA:[{string.Join(" , ", classA)}] And ClassB:[{string.Join(" , ", classB)}] ");
            classA.UnionWith(classB);
            Console.WriteLine($"=> {string.Join(", ", classA)}");

            //[3]Union sets of tags ("C#", "Java", "Python") with another set of tags ("JavaScript", "Python", "C++").
            HashSet<string> Tag1 = new HashSet<string> { "C#", "Java", "Python" };
            HashSet<string> Tag2 = new HashSet<string> { "JavaScript", "Python", "C++" };

            Console.WriteLine($"\n[3] Union Tag1:[{string.Join(" , ", Tag1)}] With Tg2:[{string.Join(" , ", Tag2)}] ");
            Tag1.UnionWith(Tag2);
            Console.WriteLine($"=> {string.Join(", ", Tag1)}");

            
        }
    }
}
