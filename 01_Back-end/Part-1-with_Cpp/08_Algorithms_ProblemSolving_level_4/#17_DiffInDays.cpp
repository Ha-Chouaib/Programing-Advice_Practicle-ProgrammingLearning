#include<iostream>
using namespace std;

//write a programe Read tow Dayse and Check if Day1 Equals  Day2

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

bool IsDate1EqualDate2(stDate Date1, stDate Date2)
{   
    return (Date1.Year == Date2.Year && Date1.Month == Date2.Month && Date1.Day == Date2.Day);
}

bool IsLeapYear( short Year)
{
    return ((Year % 400 == 0 )|| (Year % 4 == 0 && Year % 100 !=0));
        
}

bool IsDate1BeforDate2(stDate Date1, stDate Date2)
{   
return (Date1.Year < Date2.Year) ? true : ((Date1.Year == Date2.Year) ? (Date1.Month < Date2.Month ? true : (Date1.Month == Date2.Month ? Date1.Day < Date2.Day : false)) : false );
}

short NumberOfDaysInMonth(short Year,short Month)
{
   short DaysOfMonth[12]={31,28,31,30,31,30,31,31,30,31,30,31};
   return ((Month == 2)? IsLeapYear(Year) ? 29 :28  : DaysOfMonth[Month-1]);

}

short TotalDaysFromBeginningOfYearYear(short Year,short Month,short Day)
{
    short TotDays=0;
    for(short i=1; i<=Month -1; i++)
    {
        TotDays+=NumberOfDaysInMonth(Year,i);
    } 

    return TotDays += Day;
}

short NumberOfDaysInYear(short Year)
{   
    return IsLeapYear(Year)? 366 :365;
}

//-> Method 1:
int DiffDaysBetweenTowDates(stDate Date1,stDate Date2,bool IncludingEndDay=false)
{   
    short TotDaysInDate1=0;
    short TotDaysInDate2=0;
    short Diff=0;
    if(IsDate1EqualDate2(Date1,Date2))
    {
        return Diff;
    }else
    {   

        TotDaysInDate1=TotalDaysFromBeginningOfYearYear(Date1.Year,Date1.Month,Date1.Day);
        TotDaysInDate2=TotalDaysFromBeginningOfYearYear(Date2.Year,Date2.Month,Date2.Day);
        if(Date1.Year == Date2.Year)
        { 
            Diff= TotDaysInDate1 - TotDaysInDate2;
        }
        else
        {   
            int YearsDiff= Date1.Year - Date2.Year;
            int NumberOfDaysBetweenYears=0;
            if(YearsDiff < 0)
                YearsDiff *= -1;
            
            for(int i=0; i<YearsDiff; i++)
            {
                Date1.Year ++;
                NumberOfDaysBetweenYears+= NumberOfDaysInYear(Date1.Year);
            }
            
            Diff=  NumberOfDaysBetweenYears + TotDaysInDate1 - TotDaysInDate2;
        }
    }
    return IsDate1BeforDate2(Date1,Date2)?  IncludingEndDay? (Diff * -1) +1 : Diff * -1 :IncludingEndDay? Diff +1: Diff;
}

//-->Method 2:

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

int GetDiffereceOfTowDates(stDate Date1,stDate Date2,bool IncludingEndDay=false)
{
    int DiffDays=0;
    stDate HigherDate=Date2;
    stDate LowestDate=Date1;
    if(!IsDate1BeforDate2(Date1,Date2))
    {
        HigherDate=Date1;
        LowestDate=Date2;
    }
    while (IsDate1BeforDate2(LowestDate,HigherDate))
    {
        DiffDays++;
        LowestDate=IncreaseDateByOneDay(LowestDate);
    }
    return IncludingEndDay? ++DiffDays : DiffDays;
    
}


int main()
{ 
    stDate Date1=ReadDate();
    cout<<endl;
    stDate Date2=ReadDate();

    printf("the Difference between Tow Dates is: [%d]\n",DiffDaysBetweenTowDates(Date1,Date2));
    printf("By Method 2: [%d]\n",GetDiffereceOfTowDates(Date1,Date2));
    printf("Including End Day: [%d]\n",GetDiffereceOfTowDates(Date1,Date2,true));
   

    return 0;
}