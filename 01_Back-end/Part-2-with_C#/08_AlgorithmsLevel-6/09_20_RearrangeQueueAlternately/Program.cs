using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_20_RearrangeQueueAlternately
{
    internal class Program
    {
        static Queue<int> RearrangeQueueAlternately(Queue<int> queue)
        {

            List<int> list = new List<int>(queue);
            Queue<int> result = new Queue<int>();
            int halfSize = list.Count / 2;
            for (int i = 0; i < halfSize; i++)
            {
                result.Enqueue(list[i]);
                result.Enqueue(list[list.Count - i -1]);
            }
            if(list.Count %2 !=0)
            {
                result.Enqueue(list[halfSize]);
            }


            return result;
        }
        static void Main(string[] args)
        {
            Queue<int> myqueue = new Queue<int>();
            myqueue.Enqueue(1);
            myqueue.Enqueue(2);
            myqueue.Enqueue(3);
            myqueue.Enqueue(4);
            myqueue.Enqueue(5);
            myqueue.Enqueue(6);
            myqueue.Enqueue(7);
            Console.WriteLine($"Original Queue: [{string.Join(", ", myqueue)}]");
            Queue<int> rearrangedQueue = RearrangeQueueAlternately(myqueue);
            Console.WriteLine($"Rearranged Queue Alternately: [{string.Join(", ", rearrangedQueue)}]");
        }
    }
}
