using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_LINQ_FeltringData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> Numbers = new List<int> { 1,2,3,4,5,6,7,8,9,10};

            Console.WriteLine($"Even Numbers: {string.Join(" -//- ", Numbers.Where(n => n % 2 == 0))}");
            Console.WriteLine($"Odd Numbers: {string.Join(" -//- ", Numbers.Where(n=> n % 2 != 0))}");
            Console.WriteLine($"Numbers Greate Than 5: {string.Join(" -//- ", Numbers.Where(n => n > 5))}");
            Console.WriteLine($"Evry Second Number: {string.Join(" -//- ", Numbers.Where((n,index) => index % 2 == 1 ))}");
            Console.WriteLine($"Between 3 and 8 : {string.Join(" -//- ", Numbers.Where(n=> (n > 3) && (n < 8)))}");

        }
    }
}
