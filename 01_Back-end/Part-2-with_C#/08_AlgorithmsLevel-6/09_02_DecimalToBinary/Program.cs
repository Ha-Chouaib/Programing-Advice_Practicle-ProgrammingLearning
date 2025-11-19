using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_02_DecimalToBinary
{
    internal class Program
    {
        static string ConvertDecimalToBinary(int value)
        {
            Stack<byte> BinaryResult = new Stack<byte>();
            while(value > 0)
            {
                BinaryResult.Push((byte)(value % 2));

                value /= 2;
            }
            return string.Join("", BinaryResult);
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"Convert The Number [22] To Binary: {ConvertDecimalToBinary(22)}");
        }
    }
}
