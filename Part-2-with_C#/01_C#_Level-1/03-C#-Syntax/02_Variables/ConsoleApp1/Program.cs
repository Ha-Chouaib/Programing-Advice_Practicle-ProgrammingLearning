using System;

namespace Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string MyName="Chouaib Hadadi";
            int x=22;
            char Gender='M';
            double Salary=98622.783D;
            bool isMaried=false;

            Console.WriteLine("My Name is: {0}, I'am {1} YearsOld.",MyName,x);
            Console.WriteLine("Gender: {0}, Salary: {1}, Is Maried? {2} ",Gender,Salary,isMaried);
            
            //Implicitly Typed Variable = < var > <==> < auto > in C++.

            var a=2;
            var b=23.9D;
            var c= true;
            var d="Hello";
            Console.Write("\n\n{0} ",a);
            Console.Write("{0} ",b);
            Console.Write("{0} ",c);
            Console.Write("{0} ",d);


        }
    }
}