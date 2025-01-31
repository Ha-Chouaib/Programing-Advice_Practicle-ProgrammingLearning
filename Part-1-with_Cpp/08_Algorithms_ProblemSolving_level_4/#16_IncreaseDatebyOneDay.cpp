#include<iostream>
using namespace std;

//wrie a program read a date then Increase this date by one Day.

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

stDate IncreaseDateByOneDay(stDate Date)
{
    if(IsLastDayInMonth(Date))
    {
        Date.Day=1;
        if(IsLastMonthInYear(Date.Month))
        {
            Date.Month=1;
            Date.Year ++;
        }else
        {
            Date.Month +=1;
        }
    }else
    {
        Date.Day++;
    }
    return Date;
}

int main()
{   
    stDate Date=ReadDate();
    stDate NewDate=IncreaseDateByOneDay(Date);
    
    printf("The Old Date: %d/%d/%d \n",Date.Day,Date.Month,Date.Year);
    printf("The Date After InCreasing One Day: %d/%d/%d \n",NewDate.Day,NewDate.Month,NewDate.Year);

    return 0;
}