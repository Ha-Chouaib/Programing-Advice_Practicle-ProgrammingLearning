using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04_Aggregating_Data_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             1. Sum of numbers
                # Create a list of integers [10, 20, 30, 40, 50].
                # Use LINQ to calculate the sum.
                # Print the result.
             */

            List<int> Nums = new List<int> { 10, 20, 30, 40, 50 };
            Console.WriteLine($"[1] The Numbers List Sum -({string.Join(" , ",Nums)})=> [{Nums.Sum()}]");

            /*
             2. Average of prices
                # Create a list of product prices [5.5, 10.0, 7.25, 15.75].
                # Use LINQ to get the average.
                # Print the result.
             */
            List<double> Prices = new List<double> { 5.5, 10.0, 7.25, 15.75 };
            Console.WriteLine($"\n[2] The Prices List Average -({string.Join(" , ", Prices)})=> [{Prices.Average()}]");

            /*
             3. Maximum value
                # Create a list of ages [18, 25, 30, 45, 60].
                # Use LINQ to find the maximum age.
                # Print the result.
             */
            Nums= new List<int> { 18, 25, 30, 45, 60 };
            Console.WriteLine($"\n[3] The Maximum Value Of -({string.Join(" , ", Nums)})=> [{Nums.Max()}]");

            /*
             4. Minimum value
                # Create a list of temperatures [22, 30, 18, 25, 27].
                # Use LINQ to find the minimum temperature.
                # Print the result
             */

            Nums = new List<int> { 22, 30, 18, 25, 27 };
            Console.WriteLine($"\n[4] The Minimum Value Of -({string.Join(" , ", Nums)})=> [{Nums.Min()}]");

            /*
             5. Count items
                # Create a list of strings with 6 names.
                # Use LINQ to count how many names are in the list.
                # Print the result.
             */
            List<string> Names = new List<string> { "Ali", "Sara", "John","Omar","Nicolas","Mariam" };
            Console.WriteLine($"\n[5] The number of List Items  -({string.Join(" , ", Names)})=> [{Names.Count()}]");

            /*
             6. Count with condition
                # Create a list of integers [1, 2, 3, 4, 5, 6, 7, 8, 9].
                # Use LINQ to count how many numbers are even.
                # Print the result.
             */
            Nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.WriteLine($"\n[6] The number of Even Numbers  -({string.Join(" , ", Nums)})=> [{Nums.Count(n=> n%2 == 0)}]");

            /*
             7. First element
                # Create a list of product names ["Keyboard", "Mouse", "Monitor"].
                # Use LINQ to get the first item.
                # Print it.
             */
            List<string> Product = new List<string> { "Keyboard", "Mouse", "Monitor" };
            Console.WriteLine($"\n[7] Product List: {string.Join(" , ",Product)}");
            Console.WriteLine($"The First Item: {Product.First()}");

            /*
             8. Last element
                # Create a list of cities ["Paris", "London", "Tokyo", "New York"].
                # Use LINQ to get the last item.
                # Print it.
             */
            List<string> cities = new List<string> { "Paris", "London", "Tokyo", "New York" };
            Console.WriteLine($"\n[8] Product List: {string.Join(" , ", cities)}");
            Console.WriteLine($"The Last Item: {cities.Last()}");

            /*
             9. Aggregate with custom function
                # Create a list of integers [1, 2, 3, 4].
                # Use LINQ’s Aggregate to multiply all numbers together.
                # Print the result.
             */
            Nums = new List<int> { 1, 2, 3, 4 };
            Console.WriteLine($"\n[9] List Items: {string.Join(" , ", Nums)} | Multiply_All => [ {Nums.Aggregate((N, n) => N * n)} ]");

            /*
             10. Group and count
                # Create a list of fruits ["Apple", "Banana", "Apple", "Orange", "Banana"].
                # Use LINQ to group by fruit name.
                # Count how many times each fruit appears.
                # Print the result.
             */
            List<string> Fruits = new List<string> { "Apple", "Banana", "Apple", "Orange", "Banana" };
            Console.WriteLine($"\n[10] Fruits List: {string.Join(" , ", Fruits)}");
            var GroupedFruits = Fruits.GroupBy(F => F).Select( G => new {Fr = G.Key, count= G.Count()});
            foreach (var item in GroupedFruits)
            {
                Console.WriteLine(item.Fr + " -> " + item.count);
            }

            /*
             11. Concatenate strings into one sentence
                # Create a list of words: ["I", "love", "programming"].
                # Use Aggregate() to combine them into "I love programming".
                # Print the result.
             */
            List<string> Words = new List<string> { "I", "love", "programming" };
            Console.WriteLine($"\n[11] Concatenate Strings: {string.Join(" , ", Words)} | => {Words.Aggregate((W, w) => W + " " + w)}");

            /*
             12. Find the maximum manually
                # Create a list of numbers [7, 2, 10, 4, 9].
                # Use Aggregate() to compare two numbers at a time and keep the larger.
                # Print the maximum.
             */
            Nums = new List<int> { 7, 2, 10, 4, 9 };
            Console.WriteLine($"\n[12] List Items: {string.Join(" , ", Nums)} | The Max Using Aggregate() : => [ {Nums.Aggregate((N,n) => N > n ? N : n )} ]");

            /*
             13. Subtract all numbers
                # Create a list [100, 20, 5, 2].
                # Use Aggregate() to subtract numbers step by step.
                # Expected calculation: ((100 - 20) - 5) - 2.
                # Print result.
             */
            Nums = new List<int> { 100, 20, 5, 2 };
            Console.WriteLine($"\n[13] List Items: {string.Join(" , ", Nums)} | Subtract all numbers : => [ {Nums.Aggregate((N, n) => N - n)} ]");

            /*
             14. Group numbers by even/odd
                # Create a list [1, 2, 3, 4, 5, 6].
                # Use GroupBy() to separate into two groups: Even and Odd.
                # Print group key and its numbers.
             */

            Nums = new List<int> { 1, 2, 3, 4, 5, 6 };
            Console.WriteLine($"\n[14] List Items: {string.Join(" , ", Nums)}") ;
            var groupedNums = Nums.GroupBy(N => N % 2 == 0 ? "Even" : "Odd");

            foreach(var groupedNum in groupedNums)
            {
                Console.WriteLine($"{groupedNum.Key} Numbers: ");
                foreach(var num in groupedNum)
                {
                    Console.WriteLine($" {num}");
                }
            }

            /*
             15. Group names by first letter
                # Create a list of names ["Ali", "Sara", "Adam", "Lina", "Sam"].
                # Use GroupBy() on the first letter of each name.
                # Print each letter and the names under it.
             */
            Names = new List<string> { "Ali", "Sara", "Adam", "Lina", "Sam" };
            Console.WriteLine($"\n[15] List Items: {string.Join(" , ", Names)}") ;
            var GroupedByFirstLetter = Names.GroupBy(N => N[0]);
            foreach (var G in GroupedByFirstLetter)
            {
                Console.WriteLine($"Grouped By: {G.Key}");
                foreach (var N in G)
                {
                    Console.WriteLine($" {N}");
                }
            }

            /*
             6. Group words by length
                # Create a list ["Pen", "Book", "Notebook", "Phone", "PC"].
                # Use GroupBy() to group by word length.
                # Print each length and its words.
             */
            Words = new List<string> { "Pen", "Book", "Notebook", "Phone", "PC" };
            Console.WriteLine($"\n[16] List Items: {string.Join(" , ", Words)}") ;
            var groupedByLength = Words.GroupBy(w => w.Length);
            foreach (var G in groupedByLength)
            {
                Console.WriteLine($"Length: {G.Key}");
                foreach (var w in G)
                {
                    Console.WriteLine($" {w}");
                }
            }
        }
    }
}
