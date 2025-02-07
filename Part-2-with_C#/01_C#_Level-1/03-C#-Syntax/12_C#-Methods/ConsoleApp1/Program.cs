using System;


namespace Main
    {
        internal class Program
        {

        static void PrintMyName()
        {
            Console.WriteLine("Chouaib Hadadi");
        }
        static void PrintMyInfo(string Name,byte Age)
        {
            Console.WriteLine("Name= {0} , Age= {1}",Name,Age);
        }
        static void Main(string[] args)
            {

            PrintMyName();
            PrintMyInfo("Karim-Hilmi",45);

            }
        }
    }
