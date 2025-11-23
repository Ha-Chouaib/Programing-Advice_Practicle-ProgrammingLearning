using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _09_06_TicketingSystem
{
    internal class Program
    {
        static void TicketingSystem(Queue<string> Tickets)
        {
            foreach (var ticket in Tickets)
            {
                Console.WriteLine($"Ticket: {ticket} issued");
            }
            Console.WriteLine("\n--------Ticketing System Simulation Started...----------\n");
            Thread.Sleep(2000);

            while (Tickets.Count > 0)
            {
                Console.WriteLine($"Processing Ticket: {Tickets.Dequeue()}");
                if (Tickets.Count > 0)
                {
                    Console.WriteLine($"Remaining tickets: {string.Join(", ", Tickets)}");
                    Console.WriteLine("-----------------\n");

                }
                else
                    Console.WriteLine("\nNo more tickets in the queue.\n");
                Thread.Sleep(2000);

            }
            Console.WriteLine("Ticketing System Simulation Ended.");
        }
        static void Main(string[] args)
        {
            Queue<string> Tickets = new Queue<string>();

            Tickets.Enqueue("101");
            Tickets.Enqueue("102");
            Tickets.Enqueue("103");
            Tickets.Enqueue("104");
            Tickets.Enqueue("105");
           TicketingSystem(Tickets);
        }
    }
}
