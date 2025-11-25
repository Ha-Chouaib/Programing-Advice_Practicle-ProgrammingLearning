using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_14_SortQueue
{
    internal class Program
    {
        static Queue<int> SortQueue(Queue<int> queue)
        {
            List<int> list = new List<int>(queue);
            list.Sort();
            Queue<int> sortedQueue = new Queue<int>(list);
            return sortedQueue;
        }
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int> ();
            queue.Enqueue(5);
            queue.Enqueue(4);
            queue.Enqueue(3);
            queue.Enqueue(2);
            queue.Enqueue(1);

            Console.WriteLine($"Normal Queue: {string.Join(", ", queue)}");
            Console.WriteLine($"Sorted Queue: {string.Join(", ", SortQueue(queue))}");

        }
    }
}
