using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Class_Object
{   
    class clsPerson
    {
        //Fields
        public string FirstName;
        public string LastName;

        //Method
        public string FullName()
        {
            return FirstName + ' ' + LastName;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            clsPerson P1 = new clsPerson();
            Console.WriteLine("Accessing Object 1 << P1 >>");
            P1.FirstName = "Chouaib";
            P1.LastName = "Hadadi";
            Console.WriteLine(P1.FullName());

            clsPerson P2 = new clsPerson();
            Console.WriteLine("Accessing Object 2 << P2 >>");
            P2.FirstName = "Ali";
            P2.LastName = "Maher";
            Console.WriteLine(P2.FullName());
        }
    }
}
