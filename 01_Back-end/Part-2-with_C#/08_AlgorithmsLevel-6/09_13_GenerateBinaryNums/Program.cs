using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_13_GenerateBinaryNums
{
    internal class Program
    {
        static string GetBinaryNumber(int number)
        {
            StringBuilder binary = new StringBuilder();
            if (number == 0) return "0";

            while (number > 0)
            { 
                int bit = number % 2;
                binary.Insert(0, bit);
                number /= 2;
            }
            return binary.ToString();
        }
        static Queue<string> GetBinaryNumsFrom1toN(int Num)
        {
            Queue<string> Queue = new Queue<string>();
            for (int i = 1; i <= Num; i++)
            {
                Queue.Enqueue(GetBinaryNumber(i));
            }
            return Queue;
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"The Binary Numbers From 1 to 8: [ {string.Join("| ",GetBinaryNumsFrom1toN(8) )} ]");
        }
    }
}
