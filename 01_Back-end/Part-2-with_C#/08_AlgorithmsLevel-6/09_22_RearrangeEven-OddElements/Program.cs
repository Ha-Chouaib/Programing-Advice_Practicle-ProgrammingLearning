using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_22_RearrangeEven_OddElements
{
    internal class Program
    {
        public Queue<int> RearrangeEvenOddElements(Queue<int> inputQueue)
        {
            Queue<int> evenQueue = new Queue<int>();
            Queue<int> oddQueue = new Queue<int>();
            
            while(inputQueue.Count > 0)
            {
                if(inputQueue.Peek() % 2 == 0)
                {
                    evenQueue.Enqueue(inputQueue.Dequeue());
                }
                else
                {
                    oddQueue.Enqueue(inputQueue.Dequeue());
                }
            }
            inputQueue = new Queue<int>(evenQueue);
            while(oddQueue.Count > 0)
            {
                inputQueue.Enqueue(oddQueue.Dequeue());
            }
            return inputQueue;
        }
        static void Main(string[] args)
        {
            Queue<int> inputQueue = new Queue<int>(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            Console.WriteLine("Input Queue: " + string.Join(", ", inputQueue));
            Console.WriteLine("Rearranged Queue: " + string.Join(", ", new Program().RearrangeEvenOddElements(inputQueue)));
        }
    }
}
