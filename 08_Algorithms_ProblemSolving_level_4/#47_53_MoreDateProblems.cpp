#include<iostream>
#include<ctime>
using namespace std;

struct stDate
{
    short Day=0;
    short Month=0;
    short Year=0;
};

stDate GetCurrentDate()
{
    stDate Date;

    time_t t= time(0);
    tm * CurrTm= localtime(&t);

    Date.Day=CurrTm->tm_mday;
    Date.Month= CurrTm->tm_mon +1;
    Date.Year=CurrTm->tm_year + 1900;

    return Date;
}

bool IsLeapYear( short Year)
{
    return ((Year % 400 == 0 )|| (Year % 4 == 0 && Year % 100 !=0));
        
}

short GetDayOrder(short Year,short Month,short Day)
{
    short A=0,Y=0,M=0,D=0;
    A=(14 -Month)/12;
    Y= Year - A;
    M= Month +(12 *A)-2;
    
    return (Day+Y+ (Y/4) - (Y/100) + (Y/400) + ((31*M)/12)) % 7; 
}

short GetDayOrder(stDate Date)
{
    return GetDayOrder( Date.Year, Date.Month, Date.Day); 
}

short NumberOfDaysInMonth(short Year,short Month)
{
   short DaysOfMonth[12]={31,28,31,30,31,30,31,31,30,31,30,31};
   return ((Month == 2)? IsLeapYear(Year) ? 29 :28  : DaysOfMonth[Month-1]);

}

short NumberOfDaysInYear(short Year)
{   
    return IsLeapYear(Year)? 366 :365;
}

short GetTotalDaysFromBeginningOfYear(short Year,short Month,short Day)
{
    short TotDays=0;
    for(short i=1; i<=Month -1; i++)
    {
        TotDays+=NumberOfDaysInMonth(Year,i);
    } 

    return TotDays += Day;
}

string GetDayName(short DayOrder)
{
    string DayName[7]={"Sun","Mon","Tue","Wed","Thu","Fri","Sat"};
    return DayName[DayOrder];
}

void ShowCurrentDate(stDate Date, string DayName)
{   
    
    printf("Today is:[ %s ]-> < %d/%d/%d >\n",DayName.c_str(),Date.Day,Date.Month,Date.Year);
}

bool IsEndOfWeek( short DayOrder)
{
    return DayOrder == 0;
}

bool IsWeekEnd(short DayOrder)
{
    return (DayOrder == 6 || DayOrder == 0);
}

bool IsbusinessDay(short DayOrder)
{
    return (!IsWeekEnd(DayOrder));
}

short DaysUntilTheEndOfWeek(short DayOrder)
{   
    if(DayOrder==0)
        DayOrder=7;
    return 7-DayOrder;
}

short DaysUntilTheEndOfMonth(stDate Date)
{
    return NumberOfDaysInMonth(Date.Year,Date.Month) - Date.Day;
}

short DaysUntilTheEndOfYear(stDate Date)
{
    return NumberOfDaysInYear(Date.Year) - GetTotalDaysFromBeginningOfYear(Date.Year,Date.Month,Date.Day);
}

void ShowIsEndOfWeekResult(short DayOrder)
{
    printf("\n\nIs it End Of Week?\n");
    IsEndOfWeek(DayOrder)? printf("Yes: The Day is End Of Week.\n") : printf("No: The Day is Not End Of Week.\n");
}

void ShowIsWeekEndResult(short DayOrder)
{
    printf("\n\nIs it WeekEnd?\n");
    IsWeekEnd(DayOrder)?printf("Yes: It's a Weekend\n") : printf("No:It is Not a Weekend\n");
}

void ShowIsBusinessDay(short DayOrder)
{
    printf("\n\nIs Business Day?\n");
    IsbusinessDay(DayOrder)? printf("Yes: It's a businees Day\n") : printf("No:It is Not a Business day\n");  
}

void ShowDaysUntilEndOfWeek(short DayOrder)
{
    printf("\nDays Until the End Of Week is [%d]\n",DaysUntilTheEndOfWeek(DayOrder));
}

void ShowDaysUntilEndOfMonth(stDate Date)
{
    printf("Days Until the End Of Month is [%d]\n",DaysUntilTheEndOfMonth(Date));
}

void ShowDaysUntilEndOfYear(stDate Date)
{
    printf("Days Until the End Of Year is [%d]\n",DaysUntilTheEndOfYear(Date));
}

int main()
{
    stDate Date=GetCurrentDate();
    short DayOrder=GetDayOrder(Date);
    string DayName=GetDayName(DayOrder);
    ShowCurrentDate(Date,DayName);

    ShowIsEndOfWeekResult(DayOrder);
    ShowIsWeekEndResult(DayOrder);
    ShowIsBusinessDay(DayOrder);
    
    ShowDaysUntilEndOfWeek(DayOrder);
    ShowDaysUntilEndOfMonth(Date);
    ShowDaysUntilEndOfYear(Date);

    return 0;
}