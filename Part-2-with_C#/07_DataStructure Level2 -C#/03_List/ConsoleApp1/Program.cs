using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> Numbers = new List<int> { 2, 400, 99, 700, -9, 22, -1, 0, 4 };

            Console.WriteLine($"List Contains [8]: {Numbers.Contains(8)}");

            Console.WriteLine($"List Contains negative numbers: {Numbers.Exists(n => n < 0)}");

            Console.WriteLine($"First negative number: {Numbers.Find(n=> n < 0)}");

            Console.WriteLine($"All negative numbers: {string.Join(",",Numbers.FindAll(n=> n<0))}");

            Console.WriteLine($"Any number Greater than [100]: {Numbers.Any(n=> n>100)}");


            List<string> Words = new List<string> { "apple","banana","cherry","date","chouaib","laptop","mouse"};

            Console.WriteLine($"\n\nList Contains [chouaib]: { Words.Contains("chouaib")}" );

            Console.WriteLine($"List Contains a word of length [6]: { Words.Exists(word => word.Length == 6)}" );

            Console.WriteLine($"Find word longer than [6] chars: { Words.Find(word => word.Length > 6)}" );

            Console.WriteLine($"Find All words longer than [6] chars: {string.Join("," ,Words.FindAll(word => word.Length > 6))}" );

            Console.WriteLine($"Any Word starting with [a]: { Words.Any(word => word.StartsWith("a"))}" );

            Console.WriteLine($"Any Word Ends with [n]: { Words.Any(word => word.EndsWith("n"))}" );


        }
    }
}
