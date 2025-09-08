using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Removing_Exercises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             1. Remove a number by value
                # Create List<int> numbers = [10, 20, 30, 40].
                # Remove 20.
                # Print result → [10, 30, 40].
             */

            List<int> Nums= new List<int> { 10,20,30,40};
            Console.WriteLine($"[1]List Initial Values: {string.Join(" | ",Nums)}");
            Nums.Remove(20);
            Console.WriteLine($"After Removing [20] : {string.Join(" | ",Nums)}");

            /*
             2. Remove a string by value
                # Create List<string> fruits = ["Apple", "Banana", "Orange"].
                # Call fruits.Remove("Banana").
                # Print result → ["Apple", "Orange"].
             */
            List<string> fruits = new List<string> { "Apple", "Banana", "Orange" };
            Console.WriteLine($"\n\n[2]List Initial fruit List Values: {string.Join(" | ", fruits)}");
            fruits.Remove("Banana");
            Console.WriteLine($"After removing [Banana]: {string.Join(" | ", fruits)}");

            /*
             3. RemoveAt from beginning
                # Create List<int> numbers = [1, 2, 3, 4].
                # Print result → [2, 3, 4].
             */
            List<int> Nums1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, };
            Console.WriteLine($"\n\n[3]List Initial Values: {string.Join(" | ", Nums1)}");
            Nums1.RemoveAt(0);
            Console.WriteLine($"After Removing the beginning value : {string.Join(" | ", Nums1)}");

            /*
             4. RemoveAt from middle
                # Create List<string> colors = ["Red", "Green", "Blue", "Yellow"].
                # Print result → ["Red", "Green", "Yellow"].
             */
            List<string> colors = new List<string> { "Red", "Green", "Blue", "Yellow" };
            Console.WriteLine($"\n\n[4]Initial colors list Values: {string.Join(" | ", colors)}");
            byte Middle = (byte)Math.Round(colors.Count / 2.0);
            colors.RemoveAt(Middle);
            Console.WriteLine($"After Removing Middel Value : {string.Join(" | ", colors)}");

            /*
             5. RemoveAt from end
                # Create List<int> nums = [5, 10, 15, 20].
                # Print result → [5, 10, 15].
             */
            List<int> Nums2 = new List<int> { 1, 2, 3, 4, 5, 6, 7, };
            Console.WriteLine($"\n\n [5]List Initial Values: {string.Join(" | ", Nums2)}");
            Nums2.RemoveAt(Nums2.Count -1);
            Console.WriteLine($"After Removing the end value : {string.Join(" | ", Nums2)}");

            /*
             RemoveAll even numbers
                # Create List<int> numbers = [1, 2, 3, 4, 5, 6].
                # Print result → [1, 3, 5].
             */
            Nums2.RemoveAll(N => N % 2 == 0);
            Console.WriteLine($"[6]After Removing All Even Values : {string.Join(" | ", Nums2)}");

            /*
             7. RemoveAll strings with length > 5
                  # Create List<string> words = ["Pen", "Pencil", "Notebook", "Book"].
                  # Print result → ["Pen", "Book"].
             */

            List<string> words = new List<string> { "Pen", "Pencil", "Notebook", "Book" };
            Console.WriteLine($"\n\n [7]Words List Initial Values: {string.Join(" | ", words)}");
            words.RemoveAll(w => w.Length > 5);
            Console.WriteLine($"After Removing All Words with length > 5 : {string.Join(" | ", words)}");

            /*
                8. RemoveAll negative numbers
                    # Create List<int> nums = [-3, -1, 0, 2, 4, -5].
                    # Print result → [0, 2, 4].
             */

            List<int> Nums3 = new List<int> { -3, -1, 0, 2, 4, -5 };
            Console.WriteLine($"\n\n [8]List Initial Values: {string.Join(" | ", Nums3)}");
            Nums3.RemoveAll(N=> N < 0);
            Console.WriteLine($"After Removing All Negative Numbers : {string.Join(" | ", Nums3)}");

            /*
             9. Remove only first occurrence 
                # Create List<int> nums = [1, 2, 3, 2, 4].
                # Print result → [1, 3, 2, 4] (only first 2 removed).
             */
            List<int> Nums4 = new List<int> { 1, 2, 3, 2, 4 };
            Console.WriteLine($"\n\n [9]List Initial Values: {string.Join(" | ", Nums4)}");
            Nums4.Remove(2);
            Console.WriteLine($"After Removing the first [2] : {string.Join(" | ", Nums4)}");

            /*
             10. RemoveAll specific word case-insensitive
                # Create List<string> fruits = ["Apple", "Banana", "apple", "Orange"].
                # Print result → ["Banana", "Orange"].
             */
            List<string> fruits1 = new List<string> { "Apple", "Banana", "Orange" };
            Console.WriteLine($"\n\n[10]List Initial fruit2 List Values: {string.Join(" | ", fruits1)}");
            fruits1.RemoveAll(f => f.ToUpper() == "APPLE");
            Console.WriteLine($"After removing [Apple/apple] at ones: {string.Join(" | ", fruits1)}");

        }
    }
}
