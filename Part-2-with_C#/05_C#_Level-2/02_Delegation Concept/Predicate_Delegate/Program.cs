using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predicate_Delegate
{
    internal class Program
    {
        //Takes On Parameter and Return a Boolean Value
        static Predicate<int> CheckNum = IsEven;
        static bool IsEven(int Num)
        {
            return (Num % 2) == 0;
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"Is 5 Even Number? {CheckNum(5)}");
        }
    }
}
