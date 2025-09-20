using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Tuples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declare a Tuple
            (int ID, string, double) person = (1, "Chouaib", 8.2);

            Console.WriteLine($"ID: {person.ID}");
            Console.WriteLine($"name: {person.Item2}");
            Console.WriteLine($"Height: {person.Item3}");


            Console.WriteLine($"Number: {GetMultiValues().Item1}");
            Console.WriteLine($"Text: {GetMultiValues().Item2}");


        }

        static (int,string) GetMultiValues()
        {
            return (10, "Ten");
        }
    }
}
