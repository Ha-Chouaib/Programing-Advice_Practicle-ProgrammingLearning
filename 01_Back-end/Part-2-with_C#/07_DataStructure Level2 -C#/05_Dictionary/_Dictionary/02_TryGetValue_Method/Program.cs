using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_TryGetValue_Method
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,int> fruitBasket = new Dictionary<string, int> 
            {
                { "Apple",22},
                { "Banana",29},
            };

            if (fruitBasket.TryGetValue("Apple", out int AppleQuantity))
                Console.WriteLine($"Apple quantity: {AppleQuantity}");
            else 
                Console.WriteLine("No Apple In The Basket");

            if(fruitBasket.TryGetValue("Orange", out int OrangeQuantity))
                Console.WriteLine($"Orange quantity: {OrangeQuantity}");
            else
                Console.WriteLine("No Orange In The Basket");

        }
    }
}
