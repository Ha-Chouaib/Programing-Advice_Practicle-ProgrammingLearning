using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_WorkingWithSortedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedList<string,int>FruitsBasket = new SortedList<string,int>();

            
            FruitsBasket.Add("Banana", 3);
            FruitsBasket.Add("Orange", 2);
            FruitsBasket.Add("Cherry", 5);

            Console.WriteLine($"The Quantity of Cherry: {FruitsBasket["Cherry"]}");

            Console.WriteLine($"\nIteration Over the Sorted List:");
            foreach(var item in FruitsBasket)
            {
                Console.WriteLine($"Fruit: {item.Key} || Quantity: {item.Value}");
            }

            FruitsBasket.Remove("Cherry");

            Console.WriteLine($"\nFruits After Removing Cherry:");
            foreach (var item in FruitsBasket)
            {
                Console.WriteLine($"Fruit: {item.Key} || Quantity: {item.Value}");
            }

        }
    }
}
