using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamda_Exepression
{
    internal class Program
    {

        static Func<int, int> Square = x => x * x;
        static Action ParameterLessAction = () =>
        {
            Console.WriteLine($"ParameterLess Action Using Lamda Ex");

        };

        static Predicate<int> CheckNum_IsEven = (num) => (num % 2 == 0);

        static Action <int, bool> ActionWithParam = (Num, IsEven) =>
        {
            Console.WriteLine($"Is The Number {Num} Even? {IsEven}");

        };

        static void ExecuteOperation(int num1, int num2, Func <int,int,int>operation)
        {
            Console.WriteLine($"The Operation Result is: [ {operation(num1, num2)} ]");
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"Square of 5 is: {Square(5)}");

            ParameterLessAction();
            ActionWithParam(8, CheckNum_IsEven(8));

            Func<int, int, int> Add = (num1, num2) => num1 + num2;
            Func<int, int, int> Sub = (num1, num2) => num1 - num2;

            Console.WriteLine($"Add Operation:");
            ExecuteOperation(20, 30, Add);

            Console.WriteLine($"Substruct Operation:");
            ExecuteOperation(20, 30, Sub);
        }
    }
}
