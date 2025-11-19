using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_01_BrowserBackBtn
{
    internal class Program
    {
        class clsWebPage
        {
            public string Header { get; set; }
            public string Body { get; set; }
            public string Footer { get; set; }
        }

        enum enBrowsingOptions { BrowsBack = -1, BrowsForward = 1, Exit=0 }
        static void DrawWebPage(clsWebPage Page)
        {
            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine($"\t\tHEADER: {Page.Header}");
            Console.WriteLine("-------------------------------------\n");
            Console.WriteLine($"BODY:\n{Page.Body}");
            Console.WriteLine("\n-------------------------------------");
            Console.WriteLine($"\t\tFOOTER: {Page.Footer}");
            Console.WriteLine("=====================================");
            Console.WriteLine();
        }

        static void PerformUserOption(enBrowsingOptions opt,ref int CurrentPageIndex, ref Stack<int> PreviousPgs)
        {
            switch (opt)
            {   
                case enBrowsingOptions.Exit:
                    return;
                case enBrowsingOptions.BrowsBack:
                    if(PreviousPgs.Count > 0)                    
                        CurrentPageIndex = PreviousPgs.Pop();
                    
                    break;
                case enBrowsingOptions.BrowsForward:
                    PreviousPgs.Push(CurrentPageIndex);
                    CurrentPageIndex++;
                    break;
                default:
                    return;
            }
        }
        static void BrowseWebPages(List<clsWebPage> pages)
        {
            short UserOpt = 0;
            int CurrentPageIndex = 0;
            Stack<int> PreviousPgs = new Stack<int>();

            do
            {
                DrawWebPage(pages[CurrentPageIndex]);
                Console.WriteLine("Please Enter: [-1]-> Go Back || [1]->(Move Foreword) || [0]->(Exit)");
                while(!short.TryParse(Console.ReadLine(),out UserOpt) || (UserOpt != -1 && UserOpt != 1 && UserOpt != 0))
                {
                    Console.WriteLine("Please Enter a Valid Input: [-1], [1] or [0]");
                }
                PerformUserOption((enBrowsingOptions)UserOpt,ref CurrentPageIndex,ref PreviousPgs);

            }while (UserOpt != 0);
        }
        static void Main(string[] args)
        {
            List<clsWebPage> pages = new List<clsWebPage>
            {
                new clsWebPage { Header = "Home", Body = "Welcome to our homepage!", Footer = "© 2025 Company Inc." },
                new clsWebPage { Header = "About Us", Body = "We provide modern software solutions.", Footer = "Contact: info@company.com" },
                new clsWebPage { Header = "Services", Body = "Web development, mobile apps, cloud services.", Footer = "See our pricing plans." },
                new clsWebPage { Header = "Portfolio", Body = "Here are some of our recent projects.", Footer = "Updated monthly." },
                new clsWebPage { Header = "Blog", Body = "Latest tech articles and tutorials.", Footer = "Subscribe for updates." },
                new clsWebPage { Header = "Careers", Body = "We are hiring developers and designers.", Footer = "Apply now!" },
                new clsWebPage { Header = "Contact", Body = "Send us a message or visit our office.", Footer = "We reply within 24 hours." },
                new clsWebPage { Header = "FAQ", Body = "Frequently asked questions about our services.", Footer = "Still need help? Contact us." },
                new clsWebPage { Header = "Testimonials", Body = "What our clients say about us.", Footer = "Thanks for your trust!" },
                new clsWebPage { Header = "Terms & Conditions", Body = "Please read our terms carefully.", Footer = "Effective from January 2025." }
            };

            BrowseWebPages(pages);

        }
    }
}
