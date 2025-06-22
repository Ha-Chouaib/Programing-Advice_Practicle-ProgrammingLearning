using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Task_Class
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            Task<int> resultTask = PerformAsyncOperation();

            //Will Execute The Code Bellow While Waiting thr task to complete
            Console.WriteLine("Do Some Other Work ...");

            // [await] // Means Stop here Until You Finish The Task
            int Result = await resultTask;

            Console.WriteLine($"Result: {Result}");
        }

        static async Task<int> PerformAsyncOperation()
        {
            await Task.Delay(4000);

            return 1;
        }
    }
}
