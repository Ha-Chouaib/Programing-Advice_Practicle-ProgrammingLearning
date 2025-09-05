using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_AdvancedLINQQuieries
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, string> fruitCategory = new Dictionary<string, string>
            {
                {"Apple","Tree"},
                {"Banana","Herb"},
                {"Cherry","Tree"},
                {"Strawbarry","Bush"},
                {"Raspberry","Bush"},
            };

            // Grouping fruits By Category
            var groupedFruits = fruitCategory.GroupBy(kpv => kpv.Value);
            foreach (var group in groupedFruits)
            {
                Console.WriteLine($"category: {group.Key}");
                foreach (var fruit in group)
                {
                    Console.WriteLine($" - {fruit.Key}");
                }
            }

            //---------------------------

            Dictionary<string, int> fruitBasket = new Dictionary<string, int>
            {
                { "Apple",6},
                { "Banana",2},
                { "Orange",4}
            };

            // Combined LINQ Queries
            var sortedFiltredFruits = fruitBasket
                .Where(kpv => kpv.Value > 3)
                .OrderBy(kpv => kpv.Key)
                .Select(kpv => new { kpv.Key, kpv.Value });
            Console.WriteLine("\n\nSorted and Filtered Fruits:");
            foreach(var fruit in sortedFiltredFruits)
            {
                Console.WriteLine($"Fruits: {fruit.Key}, Quantity: {fruit.Value}");
            }
        }
    }
}
