using System;
namespace Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                =================================Assignement Operators=============================
                [+=]-------------(Addition Assignemet)
                [-=]-------------(SubStraction Assignemet)
                [*=]-------------(Multiplication Assignemet)
                [/=]-------------(Division Assignemet)
                [%=]-------------(Modulo Assignemet)
                [&=]-------------(Bitwize AND Assignemet)
                [|=]-------------(Bitwize OR Assignemet)
                
                [^=]-------------(Bitwize XOR Assignemet) 
                    int a= 5; // 5 in Binary is 0101
                    a ^= 3; // 3 in Binary is 0011
                    //XOR Operation: 0101 ^ 0011 = 0110 (6 in decimal)
                    Console.WriteLine(a) // Output-> 6 
                        .......................

                [<<=]-------------(Left Sheft Assignemet)
                    int a= 5; // in Binary 5= 0000 0101
                    a <<= 2; // Sheft Left By Tow Bites: 0001 0100 (20 in decimal)
                    Console.WriteLine(a) // Output-> 20 
                        .......................

                [>>=]-------------(rigth Sheft Assignemet)
                    int a= 20; // in Binary 20= 0001 0100
                    a <<= 2; // Sheft rigth By Tow Bites: 0000 0101 (5 in decimal)
                    Console.WriteLine(a) // Output-> 5 
                        .......................

                [=>]-------------(Lambda operator)
                    Func<int, int> square = x=> x*x;
                    Console.WriteLine(Square(4)) //Output--> 16
                
            */
        }
    }
}