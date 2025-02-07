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
            string FullName = Console.ReadLine();
            Console.WriteLine($"\nFullName: {FullName}");
            
        }
    }
}