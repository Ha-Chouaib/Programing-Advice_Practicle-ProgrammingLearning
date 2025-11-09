using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Task.Run
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //[ Task.Run ] is a Powerful Method Used For << Multithreading >> in C#. It Allows You to Execute Code Concurrently by Offloading it to a Background Thread
            // from The thread pool. This Keeps The UI Responsive While The Background Task Is running

            Task task1 = Task.Run(() => DownloadFile("Download file[1]"));
            Task task2 = Task.Run(() => DownloadFile("Download file[2]"));

            await Task.WhenAll(task1, task2);

            Console.WriteLine("Task 1 and 2 are Completed");
        }
         static void DownloadFile(string TaskName)
        {
            Console.WriteLine($"{TaskName} Is Started");
            Task.Delay(1000);
            Console.WriteLine($"{TaskName} Is Completed");
        }
    }
}
