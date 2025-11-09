#include<iostream>
using namespace std;

//Write a program to read vacation period DateFrom and DateTo and make a function to
//Calculate the actual vacation days.


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

bool IsDate1BeforDate2(stDate Date1, stDate Date2)
{   
return (Date1.Year < Date2.Year) ? true : ((Date1.Year == Date2.Year) ? (Date1.Month < Date2.Month ? true : (Date1.Month == Date2.Month ? Date1.Day < Date2.Day : false)) : false );
}

void ShowVacationStartAndEndDate(stDate StartDate,string StartDayName,stDate EndDate,string EndDayName)
{
    printf("\n\nVacation Starts from: [%s] %d/%d/%d\n",StartDayName.c_str(),StartDate.Day,StartDate.Month,StartDate.Year);
    printf("Vacation Ends in: [%s] %d/%d/%d\n",EndDayName.c_str(),EndDate.Day,EndDate.Month,EndDate.Year);
}

bool IsWeekEnd(short DayOrder)
{
    return (DayOrder == 5 || DayOrder == 6);
}

short GetActualVacation(stDate DateFrom, stDate DateTo)
{
    short ActualVac=0;
    short DayOrder=0;
    
    while(IsDate1BeforDate2(DateFrom,DateTo))
    {   
        
        DayOrder=GetDayOrder(DateFrom);
        if(!IsWeekEnd(DayOrder))
            ActualVac ++;
        DateFrom=IncreaseDateByOneDay(DateFrom);
         
    }
    return ActualVac;
}

int main()
{
    printf("Vacation Starts:\n");
    stDate DateFrom=ReadDate();
    printf("\nVacation ends:\n");
    stDate DateTo=ReadDate();

    string StartDayName=GetDayName(GetDayOrder(DateFrom));
    string EndDayName=GetDayName(GetDayOrder(DateTo));

    ShowVacationStartAndEndDate(DateFrom,StartDayName,DateTo,EndDayName);

    printf("\nActual Vacation is: [%d]\n",GetActualVacation(DateFrom,DateTo));
    
    return 0;
}
