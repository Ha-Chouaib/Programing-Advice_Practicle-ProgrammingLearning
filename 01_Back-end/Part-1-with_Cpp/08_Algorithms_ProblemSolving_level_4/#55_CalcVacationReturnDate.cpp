#include<iostream>
using namespace std;

//Write a program to read vacation period DateFrom and Vacation Period then  make a function to
// Return the Vacation End date.


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

struct stDate{ short Day=0,Month=0,Year=0;};

stDate ReadDate()
{
    stDate Date;
    Date.Day=ReadNumberInRange(1,31,"Please enter a day:");
    Date.Month=ReadNumberInRange(1,31,"Please enter a Month:");
    Date.Year=ReadNumber("Plear Enter a Year:");

    return Date;
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

string GetDayName(short DayOrder)
{
    string DayName[7]={"Sun","Mon","Tue","Wed","Thu","Fri","Sat"};
    return DayName[DayOrder];
}

bool IsLastDayInMonth(stDate Date)
{
    return (NumberOfDaysInMonth(Date.Year ,Date.Month) == Date.Day);
}

bool IsLastMonthInYear(short Month)
{
    return(Month == 12);
}

bool IsDate1BeforDate2(stDate Date1, stDate Date2)
{   
return (Date1.Year < Date2.Year) ? true : ((Date1.Year == Date2.Year) ? (Date1.Month < Date2.Month ? true : (Date1.Month == Date2.Month ? Date1.Day < Date2.Day : false)) : false );
}

bool IsWeekEnd(short DayOrder)
{
    return (DayOrder == 5 || DayOrder == 6);
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

stDate IncreaseDateByXDays(stDate Date,short HowManyDaysToAdd)
{
    for(short i=0; i< HowManyDaysToAdd; i++)
    {
        Date= IncreaseDateByOneDay(Date);
    }
    return Date;
}

stDate GetVacationEndDate(stDate StartDate, short VacationDays)
{   
    stDate EndDate;
    EndDate= IncreaseDateByXDays(StartDate,VacationDays);

    short DayOrder=0;
    while(IsDate1BeforDate2(StartDate,EndDate))
    {
        DayOrder= GetDayOrder(StartDate);
        if(IsWeekEnd(DayOrder))
            EndDate=IncreaseDateByOneDay(EndDate);
        StartDate=IncreaseDateByOneDay(StartDate);
        
    }
    return EndDate;
    
}

void ShowVacationEndDate(stDate EndDate,string EndDayName)
{
    printf("Vacation Ends in: [%s] %d/%d/%d\n",EndDayName.c_str(),EndDate.Day,EndDate.Month,EndDate.Year);
}

int main()
{
    printf("Vacation Starts:\n");
    stDate DateFrom=ReadDate();
    
    short VacationPeriod=0;
    VacationPeriod=ReadNumber("Please enter a vacation Period?");
    stDate DateEnd=GetVacationEndDate(DateFrom,VacationPeriod);
    ShowVacationEndDate(DateEnd,GetDayName(GetDayOrder(DateEnd)));

    return 0;
}
