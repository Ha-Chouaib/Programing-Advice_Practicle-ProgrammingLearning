using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _03_Download_3_WebPages_Ex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Threads ...");

            Thread t1 = new Thread(() => DownloadAndPrint("https://www.cnn.com"));
            t1.Start();
            Console.WriteLine("Thread <1> Started ...");

            Thread t2 = new Thread(() => DownloadAndPrint("https://www.amazon.com"));
            t1.Start();
            Console.WriteLine("Thread <2> Started ...");

            Thread t3 = new Thread(() => DownloadAndPrint("https://www.ProgrammingAdvices.com"));
            t1.Start();
            Console.WriteLine("Thread <3> Started ...");

            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine("\nAll Web Pages Are Downloaded Successfully");


        }

        static void DownloadAndPrint(string Url)
        {
            StringBuilder Content = new StringBuilder();

            using (WebClient Client = new WebClient())
            {
                Thread.Sleep(100);// Add a Delay To Simulate Some-Actions

                Content.Append( Client.DownloadString(Url)) ; 
            }

            Console.WriteLine($"{Url}: {Content.Length} Characters Downloaded");
        }
    }
}
