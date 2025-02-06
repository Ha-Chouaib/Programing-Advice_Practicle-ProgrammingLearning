using System;

namespace Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //............Set Date....................
            DateTime DT1= new DateTime();// assign the default value (01/01/0001 00:00:00)
            DateTime DT2= new DateTime(2002,3,21);//assign Year, Month, Day
            DateTime DT3= new DateTime(2002,2,22,12,30,45);//Assign Year/Month/Day/Hour/Min/Sec
            DateTime DT4= new DateTime(2002,2,22,12,30,45, DateTimeKind.Utc); //Datetime Kind

            Console.WriteLine(DT1);
            Console.WriteLine(DT2);
            Console.WriteLine(DT3);
            Console.WriteLine(DT4);

            //............Get Current Date............
            DateTime dtn=new DateTime();
            dtn=DateTime.Now;
            Console.WriteLine("The Current Date: {0}",dtn);


        }
    }
}