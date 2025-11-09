 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// important To Import This Lib
using System.Diagnostics;
namespace _12_Logging_Event_Log
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sourceName = "KokoApp";

            if(!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, "Application");
                Console.WriteLine("Event Source Added Successfully");
            }

            EventLog.WriteEntry(sourceName,"This is My Information.",EventLogEntryType.Information);
            EventLog.WriteEntry(sourceName,"This is My Warning.",EventLogEntryType.Warning);
            EventLog.WriteEntry(sourceName,"This is My Error.",EventLogEntryType.Error);
        }
    }
}
