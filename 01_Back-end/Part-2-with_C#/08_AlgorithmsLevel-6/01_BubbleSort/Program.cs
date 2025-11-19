using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_BubbleSort
{
    internal class Program
    {
        public static void BubbleSort(int[] arr)
        {
            
            for(int i= 0; i<arr.Length -1; i++)
            {
                for(int j =0; j < arr.Length - i -1; j++) 
                {
                    if (arr[j] > arr[j + 1]) 
                        (arr[j] , arr[j + 1]) = (arr[j +1], arr[j]);

                }
            }
        }
        static void Main(string[] args)
        {
            int[] arr = { 64, 34, 25, 12, 22, 11, 90 };

            Console.WriteLine("Original array:");
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            BubbleSort(arr);

            Console.WriteLine("\nSorted array:");
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.ReadKey();
        }
    }
}
