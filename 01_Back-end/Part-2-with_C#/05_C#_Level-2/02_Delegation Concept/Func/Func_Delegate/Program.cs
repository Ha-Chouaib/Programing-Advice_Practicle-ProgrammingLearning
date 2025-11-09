using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Func_Delegate
{
    internal class Program
    {
        public delegate int Normal_SquareDelegate(int num);

        static Func<int, int> Func_Square = SquareMethod;
        static int SquareMethod(int num)
        {
            return num * num;
        }
        static void Main(string[] args)
        {
            //Normal Way
            Normal_SquareDelegate Normal_Square = new Normal_SquareDelegate(SquareMethod);
            Console.WriteLine($"Using Naormal Delegate | The Squre Of 3 is: {Normal_Square(3)}");

            //Using Func (Delegate shortCat)
            
            Console.WriteLine($"Using Func Delegate | The Squre Of 7 is : {Func_Square(7)}");

        }
    }
}
