using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_17_MergeTowSortedQueues
{
    internal class Program
    {
        static Queue<int> MergeTowQueues(Queue<int> q1,Queue<int> q2)
        {
            List<int> list = new List<int>(q1);
            list.Sort();
            q1 = new Queue<int>(list);
            
            list = new List<int>(q2);
            list.Sort();
            q2 = new Queue<int>(list);

            list = new List<int>();

            Queue<int> MergedQueue = new Queue<int>();
            int Size = q1.Count + q2.Count;
            while (q1.Count > 0 && q2.Count > 0)
            {
                if(q1.Peek() > q2.Peek())
                    { MergedQueue.Enqueue(q2.Dequeue()); }
                else
                    { MergedQueue.Enqueue(q1.Dequeue()); }

            }
            while (q1.Count > 0)
            {
                MergedQueue.Enqueue(q1.Dequeue());
            }


            while (q2.Count > 0)
            {
                MergedQueue.Enqueue(q2.Dequeue());
            }

            return MergedQueue;
        }
        static void Main(string[] args)
        {
            Queue<int> q1 = new Queue<int>(new[] { 1, 3, 5 });
            Queue<int> q2 = new Queue<int>(new[] { 4, 2, 6 });

            Console.WriteLine($"Queue1: {string.Join(", ", q1)} | Queue2: {string.Join(", ", q2)}");
            Console.WriteLine($"Merged Queue: {string.Join(", ", MergeTowQueues(q1,q2))}");
        }
    }
}
