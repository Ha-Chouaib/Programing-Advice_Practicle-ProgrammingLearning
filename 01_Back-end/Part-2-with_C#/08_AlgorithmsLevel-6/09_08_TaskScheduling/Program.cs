using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_08_TaskScheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> tasks = new Queue<string>();

            tasks.Enqueue("Task1");
            tasks.Enqueue("Task2");
            tasks.Enqueue("Task3");
            tasks.Enqueue("Task4");

            Console.WriteLine("View Scheduled tasks:");
            while (tasks.Count > 0)
            { 
                Console.WriteLine(tasks.Dequeue());
            }

        }
    }
}
