using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _09_10_WebPageRequestHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> requests = new Queue<string>();

            requests.Enqueue("Request 1");
            requests.Enqueue("Request 2");
            requests.Enqueue("Request 3");
            requests.Enqueue("Request 4");

            Console.WriteLine("Processing requests\n");
            while (requests.Count > 0)
            {
                Console.WriteLine($"Process {requests.Dequeue()}");
                Thread.Sleep(2000);
            }
            Console.WriteLine("No More Requests");
        }
    }
}
