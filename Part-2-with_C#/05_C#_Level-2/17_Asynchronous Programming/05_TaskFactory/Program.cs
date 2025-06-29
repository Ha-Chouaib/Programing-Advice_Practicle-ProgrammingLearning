using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _05_TaskFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Define a cancellation token so we can stop the task if needed.
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            //Create a TaskFactory With Some Common Configuration
            TaskFactory taskFactory = new TaskFactory(token, TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);

            //Use The TaskFactory to Create and Start a new Task
            Task t1 = taskFactory.StartNew(() =>
            {
                Console.WriteLine("Task 1 is Running");

                Thread.Sleep(2000);

                Console.WriteLine("Task 1 is Completed");
            });
            //cts.Cancel();// To Cancel Tasks

            Task t2 = taskFactory.StartNew(() =>
            {
                Console.WriteLine("Task 2 is Running");

                Thread.Sleep(2000);

                Console.WriteLine("Task 2 is Completed");
            });

            try
            {
                Task.WaitAll(t1, t2);
                Console.WriteLine("All Tasks Are Done");
            }catch(AggregateException ae)
            {
                foreach (var e in ae.InnerExceptions)
                    Console.WriteLine($"Exception: {e.Message}");
            }

            cts.Dispose(); 
        }
    }
}
