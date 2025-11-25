using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_18_FirstNon_RepeatingCharacter
{
    internal class Program
    {
        static Queue<char>DetectRepeatedCharacter(string input)
        {
            Queue<char> result = new Queue<char>();
            for (int i = 0; i < input.Length; i++)
            {
                if(result.Count == 0)
                {
                    result.Enqueue(input[i]);
                    continue;
                }
 
                if (input[i] != result.Last())
                    result.Enqueue(input[i]);
                else result.Enqueue('-');

            }
            return result;
        }
        static void Main(string[] args)
        {
            string input = "aabcdd";
            Console.WriteLine($"Original string:[{input}] || with First Non-Repeating Character in a Stream: [{string.Join(", ",DetectRepeatedCharacter(input))}]");
        }
    }
}
