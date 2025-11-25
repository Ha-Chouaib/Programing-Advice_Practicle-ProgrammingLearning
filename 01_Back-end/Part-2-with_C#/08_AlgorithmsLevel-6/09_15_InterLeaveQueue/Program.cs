using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_15_InterLeaveQueue
{
    internal class Program
    {
        static Queue<int> InterLeaveQueue(Queue<int> queue)
        {
            int halfSize = queue.Count / 2;
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < halfSize; i++)
            {
                stack.Push(queue.Dequeue());
            }

            while (stack.Count > 0)
            {
                queue.Enqueue(stack.Pop());
            }

            for (int i = 0; i < halfSize; i++)
            {
                queue.Enqueue(queue.Dequeue());
            }

            for (int i = 0; i < halfSize; i++)
            {
                stack.Push(queue.Dequeue());
            }

            while (stack.Count > 0)
            {
                queue.Enqueue(stack.Pop());
                queue.Enqueue(queue.Dequeue());
            }
            return queue;
        }
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>(new[] {1,2,3,4,5,6});

            Console.WriteLine($"Normal Queue:{string.Join(", ",queue)}");
            Console.WriteLine($"InterLeave Queue:{string.Join(", ",InterLeaveQueue(queue))}");
        }
    }
}
