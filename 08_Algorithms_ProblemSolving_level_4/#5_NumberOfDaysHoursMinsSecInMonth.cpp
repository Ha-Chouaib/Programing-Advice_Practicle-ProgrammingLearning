#include<iostream>
using namespace std;

//Write a program to print number of days,hours,minutes,seconds in a sectain Month.
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
   if(Month == 2)
   {
     return IsLeapYear(Year)? 29 :28;
   }

   short Month31Days[7]={1,3,5,7,8,10,12};
   for(short i=1; i<=7; i++)
   {
        if(Month31Days[i-1] == Month)
            return 31;
   }
   return 30;
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