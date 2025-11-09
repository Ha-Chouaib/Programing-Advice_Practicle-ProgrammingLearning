using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_JaggedArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] jaggedArray = new int[3][];

            jaggedArray[0] = new int[] {1,2,3,4,5,9,6};
            jaggedArray[1] = new int[] { 1, 2, 3, 4 };
            jaggedArray[2] = new int[] { 0, 32, 100 };


            for(int i = 0; i < jaggedArray.Length; i++)
            {
                for(int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
