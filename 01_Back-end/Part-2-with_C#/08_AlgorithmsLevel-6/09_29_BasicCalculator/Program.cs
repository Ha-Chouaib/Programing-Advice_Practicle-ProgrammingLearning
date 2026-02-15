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
                
                if (parentheses.Contains(value) || (char.IsDigit(value) && HasPriority) || (Operators.Contains(value) && HasPriority))
                {
                    if (value == '(') HasPriority = true;                  
                    if (value == ')') HasPriority = false;
                    
                    if (HasPriority )
                    {
                        if (char.IsDigit(value))
                        {
                            int b = value - '0';
                            int a = 0;
                            if (numbers.Count > 0)
                            {
                                a = numbers.Pop();
                            }
                            int result = DoCalc(a, b, op);
                            numbers.Push(result);
                        }
                        if (Operators.Contains(value))
                        {
                            op = value;
                        }
                       
                    }
                    i++;

                }


                if (!HasPriority)
                {
                    if (Operators.Contains(value))
                    {
                        op = value;
                        i++;
                    }
                    if (char.IsDigit(value))
                    {
                        int b = value - '0';
                        int a = 0;
                        if (numbers.Count > 0)
                        {
                            a = numbers.Pop();
                        }
                        
                        int result = DoCalc(a, b, op);
                        numbers.Push(result);
                        i++;
                    }


                }
                
            }
            return numbers.Pop();

        }
        static void Main(string[] args)
        {
            string input = "1+(1+2)";
            int result = Calculate(input);
            Console.WriteLine("input: " + input);
            Console.WriteLine("Result: " + result);
            Console.ReadLine();
        }
    }
}
