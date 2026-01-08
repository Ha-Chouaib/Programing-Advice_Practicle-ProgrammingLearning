using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_25_ReversString
{
    internal class Program
    {
        static  string StringConverter(string input)
        {
            Stack<char> stack = new Stack<char>(input);
            string revertedSRT = string.Empty;
            while (stack.Count > 0)
            { 
                revertedSRT += stack.Pop();
            }
            return revertedSRT;
        }
        static void Main(string[] args)
        {
            string input = "Hello";
            string output = StringConverter(input);
            Console.WriteLine("original value:"+input);
            Console.WriteLine("reversed value:"+output);
        }
    }
}
