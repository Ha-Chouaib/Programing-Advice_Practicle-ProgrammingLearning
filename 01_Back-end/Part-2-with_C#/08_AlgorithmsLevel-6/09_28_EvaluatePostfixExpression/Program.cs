using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _09_28_EvaluatePostfixExpression
{
    internal class Program
    {   
       
        static int GetPostFixValue(string input)
        {
            Stack<int> stack = new Stack<int>();

            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    stack.Push(c - '0');
                }
                else
                {


                    int value2 = stack.Pop();
                    int value1 = stack.Pop();

                    switch (c)
                    {
                        case '+':
                            stack.Push((value1 + value2));
                            break;
                        case '-':
                            stack.Push((value1 - value2));
                            break;
                        case '*':
                            stack.Push((value1 * value2));
                            break;
                        case '/':
                            stack.Push((value1 / value2));
                            break;

                    }
                }
            }
            //foreach (char c in expression)
            //{
            //    if (char.IsDigit(c))
            //    {
            //        stack.Push(c - '0');
            //    }
            //    else
            //    {
            //        int b = stack.Pop();
            //        int a = stack.Pop();
            //        switch (c)
            //        {
            //            case '+': stack.Push(a + b); break;
            //            case '-': stack.Push(a - b); break;
            //            case '*': stack.Push(a * b); break;
            //            case '/': stack.Push(a / b); break;
            //        }
            //    }
            //}

            return stack.Pop();
        }
        static void Main(string[] args)
        {
            string input = "231*+9-";
            Console.WriteLine($"input: {input}");
            Console.WriteLine($"Postfix result: {GetPostFixValue(input)}");
        }
    }
}
