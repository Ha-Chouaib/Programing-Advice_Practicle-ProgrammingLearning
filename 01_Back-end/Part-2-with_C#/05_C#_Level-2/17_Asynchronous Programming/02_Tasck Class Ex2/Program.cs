using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02_Tasck_Class_Ex2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting Tas ...");

            Task t1 = DownloadAndPrintAsync("https://www.cnn.com");
            t1.Start();
            Console.WriteLine("Task <1> Started ...");

            Task t2 = DownloadAndPrintAsync("https://www.amazon.com");
            t1.Start();
            Console.WriteLine("Task <2> Started ...");

            Task t3 = DownloadAndPrintAsync("https://www.ProgrammingAdvices.com");
            t1.Start();
            Console.WriteLine("Task <3> Started ...");

            await Task.WhenAll(t1, t2, t3);//wait for all Tasks to Complete

            Console.WriteLine("\nAll Web Pages Are Downloaded Successfully");


        }

        static async Task DownloadAndPrintAsync(string Url)
        {
            StringBuilder Content = new StringBuilder();

            using (WebClient Client = new WebClient())
            {
                await Task.Delay(100);// Add a Delay To Simulate Some-Actions

                Content.Append(await Client.DownloadStringTaskAsync(Url));
            }

            Console.WriteLine($"{Url}: {Content.Length} Characters Downloaded");
        }
    }
}
