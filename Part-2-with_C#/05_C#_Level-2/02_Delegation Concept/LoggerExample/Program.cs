using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateConcept
{
    public class Logger
    {
        public delegate void LogAction(string Message);

        private LogAction _LogAction;
        public Logger(LogAction Action)
        {
            _LogAction = Action;
        }
        public void Log(string Message)
        {
            _LogAction(Message);
        }
    }
    internal class Program
    {
        public static void LogToScreen(string Message)
        {
            Console.WriteLine(Message);
        }
        public static void LogToFile(string Message)
        {
            string FileName = "log.txt";
            using(StreamWriter Writer = new StreamWriter(FileName,true))
            {
                Writer.WriteLine(Message);
            }
        }
        static void Main(string[] args)
        {
            Logger ScreenLogger = new Logger(LogToScreen);
            Logger FileLoger = new Logger(LogToFile);

            ScreenLogger.Log("You Can Log You'r Data To The Screen Right Now");
            FileLoger.Log("Log Data To File By FileLogger");
        }
    }
}
