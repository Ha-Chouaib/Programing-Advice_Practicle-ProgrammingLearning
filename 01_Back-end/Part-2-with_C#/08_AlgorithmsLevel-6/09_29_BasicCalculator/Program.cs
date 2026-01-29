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
            List<char> parentheses = new List<char> { '(',')'};
            List<char> Operators = new List<char> { '+','-'};

            Stack<int> numbers = new Stack<int>();
            Queue<int> PriorityNumbers = new Queue<int>();
            Stack<char> operations = new Stack<char>();
            int i = 0;
            bool HasPriority = false;
            char value;
            char op = new char();
            
            while (i < input.Length)
            {
                value = input[i];
                if (char.IsDigit(value) && !HasPriority)
                {
                    numbers.Push(value - '0');
                    i++;
                }
                if (parentheses.Contains(value) || (char.IsDigit(value) && HasPriority) || (Operators.Contains(value) && HasPriority))
                {
                    if (value == '(') HasPriority = true;                  
                    if (value == ')') HasPriority = false;
                    
                    if (HasPriority )
                    {
                        if (char.IsDigit(value))
                        {
                            PriorityNumbers.Enqueue(value - '0');
                            i++;
                        }
                        else if (Operators.Contains(value))
                        {
                            op = value;
                            i++;
                        }
                        if(PriorityNumbers.Count == 2)
                        {
                            int a = PriorityNumbers.Dequeue();
                            int b = PriorityNumbers.Dequeue();
                            int result = DoCalc(a, b, op);
                            PriorityNumbers.Enqueue(result);
                        }
                    }
                    else
                    {
                        HasPriority = false;
                        numbers.Push(PriorityNumbers.Dequeue());
                    }
                }


                if (!HasPriority)
                {
                    if (Operators.Contains(value))
                    {
                        op = value;
                        i++;
                    }
                    if(numbers.Count == 2)


                }
                
            }
            return numbers.Pop();

        }
        static void Main(string[] args)
        {
        }
    }
}
