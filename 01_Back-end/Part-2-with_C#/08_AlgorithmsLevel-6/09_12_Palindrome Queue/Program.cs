using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_12_Palindrome_Queue
{
    internal class Program
    {
          static bool IsPalindromeQueue(Queue<int> queue)
        {
            Stack<int> stack = new Stack<int>(queue);
            while (queue.Count > 0)
            { 
                if(queue.Dequeue() != stack.Pop())
                    return false ;
            }
            return true ;
        }
        static void Main(string[] args)
        {
            Queue<int> queue1 = new Queue<int>() ;
            queue1 .Enqueue(1) ;
            queue1 .Enqueue(2) ;
            queue1 .Enqueue(3) ;
            queue1 .Enqueue(2) ;
            queue1 .Enqueue(1) ;

            Console.WriteLine($"Is queue1[{string.Join(" ", queue1)}] palindrome? ->[ {IsPalindromeQueue(queue1)} ]\n");

            Queue<int> queue2 = new Queue<int>();
            queue2.Enqueue(1);
            queue2.Enqueue(2);
            queue2.Enqueue(3);
            queue2.Enqueue(2);
            queue2.Enqueue(4);

            Console.WriteLine($"\nIs queue2[{string.Join(" ", queue2)}] palindrome? ->[ {IsPalindromeQueue(queue2)} ]");
        }
    }
}
