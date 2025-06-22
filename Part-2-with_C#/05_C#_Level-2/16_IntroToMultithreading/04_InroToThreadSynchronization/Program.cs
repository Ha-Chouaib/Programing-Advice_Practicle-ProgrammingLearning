using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _04_Inro_To_Thread_Synchronization
{
    internal class Program
    {
        static int SharedCounter = 0;
        static object lockObject = new object();
        static void Main(string[] args)
        {
            Thread t1 = new Thread(IncrementCounter);
            t1.Start();

            Thread t2 = new Thread(IncrementCounter);
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine($"Final Counter Value: [ {SharedCounter} ]");

        }

        static void IncrementCounter()
        {
            for(int i=0; i< 100; i++)
            {
                lock(lockObject) // Use 'lock' to synchronize access to The shared counter 
                {
                    SharedCounter++;
                }
            }
        }
    }
}
