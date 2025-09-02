using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Looping_Through_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> Numbers = new List<int> { 1, 2, 3, 4, 5 };

            Console.WriteLine($"Number Of List Items: {Numbers.Count}");

            //[1] For Loop
            Console.WriteLine("Displaying list elements Using [ for loop ]");
            for(int i=0; i< Numbers.Count; i++)
            {
                Console.WriteLine(Numbers[i]);
            }

            //[2] foreach
            Console.WriteLine("Displaying list elements Using [ foreach ]");
            foreach (int N in Numbers)
            { 
                Console.WriteLine(N);            
            }

            //[3] List.ForEach
            Console.WriteLine("Displaying list elements Using [ List.ForEach ]");
            Numbers.ForEach(N => Console.WriteLine(N));

        }

    }
}
