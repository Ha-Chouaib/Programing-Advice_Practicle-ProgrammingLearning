using System;


namespace Main
    {
        internal class Program
        {

        static void PrintMyName()
        {
            Console.WriteLine("Chouaib Hadadi");
        }
        static string GetMyName()
        {
            return "Karim-Hilmi";

        }
        static void PrintMyInfo(string Name="Chouaib",byte Age=22)
        {
            Console.WriteLine("Name= {0} , Age= {1}",Name,Age);
        }
        static void MyMethod(string child1, string child2, string child3)
        {
            Console.WriteLine("The youngest child is: " + child3);
        }

        static int Sum(int Num1, int Num2)

        {
            return Num1+Num2;
        }

        static int Sum(int Num1, int Num2,int Num3)

        {
            return Num1 + Num2+ Num3;
        }
        static int Sum(int Num1, int Num2, int Num3,int Num4)

        {
            return Num1 + Num2 + Num3+Num4;
        }
        static void Main(string[] args)
            {

            PrintMyName();
            PrintMyInfo(GetMyName(),45);
            MyMethod(child3: "Omar", child1: "Saqer", child2: "Hamza");
            Console.WriteLine(Sum(10, 20));
            Console.WriteLine(Sum(10, 20,30));
            Console.WriteLine(Sum(10, 20, 30,40));
            
            }
        }
    }
