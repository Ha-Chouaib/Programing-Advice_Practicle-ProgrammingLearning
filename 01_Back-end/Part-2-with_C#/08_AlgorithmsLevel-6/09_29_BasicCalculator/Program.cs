using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_29_BasicCalculator
{
    internal class Program
    {
        static int DoCalc(int a, int b ,char Operator)
        {
            switch(Operator)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                default:
                    return 0;
            }
        }
        static int Calculate(string input)
        {
            Stack<int> numbers = new Stack<int>();
            Queue<int> PriorityNumbers = new Queue<int>();
            Stack<char> operations = new Stack<char>();
            int i = 0;
            bool HasPriority = false;
            char value;
            while (i < input.Length)
            {
                value = input[i];
                if (char.IsDigit(value) && !HasPriority)
                {
                    numbers.Push(value - '0');
                    i++;
                }
                if (value == '(' || value == ')' || HasPriority)
                {
                    if (value == '(') HasPriority = true;                  
                    if (value == ')') HasPriority = false;
                    
                    if (HasPriority && char.IsDigit(value))
                    {

                        PriorityNumbers.Enqueue( value - '0');
                    }else
                    {
                        numbers.Push();
                        HasPriority = false;

                    }
                }
            }

        }
        static void Main(string[] args)
        {
        }
    }
}
