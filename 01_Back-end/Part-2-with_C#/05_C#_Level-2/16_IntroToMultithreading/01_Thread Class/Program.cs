using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _01_Thread_Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(Method1); //Create a Thread For Method1 and Execute It In parallel Woth The Entier Code On The Main
            t.Start();

            Thread t2 = new Thread(Method2);
            t2.Start();

            //t.Join();
            t2.Join();// This Stops Main Execution until t2 Finish 


            for (byte i = 0; i < 15; i++)
            {
                Console.WriteLine($"Main: {i}");
                Thread.Sleep(500);//Just To Slow The Execution
            }

        }

        static void Method1()
        {
            for(byte i =0; i<10; i++)
            {
                Console.WriteLine($"Method< 1 >: {i}");
                Thread.Sleep(500);
            }
        }
        static void Method2()
        {
            for (byte i = 0; i < 10; i++)
            {
                Console.WriteLine($"Method< 2 >: {i}");
                Thread.Sleep(500);
            }
        }
    }
}
