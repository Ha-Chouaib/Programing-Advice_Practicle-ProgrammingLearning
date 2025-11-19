using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_AlgorithmsLevel_2
{
    internal class Program
    {
        static int LinearSearch(int[] arr, int ItemToFind)
        {
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] == ItemToFind) return i;
            }
            return -1;
        }
        static void Main(string[] args)
        {

            int[]arr = { 1, 2, 3 ,4,5};
            int Item = 3;


            Console.WriteLine("Original Array:");
            foreach (var item in arr)
                Console.Write(item + " ");
            Console.WriteLine();

            int result = LinearSearch(arr, Item);


            if (result == -1)
                Console.WriteLine("Element not found in the array.");
            else
                Console.WriteLine("Element found at index: " + result);


        }
    }
}
