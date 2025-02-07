using System;

namespace Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //.............................ReadLine()..........................
            //ReadLine() Method Allways Reads String Values Equivalent to getline() in C++

            Console.WriteLine("Please Enter Full Name?");
            string? FullName = Console.ReadLine();
            Console.WriteLine($"\nFullName: {FullName}");
            // To Read The other Data Type Values You Should Convert The Str VAlue To The Target Data Type

            Console.WriteLine("Please Enter your Age?");
            int Age=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Age: {Age}");


        }
    }
}