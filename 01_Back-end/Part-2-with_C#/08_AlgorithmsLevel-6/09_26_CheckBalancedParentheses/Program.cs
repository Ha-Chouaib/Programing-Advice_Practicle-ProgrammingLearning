using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace _09_26_CheckBalancedParentheses
{
    internal class Program
    {
        static bool IsParenthesesBalanced(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;

            Stack<char> stack = new Stack<char>();


            foreach (char c in input)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c); 
                }
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (stack.Count == 0)
                        return false; 


                    char top = stack.Pop();


                    if ((c == ')' && top != '(') ||
                        (c == '}' && top != '{') ||
                        (c == ']' && top != '['))
                    {
                        return false; 
                    }
                }
            }


            return stack.Count == 0;
        }
        static void Main(string[] args)
        {
            string input1 = "({[ valid]})";
            string input2 = "({[ none valid)]}";

            Console.WriteLine($"[{input1}] Is Valid Parentheses: {IsParenthesesBalanced(input1)}");
            Console.WriteLine($"[{input2}] Is Valid Parentheses: {IsParenthesesBalanced(input2)}");
        }
    }
}
