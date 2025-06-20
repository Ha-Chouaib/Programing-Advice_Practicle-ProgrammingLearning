using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Type_Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //The < Type > Class Is The Central Class in Reflection

            Type mytype = typeof(string);
            Console.WriteLine($"Type Name: [{mytype.Name}]");
            Console.WriteLine($"Full Name: [{mytype.FullName}]");
            Console.WriteLine($"Is Class: [{mytype.IsClass}]");
        }
    }
}
