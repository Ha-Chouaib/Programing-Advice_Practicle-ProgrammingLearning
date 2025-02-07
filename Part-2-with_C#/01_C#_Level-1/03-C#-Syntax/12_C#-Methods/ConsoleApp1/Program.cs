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
        static void Main(string[] args)
            {

            PrintMyName();
            PrintMyInfo(GetMyName(),45);
            MyMethod(child3: "Omar", child1: "Saqer", child2: "Hamza");
            }
        }
    }
