//[1] Using -> To Import Libs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//[2] Using -> To Make An Alias Name To Long Terms
using koko = System.Console;

//[3] Using static -> To Import a Specific Class Within a name Space
using static System.Math;
using System.IO;

namespace Using_In_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {

            koko.WriteLine("Hello! From Koko Alias Name");
            koko.WriteLine($"The Square Number Of 4 is: {Sqrt(4)} / Without Using static You Should Enter Math.Sqrt Instead Of Sqrt() Directly");

            //[4] Using -> For Resource Management
            using( StreamWriter Writer = new StreamWriter("Example.txt"))
            {
                Writer.WriteLine("Test Using Statment In C# For Resource Managment",true);
            }

            using( StreamReader Reader =new StreamReader("Example.txt"))
            {
                string Line = "";
                while((Line =Reader.ReadLine()) != null)
                {
                    Console.WriteLine(Line);
                }
            }
        }
    }
}
