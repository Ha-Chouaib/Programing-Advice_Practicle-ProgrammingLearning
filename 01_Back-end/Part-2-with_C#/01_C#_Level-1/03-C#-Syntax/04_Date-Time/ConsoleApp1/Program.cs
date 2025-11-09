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
            Console.WriteLine("\n\n");
            
            DateTime dtn=new DateTime();
            dtn=DateTime.Now;
            Console.WriteLine("The Current Date: {0}",dtn);

            //..................Ticks.................
            /*
                
                # The DateTime Stucture in .net uses ticks to repesent time internally.
                # the Number of Ticks represent the elapsed time Since << Jan 1,0001(Midnight),UTC >>
                # A Tick is : the smallest Unit of time in .net used internally by "DateTime" and "DateSpan".
                    its Like a super tiny fraction of second.

                * 1Tick= 100 nanoseconds=0.0001 millisecond =0.0000001 second.
                * 1 Millisecond= 10,000 ticks.
                * 1 second= 10,000,000 ticks.

            */
            Console.WriteLine("\n\n");

            Console.WriteLine("Current Ticks: {0}",DateTime.Now.Ticks);
            Console.WriteLine("Min Value of Ticks: {0}",DateTime.MinValue.Ticks);
            Console.WriteLine("Max Value of Ticks: {0}",DateTime.MaxValue.Ticks);


            //.................Date Time Static field............................
            Console.WriteLine("\n\n");
            DateTime CurrentDateTime= DateTime.Now;
            DateTime TodaysDate= DateTime.Today;
            DateTime CurrentDateTimeUTC= DateTime.UtcNow;
            DateTime MaxDateTimeValue=DateTime.MaxValue;
            DateTime MinDateTimeValue=DateTime.MinValue;

            Console.WriteLine("Current Date and Time: "     + CurrentDateTime);
            Console.WriteLine("Todays Date: "               + TodaysDate);
            Console.WriteLine("Current Date and Time UTC: " + CurrentDateTimeUTC);
            Console.WriteLine("Max Date Time Value: "       + MaxDateTimeValue);
            Console.WriteLine("Min Date Time Value: "       + MinDateTimeValue);
            

            //...............................Time Span...........................
            //it Used To represent Time in: Hour, Minutes, Seconds and Milliseconds
            Console.WriteLine("\n\n");

            DateTime _DT=new DateTime(2025,1,10);
            Console.WriteLine("Date" + _DT);

            //set Hours, Min, Sec in TimeSpan

            TimeSpan TS= new TimeSpan(56,60,24);
            Console.WriteLine("Time Span: " + TS);
            Console.WriteLine("Time Span Days: " + TS.Days);
            Console.WriteLine("Time Span Hours: " + TS.Hours);
            Console.WriteLine("Time Span Minutes: " + TS.Minutes);
            Console.WriteLine("Time Span Seconds: " + TS.Seconds);

            //Add TimeSpan To Date.
            DateTime Newdate= _DT.Add(TS);
            Console.WriteLine("New Date " + Newdate);

            //........................Substruction of Tow dates.....................
            Console.WriteLine("\n\n");
            DateTime _DT1=new DateTime(2003,6,20);
            DateTime _DT2=new DateTime(2025,2,6);
            TimeSpan SUbResult= _DT2.Subtract(_DT1);

            Console.WriteLine("Date 1" + _DT1);
            Console.WriteLine("Date 2" + _DT2);
            Console.WriteLine("Date2 - Date1 = " + SUbResult);
            

            //......................Operators......................................
            Console.WriteLine("\n\n");

            DateTime D1=new DateTime(2001,12,31);
            DateTime D2=new DateTime(2004,12,5,5,10,23);
            TimeSpan T=new TimeSpan(20,33,43);
            Console.WriteLine("Date 1: " + D1);
            Console.WriteLine("Date 2: " + D2);
            Console.WriteLine(D2 + T);//12/6/2004 1:44:06 AM
            Console.WriteLine(D2 > D1);//True
            Console.WriteLine(D2 < D1);//False
            Console.WriteLine(D2 == D1);//False
            Console.WriteLine(D2 >= D1);//True
            Console.WriteLine(D2 <= D1);//False

            //....................Convert String To Date...........................
            /*
            A valid date and time string can be converted to a DateTime object using:
                Parse(), ParseExact(), TryParse() and TryParseExact() methods.

            The Parse() and ParseExact() methods will throw an exception if 
                the specified string is not a valid representation of a date and time.
                So, it's recommended to use TryParse() or TryParseExact() method because they return false if a string is not valid.
            */
            Console.WriteLine("\n\n");

            var str = "6/12/2023";
            DateTime dt;

            var isValidDate = DateTime.TryParse(str, out dt);

            if (isValidDate)
                Console.WriteLine(dt);
            else
                Console.WriteLine($"{str} is not a valid date string");

            //invalid string date
            var str2 = "6/65/2023";
            DateTime dt2;

            var isValidDate2 = DateTime.TryParse(str2, out dt2);

            if (isValidDate2)
                Console.WriteLine(dt2);
            else
                Console.WriteLine($"{str2} is not a valid date string");

        }
    }
}