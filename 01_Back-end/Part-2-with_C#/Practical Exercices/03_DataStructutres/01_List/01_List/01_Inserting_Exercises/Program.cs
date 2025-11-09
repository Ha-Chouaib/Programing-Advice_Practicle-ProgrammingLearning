using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _01_Inserting_Exercises
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Ex [1]
            /*
             1. Add a single number
                # Create a List<int>.
                # Add the numbers 1, 2, 3 using Add().
                # Print the list.
             */

            List<int> Nums = new List<int>();

            Nums.Add(1);
            Nums.Add(2);
            Nums.Add(3);
            Nums.Add(4);
            Nums.Add(5);

            Console.WriteLine($"[1]_Displaying List Contenet: {string.Join(" | ", Nums)}");

            //Ex [2]
            /*
            2. Add a product name
                # Create a List<string> for products.
                # Add "Laptop", "Phone", "Tablet".
                # Print all products.
             */

            List<string> Products= new List<string>();
            Products.Add("Laptop");
            Products.Add("Phone");
            Products.Add("Tablet");

            Console.WriteLine($"\n\n[2]_Displaying Products Name: {string.Join(" | ", Products)}");

            //Ex [3]
            /*
            3. Insert at the beginning
                # Create a List<int> with values [10, 20, 30].
                # put 5 at the beginning.
                # Print the list.
             */
            List <int>numbers= new List<int> { 10,20,30};
            Console.WriteLine($"\n\nInitial List Content: {string.Join(" | ", numbers)}");
            numbers.Insert(0, 5);
            Console.WriteLine($"After Adding [5]: {string.Join(" | ", numbers)}");

            //Ex [4]
            /*
             4. Insert in the middle
                # Create a List<string> with ["Apple", "Banana", "Orange", ...].
                # Insert "Mango" in the middle.
                # Print the list.
             */
            List<string> Fruits= new List<string> { "Apple","Banana","Orange","Pineapple","Grapes","Strawberry","Kiwi"};
            Console.WriteLine($"\n\nInitial Fruits Names: {string.Join(" | ", Fruits)}");
            Fruits.Insert((Fruits.Count / 2), "Mango");
            Console.WriteLine($"After Adding [Mango] int The Middel: {string.Join(" | ", Fruits)}");

            //Ex [5]
            /*
             5. Insert at the end
                # Create a List<int> with [100, 200, 300].
                # 400 to add at the end.
                # Print the list/
            */
            List<int> nums= new List<int> { 100,200,300};
            Console.WriteLine($"\n\nInitial List Items: {string.Join(" | ", nums)}");
            nums.Insert((nums.Count), 400);
            Console.WriteLine($"After Adding [400] at the end: {string.Join(" | ", nums)}");

            //Ex [6]
            /*
             6. InsertRange at the beginning
                # Create a List<int> with [10, 20, 30].
                # Create another List<int> with [1, 2, 3].
                # InsertRange at index 0.
                # Result: [1, 2, 3, 10, 20, 30].
             */

            nums.InsertRange(0, new List<int> { 10, 20, 30, 40 });
            Console.WriteLine($"\nAfter Adding The New List at the Beginning: {string.Join(" | ", nums)}");

            //Ex [7]
            /*
             7. InsertRange in the middle
                # Create a List<string> with ["A","B", "C","F", "G"].
                # InsertRange int the Middel with ["D","E"].
                # Print result → ["A", "B", "C", "D","E","F","G"].
             */
            List<string> Chars= new List<string> { "A", "B", "C", "F", "G" };
            Console.WriteLine($"\n\nInitial List Items: {string.Join(" | ", Chars)}");
            Chars.InsertRange((Chars.Count / 2) +1, new List<string> { "D", "E" });
            Console.WriteLine($"After Adding [D ,E] int The Middel: {string.Join(" | ", Chars)}");

            //Ex [8]
            /*
             8. InsertRange at the end
                # Create a List<int> with [1, 2, 3].
                # InsertRange at index the end with [4, 5, 6].
                # Print result.
             */
            nums = new List<int> { 1, 2, 3 };
            Console.WriteLine($"\n\nInitial List Items: {string.Join(" | ", nums)}");
            nums.InsertRange((nums.Count), new List<int> { 4,5,6});
            Console.WriteLine($"After Adding [4,5,6] at the end: {string.Join(" | ", nums)}");

            //Ex [9]
            /*
             9. Add multiple using loop
                #Create a List<int>.
                #Use a for loop to Add() numbers from 1 to 20.
                #Print list → [1, 2, 3, 4, 5, ...,20].
             */

            nums = new List<int>();
            for(int i=0; i < 20; i++ )
            {
                nums.Add(i + 1);
            }
            Console.WriteLine($"\nAfter Filling List Using Loop : {string.Join(" | ", nums)}");

            //Ex [10]
            /*
             10. Combine two product lists
                # Create List<string> list1 = ["Keyboard", "Mouse"].
                # Create List<string> list2 = ["Monitor", "Printer"].
                # InsertRange at index 1 of list1 with list2.
                # Print result → ["Keyboard", "Monitor", "Printer", "Mouse"].
             */
            List<string> list1=new List<string> { "Keyboard", "Mouse"};
            List<string> list2=new List<string> { "Monitor", "Printer" };
            byte Middel = (byte) Math.Ceiling(list1.Count / 2.0);

            list1.InsertRange(Middel, list2);

            Console.WriteLine($"\n\nAfter  puting List Tow In The Midle Of list One : {string.Join(" | ", list1)}");



        }
    }
}
