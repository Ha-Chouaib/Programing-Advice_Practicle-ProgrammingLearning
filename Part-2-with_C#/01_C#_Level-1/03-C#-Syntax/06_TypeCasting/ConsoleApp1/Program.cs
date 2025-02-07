using System;
namespace Main
{
    internal class Program
    {
        enum enWeekDays
        {
            Mon,Tus,Wed,Thu,Fri,Sat,sun
        }
        static void Main(string[] args)
        {
            /*
                Type Casting is Simply Converting a DataType Value To another Data Tyep
                and Ther are Tow Types Of Castings:

                => Implicit Casting < automatically >:
                    . Converting Small Type To Another is bigger.
                    --> char > int > long >float > double

                => Explicit Casting < Manually > :
                    . Converting Larger Type To smaller one.
                    --> double > float > long > int > char
            */

            //-----------------------Implicit Casting-----------------------
            int MyInt=67;
            double MyDouble= MyInt;
            Console.WriteLine(MyInt);//67
            Console.WriteLine(MyDouble);//67

            //-----------------------Explicit Casting-----------------------
            
            double Mydouble= 67.987;
            int Myint= (int) Mydouble;
            Console.WriteLine(Mydouble);//67.987
            Console.WriteLine(Myint);//67

            //------------------------Type Converting Methods----------------
            Console.WriteLine("\n\n");
            int intx=23;
            double doublex=67.24;
            bool boolx= true;

            Console.WriteLine(Convert.ToString(boolx));
            Console.WriteLine(Convert.ToString(intx));
            Console.WriteLine(Convert.ToDouble(intx));
            Console.WriteLine(Convert.ToInt32(doublex) );

            //-----------------------Casting Enums---------------------------
            Console.WriteLine("\n\n");

            Console.WriteLine(enWeekDays.Fri);//Fri
            int FriNum= (int) enWeekDays.Fri;
            Console.WriteLine(FriNum);//4

            var Day= (enWeekDays) 0;//Mon
            Console.WriteLine(Day);
            

        }
    }
}