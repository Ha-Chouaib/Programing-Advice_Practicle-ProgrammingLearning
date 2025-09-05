using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int > fruitBasket = new Dictionary<string, int>();

            fruitBasket.Add("Apple",5);
            fruitBasket.Add("Banana",3);
            fruitBasket.Add("Orange",7);

            Console.WriteLine("Dictionary Initial content");
            foreach (KeyValuePair<string, int> item in fruitBasket)
            {
                Console.WriteLine($"Fruit: [{item.Key}], Quantity: [{item.Value}]");   
            }

            fruitBasket["Apple"] = 11;

            fruitBasket.Remove("Banana");
            Console.WriteLine("\nDictionary content After Removing Banana And Update Apple Quantity");
            foreach (KeyValuePair<string, int> item in fruitBasket)
            {
                Console.WriteLine($"Fruit: [{item.Key}], Quatity: [{item.Value}]");
            }

        }
    }
}
