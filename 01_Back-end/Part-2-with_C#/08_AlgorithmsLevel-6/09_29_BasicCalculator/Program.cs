using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_29_BasicCalculator
{
    internal class Program
    {
        //[problem]
        /*
            
            Problem: Evaluate a mathematical expression containing +, -, (, ) without * or /.
            
            Example:
            Input: "1 + (2 - 3)"
            Output: 0
         */
       
        static int calculate(string s)
        {
            Stack<int> stack = new Stack<int>();
            int result = 0, sign = 1, number = 0;


            foreach (char c in s)
            {
                if (char.IsDigit(c))
                {
                    number = number * 10 + (c - '0');
                }
                else if (c == '+')
                {
                    result += sign * number;
                    number = 0;
                    sign = 1;
                }
                else if (c == '-')
                {
                    result += sign * number;
                    number = 0;
                    sign = -1;
                }
                else if (c == '(')
                {
                    stack.Push(result);
                    stack.Push(sign);
                    result = 0;
                    sign = 1;
                }
                else if (c == ')')
                {
                    result += sign * number;
                    number = 0;
                    result *= stack.Pop();
                    result += stack.Pop();
                }
            }

            result += sign * number;
            return result;
        }
        static void Main(string[] args)
        {
            string input = "1 - (2+(1+2))";
            int result = calculate(input);
            Console.WriteLine("input: " + input);
            Console.WriteLine("Result: " + result);
            Console.ReadLine();
        }
    }
}
