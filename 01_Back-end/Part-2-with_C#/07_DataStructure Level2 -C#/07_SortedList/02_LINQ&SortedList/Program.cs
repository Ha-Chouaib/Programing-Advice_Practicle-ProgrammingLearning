using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_LINQ_SortedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedList<int,string>SL = new SortedList<int, string> { { 1,"One"}, { 2,"Tow"}, { 3,"Three"}, { 4,"Four"} };

            var queryExpressionSynthax= from kpv in SL where kpv.Key > 1 select kpv; //query Expression Method

            Console.WriteLine("Query Expression Result:");
            foreach (var item in queryExpressionSynthax)
            {
                Console.WriteLine($"{item.Key} || {item.Value}");
            }

            var methodQuery= SL.Where(kpv=> kpv.Key > 1); //Query Using Method Synthax
            Console.WriteLine("Method Synthax Result:");
            foreach (var item in methodQuery)
            {
                Console.WriteLine($"{item.Key} || {item.Value}");
            }

        }
    }
}
