using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _09_09_CustomerService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> Customers = new Queue<string>();

            Customers.Enqueue("Customer 1");
            Customers.Enqueue("Customer 2");
            Customers.Enqueue("Customer 3");
            Customers.Enqueue("Customer 4");

            Console.WriteLine("Serving Customers\n");
            while (Customers.Count > 0)
            { 
                Console.WriteLine( $"Serving The { Customers.Dequeue()}");
                Thread.Sleep(2000 );
            }
        }
    }
}
