using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Class_ask_with_CallBackEvent
{
    public class CustomEventArgs: EventArgs
    {
        public int Param1 { get; }
        public string Param2 { get; }

        public CustomEventArgs(int Param1, string Param2)
        {
            this.Param1 = Param1;
            this.Param2 = Param2;
        }
    }
    internal class Program
    {
        public delegate void CallBackEventHandler(object sender, CustomEventArgs e);
        public static event CallBackEventHandler CallbackEvent;
        static async Task Main(string[] args)
        {
            CallbackEvent += OnCallbackReceived;

            Task PerformTask = PerformAsyncOperation(CallbackEvent);

            Console.WriteLine("Doing Some Other Work ...");

            await PerformTask;// Wait For The Task To Be Completed

            Console.WriteLine("Done !");
        }
        static async Task PerformAsyncOperation(CallBackEventHandler Callback)
        {
            await Task.Delay(2000);

            CustomEventArgs eventArgs = new CustomEventArgs(99, "Hello from The Event");

            Callback?.Invoke(null, eventArgs);
        }
        static void OnCallbackReceived(object sender,CustomEventArgs e)
        {
            Console.WriteLine($"Event Received -->  Parameter[1]: < {e.Param1} > | Parameter[2]: < {e.Param2} > ");
        }
    }
}
