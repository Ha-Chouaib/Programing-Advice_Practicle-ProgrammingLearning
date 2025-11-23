using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _09_05_TrafficSignalSystem
{
    internal class Program
    {
        static void TrafficSignal(Queue<string> VehiclesQueue)
        {
            Console.WriteLine("Traffic Signal Simulation Started...");
            Thread.Sleep(2000);
            while (VehiclesQueue.Count > 0)
            {
                Console.WriteLine($"{VehiclesQueue.Dequeue()} has passed the signal.");               
                Console.WriteLine($"Vehicles waiting: {string.Join(" ", VehiclesQueue)}");
                Console.WriteLine("------------------------\n");
                Thread.Sleep(2000);

            }
            Console.WriteLine("No vehicles waiting.\nTraffic Signal Simulation Ended.");
        }
        static void Main(string[] args)
        {
            Queue<string> VehiclesQueue = new Queue<string>();

            VehiclesQueue.Enqueue("Car_1");
            VehiclesQueue.Enqueue("Truck_1");
            VehiclesQueue.Enqueue("Bike_1");
            VehiclesQueue.Enqueue("Bus_1");

            TrafficSignal(VehiclesQueue);
        }
    }
}
