#include<iostream>
using namespace std;

//Write a program to print number of days,hours,minutes,seconds in a sectain Month.
//!\ but do the numberofMonth function just in tow line of code
short ReadNumberInRange(short From, short To, string MSG)
{
    short num=0;
    do
    {
        cout<<MSG<<endl;
        cin>>num;   
    } while (num < From || num > To);
     
    return num;
}

short ReadNumber()
{
    short num=0;
    cout<<"Please Enter a Year: "<<endl;
    cin>>num;
    return num;
}

bool IsLeapYear( short Year)
{
    return ((Year % 400 == 0 )|| (Year % 4 == 0 && Year % 100 !=0));
        
}

short NumberOfDaysInMonth(short Year,short Month)
{
   short DaysOfMonth[12]={31,28,31,30,31,30,31,31,30,31,30,31};
   return ((Month == 2)? IsLeapYear(Year) ? 29 :28  : DaysOfMonth[Month-1]);

}

short NumberOfHoursInMonth(short Year, short Month)
{
    return NumberOfDaysInMonth(Year,Month) * 24;
}

int NumberOfMinutesInMonth(short Year, short Month)
{
    return NumberOfHoursInMonth(Year,Month) * 60;
}

int NumberOfSecondsInMonth(short Year, short Month)
{
    return NumberOfMinutesInMonth(Year,Month) * 60;
}

int main()
{ 
    short Year=ReadNumber();
    short Month=ReadNumberInRange(1,12,"Please entre a month number (1-->12)");

    cout<<"Number Of Days In Month << "<<Month<<" >> is: "<<NumberOfDaysInMonth(Year, Month) <<endl;
    cout<<"Number Of Hours In Month << "<<Month<<" >> is: "<<NumberOfHoursInMonth(Year, Month) <<endl;
    cout<<"Number Of Minutes In Month << "<<Month<<" >> is: "<<NumberOfMinutesInMonth(Year, Month) <<endl;
    cout<<"Number Of Seconds In Month << "<<Month<<" >> is: "<<NumberOfSecondsInMonth(Year, Month) <<endl;


    return  0;
}