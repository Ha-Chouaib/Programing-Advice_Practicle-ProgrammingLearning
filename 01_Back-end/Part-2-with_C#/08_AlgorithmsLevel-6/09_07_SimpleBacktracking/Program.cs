using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_07_SimpleBacktracking
{
    internal class Program
    {
        static void BackTrackingMyDay(Stack<string> Activities)
        {
            Console.WriteLine(string.Join("-> ", Activities.Reverse()));

            Console.WriteLine("Backtracking ...");
            while (Activities.Count > 0)
            { 
                Console.WriteLine($"Back To: {Activities.Pop()}");
            }
        }
        static void Main(string[] args)
        {
            Stack<string> activities = new Stack<string>();

            activities.Push("Start");
            activities.Push("Go to Gaz Station");
            activities.Push("Go to Super Market");
            activities.Push("Go to Work");
            activities.Push("Go to Cafe");
            activities.Push("Go Home");

            BackTrackingMyDay(activities);

        }
    }
}
