using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_11_ReverseQueueByStack
{
    internal class Program
    {
        static Queue<int> GetReversedQueue(Queue<int> queue)
        {
            Stack<int> stack = new Stack<int>();
            Queue<int> reversedQueue = new Queue<int>();
            while (queue.Count > 0)
            {
                    stack.Push(queue.Dequeue());
            }
            while (stack.Count > 0)
            {                
                    reversedQueue.Enqueue(stack.Pop());
            }
            return reversedQueue;
        }
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            Console.WriteLine($"Normal Queue: {string.Join(", ", queue)}\n");
            queue = GetReversedQueue(queue);
            Console.WriteLine($"\nReversed Queue: {string.Join(", ", queue)}");



        }
    }
}
