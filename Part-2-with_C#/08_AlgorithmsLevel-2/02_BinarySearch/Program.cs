using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BinarySearch
{
    internal class Program
    {
        static int BinarySearch(int[] arr, int Item)
        {
            int Start = 0, End = arr.Length - 1;
            while (Start <= End)
            {
                int Mid =Start + (End - Start);

                if (arr[Mid] == Item) return Mid;

                if (Item > arr[Mid]) Start = Mid + 1;

                else End = Mid - 1;
            }
            return -1;
        }
        static void Main(string[] args)
        {
            int[] arr = { 22, 25, 37, 41, 45, 46, 49, 51, 55, 58, 70, 80, 82, 90, 95 }; // Sorted array

            int x = 45; // Element to be searched

            Console.WriteLine("Sorted Array:");
            foreach (var item in arr)
                Console.Write(item + " ");
            Console.WriteLine();

            int result = BinarySearch(arr, x);

            if (result == -1)
                Console.WriteLine("Element not found in the array.");
            else
                Console.WriteLine("Element found at index: " + result);

        }
    }
}
