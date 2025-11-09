#include<iostream>
using namespace std;

//Write a program to read a date and Check:
//-> if its day is the last one in the month.
//-->if its Month is the last one in the year.

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

short ReadNumber(string MSG)
{
    short num=0;
    cout<<MSG<<endl;
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

struct stDate{ short Day=0,Month=0,Year=0;};
stDate ReadDate()
{
    stDate Date;
    Date.Day=ReadNumberInRange(1,31,"Please enter a day:");
    Date.Month=ReadNumberInRange(1,31,"Please enter a Month:");
    Date.Year=ReadNumber("Plear Enter a Year:");

    return Date;
}


bool IsLastDayInMonth(stDate Date)
{
    return (NumberOfDaysInMonth(Date.Year ,Date.Month) == Date.Day);
}

bool IsLastMonthInYear(short Month)
{
    return(Month == 12);
}

int main()
{ 
    stDate Date=ReadDate();
    
    IsLastDayInMonth(Date)? printf("Yes : the Day << %d >> is the last day in the month\n",Date.Day) : printf("No : the Day << %d >> it's Npt the last day in the month\n",Date.Day);
    IsLastMonthInYear(Date.Month)? printf("Yes : the Month << %d >> is the last day in the Year\n",Date.Month) : printf("No : the Month << %d >> it's Npt the last Month in the Year\n",Date.Month);
    
    return 0;
}