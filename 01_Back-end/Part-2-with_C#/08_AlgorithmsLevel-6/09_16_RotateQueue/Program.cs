using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_16_RotateQueue
{
    internal class Program
    {
        static Queue<int> RotateQueue(Queue<int> queue, int K)
        {
            for (int i = 0; i < K; i++)
            { 
                queue.Enqueue(queue.Dequeue());
            }
            return queue;
        }
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>(new[] {1,2,3,4,5});

            Console.WriteLine($"Normal Queue: {string.Join(", ",queue)}");
            Console.WriteLine($"Rotated Queue: {string.Join(", ",RotateQueue(queue,2))}");
        }
    }
}
