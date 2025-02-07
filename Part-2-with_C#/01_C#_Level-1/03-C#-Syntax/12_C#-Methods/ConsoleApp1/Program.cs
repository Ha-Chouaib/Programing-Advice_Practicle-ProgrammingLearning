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
        static void Main(string[] args)
            {

            PrintMyName();
            PrintMyInfo(GetMyName(),45);

            }
        }
    }
