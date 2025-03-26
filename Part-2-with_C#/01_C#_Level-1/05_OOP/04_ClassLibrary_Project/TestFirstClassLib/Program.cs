using System;
using FirstClassLib;

    class Program
    {
        static void Main(string[] args)
        {
        clsMyMath M1 = new clsMyMath();
        Console.WriteLine($"The Result Of 1 + 1 is: {M1.Sum(1, 1)}");

        Console.ReadKey();
        }
    }

