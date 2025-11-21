using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_04_PrinterJobScheduling
{
    internal class Program
    {

        public enum enHandlingScheduledJobsOptions { enScheduleNewJob=1, enViewAllJobs=2,enProcessTheNextJob=3,enViewTheNextJob=4,enClearAllJobs=5,enExit=6 }
       
        static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("====== Printer Job Scheduler ======");
            Console.WriteLine("\t[1]. Schedule New Job");
            Console.WriteLine("\t[2]. View All Jobs");
            Console.WriteLine("\t[3]. Process Next Job");
            Console.WriteLine("\t[4]. View Next Job");
            Console.WriteLine("\t[5]. Clear All Jobs");
            Console.WriteLine("\t[6]. Exit");
            Console.Write("Choose: ");
        }
        static void RunPrinterJobScheduler(ref Queue<string> jobs)
        {
           
            enHandlingScheduledJobsOptions UserOpt;
            do
            {
                DisplayMenu();

                StringBuilder input = new StringBuilder(Console.ReadLine());
                 UserOpt = (enHandlingScheduledJobsOptions)CheckValidInput(input);

                while (UserOpt == 0)
                {
                    Console.WriteLine("Invalid Input Please Enter: 1, 2, 3, 4, 5 or 6");
                    UserOpt = (enHandlingScheduledJobsOptions)CheckValidInput(new StringBuilder(Console.ReadLine()));
                }
                if(UserOpt != enHandlingScheduledJobsOptions.enExit)
                    HandleUserSelection(ref jobs,UserOpt);

            } while (UserOpt != enHandlingScheduledJobsOptions.enExit);
            
        }

        static byte CheckValidInput(StringBuilder input)
        {
            byte opt = 0;
            byte[] ValidOptions = new byte[] { 1,2,3,4,5,6};
            if (byte.TryParse(input.ToString(), out opt) && ValidOptions.Contains(opt)) return opt;
            return 0;
        }
        static void ScheduleNewJob(ref Queue<string> Jobs)
        {
            Console.WriteLine("\n============================");
            Console.WriteLine("Scheduling a New Jobs: ");
            Console.WriteLine("============================\n");
            Console.Write("Enter job name: ");
            Jobs.Enqueue(Console.ReadLine());
            Console.WriteLine("\n✔ Job added successfully!");
        }
        static void ViewAllJobs(Queue<string> Jobs)
        {
            Console.WriteLine("\n============================");
            Console.WriteLine("List Scheduled Jobs: ");
            Console.WriteLine("============================\n");
            if(Jobs.Count <= 0)
            {
                Console.WriteLine("No Scheduled Jobs To be Shown!");
                Console.WriteLine("\n============================\n\n");
                return;
            }
            foreach(var job in  Jobs)
            {
                Console.WriteLine(job);
                
            }
            Console.WriteLine("\n============================\n\n");
        }
        static void ProcessNextJob(ref Queue<string> Jobs)
        {
            Console.WriteLine("\n============================");
            Console.WriteLine("Process a Job");
            Console.WriteLine("============================\n");
            if(Jobs.Count <= 0)
            {
                Console.WriteLine("No Scheduled Jobs To be Shown!");
                Console.WriteLine("\n============================\n\n");
                return;

            }
            Console.WriteLine($"Processing: {Jobs.Dequeue()}");
            Console.WriteLine("\n============================\n\n");
        }
        static void ViewNextJob(Queue<string> Jobs)
        {
            Console.WriteLine("\n============================");
            Console.WriteLine("Display Next Scheduled Job");
            Console.WriteLine("============================\n");
            if (Jobs.Count <= 0)
            {
                Console.WriteLine("No Scheduled Jobs To be Shown!");
                Console.WriteLine("\n============================\n\n");
                return;
            }
            Console.WriteLine( $"The Next Scheduled Job: {Jobs.Peek()}");
            Console.WriteLine("\n============================\n\n");
        }
        static void ClearAllJobs(ref Queue<string> Jobs)
        {
            Console.WriteLine("\n============================");
            Console.WriteLine("⚠ Clear All Scheduled Jobs");
            Console.WriteLine("============================\n");
            Jobs.Clear();
            Console.WriteLine("Jobs Queue Is deleted Successfully");
        }

        static void refreshPage()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
           
        }
        static void HandleUserSelection(ref Queue<string> Jobs,enHandlingScheduledJobsOptions UserOpt )
        {
            switch(UserOpt)
            {
                case enHandlingScheduledJobsOptions.enScheduleNewJob:
                    ScheduleNewJob(ref Jobs);
                    refreshPage();
                    break;
                case enHandlingScheduledJobsOptions.enViewAllJobs:
                    ViewAllJobs(Jobs);
                    refreshPage();

                    break;
                case enHandlingScheduledJobsOptions.enProcessTheNextJob:
                    ProcessNextJob(ref Jobs);
                    refreshPage();
                    break;
                case enHandlingScheduledJobsOptions.enViewTheNextJob:
                    ViewNextJob(Jobs);
                    refreshPage();
                    break;
                case enHandlingScheduledJobsOptions.enClearAllJobs:
                    ClearAllJobs(ref Jobs);
                    refreshPage();
                    break;
                case enHandlingScheduledJobsOptions.enExit:
                    break;
                    default:
                    break;
            }
        }
        
        static void Main(string[] args)
        {
            Queue<string> jobs = new Queue<string>();
            RunPrinterJobScheduler(ref jobs);

        }
    }
}
