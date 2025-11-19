using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_01_CoinChange
{
    internal class Program
    {
        static List<int> MinCoinsNeeded(List<int> Denominations, int Amount)
        {

            List<int> result = new List<int>();

            foreach (var coin in Denominations.OrderByDescending(n => n))
            {
                while (Amount >= coin)
                {
                    result.Add(coin);
                    Amount -= coin;
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            List<int> DollarDenomination = new List<int> { 1, 5, 10, 20, 50, 100 };
            int Amount = 30;

            Console.WriteLine($"The minimum number of coins needed to make up that amount [{Amount}] using the largest denominations possible:");
            foreach (int coin in MinCoinsNeeded(DollarDenomination, Amount))
            {
                Console.WriteLine(coin);
            }
        }
    }
}
