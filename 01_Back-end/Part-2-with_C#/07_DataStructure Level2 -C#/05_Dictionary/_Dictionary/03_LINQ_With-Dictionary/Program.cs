using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_LINQ_With_Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> fruitBasket = new Dictionary<string, int>
            {
                { "Apple",6},
                { "Banana",2},
                { "Orange",4}
            };

            //Using LINQ To Transform items
            var fruitInfo = fruitBasket.Select(kpv => new {kpv.Key, kpv.Value});

            //Displaying the results
            Console.WriteLine("Transformed Items:");
            foreach(var item in fruitInfo )
            {
                Console.WriteLine($"Fruit: {item.Key} ,Quantity: {item.Value}");
            }

            //Using LINQ To Filter Items
            var filteredFruit = fruitBasket.Where(kpv => kpv.Value > 3);

            Console.WriteLine("\nFiltred Items:");
            foreach (var item in filteredFruit)
            {
                Console.WriteLine($"Fruit: {item.Key} ,Quantity: {item.Value}");
            }

            //Using LINQ To Sort By Value Asc
            var sortedbyQuatity = fruitBasket.OrderBy(kpv => kpv.Value);
            Console.WriteLine("\nStored Items Asc:");
            foreach (var item in sortedbyQuatity)
            {
                Console.WriteLine($"Fruit: {item.Key} ,Quantity: {item.Value}");
            }


            //Using LINQ To Sort By Value Desc
            var sortedbyQuatityDesc = fruitBasket.OrderByDescending(kpv => kpv.Value);
            Console.WriteLine("\nStored Items Desc:");
            foreach (var item in sortedbyQuatityDesc)
            {
                Console.WriteLine($"Fruit: {item.Key} ,Quantity: {item.Value}");
            }

            //Using LINQ to Aggregate Data
            int totalBasket = fruitBasket.Sum(kpv => kpv.Value);
            Console.WriteLine($"\nTotal Quantity: {totalBasket}");




        }
    }
}
