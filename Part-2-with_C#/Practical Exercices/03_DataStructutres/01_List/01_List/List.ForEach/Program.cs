using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List.ForEach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             1. Print all numbers
                # Create List<int> numbers = [1, 2, 3, 4, 5].
             */

            List<int> Nums = new List<int> { 1, 2, 3, 4, 5 };
            Console.WriteLine($"[1] looping List Content: ");
            Nums.ForEach(n=> Console.WriteLine($"--> {n}"));

            /*
             2. Print all strings in uppercase
                # Create List<string> fruits = ["apple", "banana", "orange"].
             */
            List<string> Fruits = new List<string> { "apple", "banana", "orange" };
            Console.WriteLine($"\n[2] Print All in Uppercase: ");
            Fruits.ForEach(F => Console.WriteLine(F.ToUpper()));

            /*
             3. Multiply numbers by 2 before printing
                # Create List<int> nums = [2, 4, 6].
             */
           Nums = new List<int> { 2, 4, 6 };
            Console.WriteLine($"\n[3] Multiply before by 2 print: ");
            Nums.ForEach(n => Console.WriteLine($"({n} x 2)--> {n * 2}"));


            /*
             4. Print index with value
                # Create List<string> colors = ["Red", "Green", "Blue"].
                # Use a for loop with ForEach inside:
             */
            List<string> colors = new List<string> { "Red", "Green", "Blue" };
            Console.WriteLine($"\n[4] Indexing Colors");
            for (int i = 0; i < colors.Count;)
            {
                colors.ForEach(c => Console.WriteLine($"{i++}: {c}"));
            }

            /*
             5. Print only odd numbers
                # Create List<int> numbers = [1, 2, 3, 4, 5].
             */
            Nums = new List<int> { 1, 2, 3, 4, 5 };
            Console.WriteLine($"\n[5] Print Only Odd Numbers: ");
            Nums.ForEach(n => { if (n % 2 != 0) Console.WriteLine(n); } );

            /*
             6. Add prefix before printing
                # Create List<string> names = ["Ali", "Sara", "John"].
                # "Hello " + name
             */
            List<string> Names = new List<string> { "Ali", "Sara", "John" };
            Console.WriteLine($"\n[6] Add a prefix before name: ");
            Names.ForEach(n => Console.WriteLine($"Hello {n}"));

            /*
             7. Print numbers squared
                # Create List<int> nums = [1, 2, 3, 4].
             */
            Nums = new List<int> { 1, 2, 3, 4, };
            Console.WriteLine($"\n[7] Squared Numbers: ");
            Nums.ForEach(n => Console.WriteLine(n * n));

            /*
             8. Print only words starting with "A"
                # Create List<string> fruits = ["Apple", "Banana", "Avocado", "Orange"].
             */
            Fruits = new List<string> { "Apple", "Banana", "Avocado", "Orange" };
            Console.WriteLine($"\n[8] : only words starting with \"A\" ");
            Fruits.ForEach(w => { if (w.StartsWith("A")) Console.WriteLine(w); });

            /*
             9. Collect results into another list
                # Create List<int> nums = [1, 2, 3].
                # Create an empty list squares.
                # Print squares.
             */
            List<int> Squers = new List<int>();
            Nums.ForEach(n=> Squers.Add(n * n));
            Console.WriteLine($"\n[9] : Collect Squerd Numbers Result To New List");
            Console.WriteLine($"Nums List: {string.Join(" | ", Nums)}");
            Console.WriteLine($"Squers List: {string.Join(" | ", Squers)}");

            /*
             10. Print formatted product list
                  #  Create List<string> products = ["Laptop", "Phone", "Tablet"].
                  #  ex -> Product: Laptop
             */
            List<string> Products=new List<string> { "Laptop", "Phone", "Tablet" };
            Console.WriteLine($"\n[10]: Formatted List");
            Products.ForEach(P => Console.WriteLine($"Product: {P}"));
        }
    }
}
