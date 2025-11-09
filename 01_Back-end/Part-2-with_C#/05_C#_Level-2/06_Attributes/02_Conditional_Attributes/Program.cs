#define TRACE_ENABLED // Custom Name For Conditional Attribute, You Can Name It Any
                       // Any Method Without This Conditional Name Will Not Be Executed
                       // So You Have The Control Over The Methods Will Be Executed Or Not By Just This Tag Name:  [Conditional( Koko )]
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace Conditional_Attributes
{
    public class MyClass
    {
        [Conditional("DEBUG")] // Will Be run just in debug Mode not in Release Mode
        public void  DebugMethod()
        {
            Console.WriteLine("Debug Method Executed");
        }

        public void NormalMethod()
        {
            Console.WriteLine("Normal Method Executed");
        }
    }

    public class TraceExample
    {
        [Conditional("TRACE_ENABLED")]
        public static void LogTrace(string Message)
        {
            Console.WriteLine("[TRACE] "+Message);
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();

            myClass.DebugMethod();
            myClass.NormalMethod();

            TraceExample.LogTrace("Is This Func Invoked?!");
        }
    }
}
