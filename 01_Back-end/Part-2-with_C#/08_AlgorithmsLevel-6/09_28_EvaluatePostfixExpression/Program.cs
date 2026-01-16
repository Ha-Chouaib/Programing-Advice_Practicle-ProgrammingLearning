using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_28_EvaluatePostfixExpression
{
    internal class Program
    {   
        static bool isDigit(char c)
        {
            return c >= '0' && c <= '9';
        }
        static int PostFixValue(string input)
        {
            Stack<int> stack = new Stack<int>();
            int resutl = 0;
            foreach (char c in input)
            {
                if (isDigit(c)) stack.Push(c);
                if (stack.Count > 0)
                {
                    switch(c)
                    {
                        case '+':
                            resutl = stack.Pop();
                            stack.Push(resutl + resutl);
                            break;
                        case '-':
                            resutl = stack.Pop();
                            break;
                        case '*':
                            resutl = stack.Pop();
                            break;
                        case '/':
                            resutl = stack.Pop();
                            break;

                    }
                }

            }
            return resutl;
        }
        static void Main(string[] args)
        {
        }
    }
}
