using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _02_Parameterized_Thread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(()=> Method1("Thread 1")); //Create a Thread For Method1 and Execute It In parallel Woth The Entier Code On The Main
            t.Start();

            Thread t2 = new Thread(()=> Method2("Thread 2"));
            t2.Start();

            t.Join();
            t2.Join();// This Stops Main Execution until t2 Finish 


            for (byte i = 0; i < 15; i++)
            {
                Console.WriteLine($"Main: {i}");
                Thread.Sleep(500);//Just To Slow The Execution
            }

        }

        static void Method1(string ThreadName)
        {
            for (byte i = 0; i < 10; i++)
            {
                Console.WriteLine($"{ThreadName} Method< 1 >: {i}");
                Thread.Sleep(500);
            }
        }
        static void Method2(string ThreadName)
        {
            for (byte i = 0; i < 10; i++)
            {
                Console.WriteLine($"{ThreadName} Method< 2 >: {i}");
                Thread.Sleep(500);
            }
        }
    }
}
