﻿using System;
namespace Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            # Generate Random Number in Min to Max Range
            # Use the Next(int min, int max) overload method
                to get a random integer that is within a specified range.
            */
            Random rnd = new Random();

            for(int j = 0; j < 4; j++)
            {
                Console.WriteLine(rnd.Next(10, 20)); // returns random integers >= 10 and < 20
            }
        }

    }
}