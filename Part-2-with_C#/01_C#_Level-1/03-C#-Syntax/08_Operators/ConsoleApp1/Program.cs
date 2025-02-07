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
                [&=]-------------(Bitwise AND Assignemet)
                [|=]-------------(Bitwise OR Assignemet)

                [^=]-------------(Bitwise XOR Assignemet) 
                    int a= 5; // 5 in Binary is 0101
                    a ^= 3; // 3 in Binary is 0011
                    //XOR Operation: 0101 ^ 0011 = 0110 (6 in decimal)
                    Console.WriteLine(a) // Output-> 6 
                        .......................

                [<<=]-------------(Left Shift Assignemet)
                    int a= 5; // in Binary 5= 0000 0101
                    a <<= 2; // Sheft Left By Tow Bites: 0001 0100 (20 in decimal)
                    Console.WriteLine(a) // Output-> 20 
                        .......................

                [>>=]-------------(rigth Shift Assignemet)
                    int a= 20; // in Binary 20= 0001 0100
                    a <<= 2; // Sheft rigth By Tow Bites: 0000 0101 (5 in decimal)
                    Console.WriteLine(a) // Output-> 5 
                        .......................

                [=>]-------------(Lambda operator)
                    Func<int, int> square = x=> x*x;
                    Console.WriteLine(Square(4)) //Output--> 16
                
            */
            /*
                ======================================Arithmetic Operators======================
                [+]-------------(Addition Operator)
                [-]-------------(SubStraction Operator)
                [*]-------------(Multiplication Operator)
                [/]-------------(Division Operator)
                [%]-------------(Modulo Operator)
            */

            /*
                ====================================Relational Operators=========================
                [==]-----(Equal To)
                [>]------(Greater Than)
                [<]------(Less Than)
                [>=]-----(Greater Than Or Equal To)
                [<=]-----(Less Than Or Equal To)
                [!=]-----(Not Equal)
            */
            /*
                ====================================Logical Operators===========================
                [&&]--->(AND)
                [||]--->(OR)
                [!]---->(NOT)
            */
            /*
                ===================================Unary Operators==============================
                [+]--->(Unary Plus)
                [-]--->(Unary Minus)
                [++]-->(Increment)
                [--]-->(Decrement)

            */
            /*
                ===================================Ternary Operator=============================
                [? :]
                Variable=Condition ? Exp1 : Exp2 ;
                if True: the result of Expretion1 Assigned to The Varieble
                if False: result of Expretion2 Assigned to the Variable
            */

            /*
                ===================================Bitwise and Bit Shift Operator===============
                [&]--->(Bitwise AND)
                [|]--->(Bitwise OR)
                [^]--->(Bitwise XOR= Exclusive OR)
                [<<]--->(Bitwise Left Shift)
                [>>]--->(Bitwise Rigth Shift)
                [~]--->(Bitwise complement)

            */
        }
    }
}