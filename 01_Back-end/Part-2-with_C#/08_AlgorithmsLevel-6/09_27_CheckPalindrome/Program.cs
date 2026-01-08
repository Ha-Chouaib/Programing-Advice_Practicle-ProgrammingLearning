using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_27_CheckPalindrome
{
    internal class Program
    {
        static bool IsPalindrome(string input)
        {
            Stack<char> stack = new Stack<char>(input);
            foreach (char c in input)
            {
                if(c != stack.Pop()) return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            string Palindrom = "madam";
            string NonPalindrom = "Hello";

            Console.WriteLine($"[{Palindrom}] is palindrom: ( {IsPalindrome(Palindrom)} )");
            Console.WriteLine($"[{NonPalindrom}] is palindrom: ( {IsPalindrome(NonPalindrom)} )");
        }
    }
}
