using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_GroupBy_SL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedList<int, string> sortedList = new SortedList<int, string>()
            {
                { 1, "Apple" },
                { 2, "Banana" },
                { 3, "Cherry" },
                { 4, "Date" },
                { 5, "Grape" },
                { 6, "Fig" },
                { 7, "Elderberry" }
            };       
        //Grouping By The Length Of The Value
            Console.WriteLine("Grouping By The Length Of The Value");
            var Groups = sortedList.GroupBy(g => g.Value.Length);
            foreach (var g in Groups)
            {
                Console.WriteLine($"Length: {g.Key}: {string.Join(" , ",g.Select(kpv => kpv.Value))}");            
            }
        
        }
    }
}
