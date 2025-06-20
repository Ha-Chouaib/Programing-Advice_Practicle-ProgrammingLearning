using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Win32;

namespace _11_Intro_To_WindowssRegistry
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //To Write The Value On Local Machine You Have Two options [1] Run The Vs Code As Adminastrator [2] Add app.Manifest> file to get the permission

            string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\YourSoftware";

            string ValueName="YourValueName";
            string ValueData = "YourValueData";

            //****** Writing To Registry

            try
            {
                Registry.SetValue(KeyPath, ValueName, ValueData, RegistryValueKind.String);
                Console.WriteLine("Your Value Added Successfully: ");

            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error Accurred: " + ex.Message);
            }

            //****** Reading from Registry

            try
            {
                string GetValue = Registry.GetValue(KeyPath, ValueName, null) as string;
                if(GetValue != null)
                {
                    Console.WriteLine($"The Value Of {ValueName} is: {GetValue}");
                }
                else { Console.WriteLine("Value Not Found"); }

            }catch(Exception ex)
            {
                Console.WriteLine("An Error Accurred: " + ex.Message);
            }

        }
    }
}
