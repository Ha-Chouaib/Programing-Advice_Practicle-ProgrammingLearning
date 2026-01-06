using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_23_CloneQueue
{
    internal class Program
    {
        public static Queue<T> CloneQueue<T>(Queue<T> originalQueue)
        {
            if(originalQueue.Count == 0)return new Queue<T>();

            T FirstElement = originalQueue.Dequeue();
            Queue<T> ClonedQueue = CloneQueue(originalQueue);

            ClonedQueue.Enqueue(FirstElement);
            return ClonedQueue;
        }
        static void Main(string[] args)
        {
            Queue<int> originalQueue = new Queue<int>(new[] { 1, 2, 3, 4, 5 });
            Console.WriteLine("Original Queue: " + string.Join(", ", originalQueue));
            Queue<int> clonedQueue = CloneQueue(originalQueue);
            Console.WriteLine("Cloned Queue: " + string.Join(", ", clonedQueue));
        }
    }
}
