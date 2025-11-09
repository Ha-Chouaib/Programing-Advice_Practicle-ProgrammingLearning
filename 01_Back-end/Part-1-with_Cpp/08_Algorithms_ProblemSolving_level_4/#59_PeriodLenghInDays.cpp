#include<iostream>
using namespace std;

//write a programe Read a Periods and Calculate its lenght in Days.

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

struct stPeriod
{
    stDate StartDate;
    stDate EndDate;
};

stDate ReadDate()
{
    stDate Date;
    Date.Day=ReadNumberInRange(1,31,"Please enter a day:");
    Date.Month=ReadNumberInRange(1,31,"Please enter a Month:");
    Date.Year=ReadNumber("Plear Enter a Year:");

    return Date;
}

stPeriod ReadPeriod()
{
    stPeriod Period;
    cout<<"Start Date:\n";
    Period.StartDate=ReadDate();
    cout<<"\nEnd Date:\n";
    Period.EndDate=ReadDate();
    
    return Period;
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

int GetPeriodLength(stPeriod Period,bool IncludingEndDay=false)
{
    return GetDiffereceOfTowDates(Period.StartDate,Period.EndDate,IncludingEndDay);
}


int main()
{   
    cout<<"Period[1]\n";
    stPeriod Period=ReadPeriod();
    
    printf("\nThe Period Length is [%d]\n",GetPeriodLength(Period));
    printf("\nThe Period Length (Including End day) is [%d]\n",GetPeriodLength(Period,true));

    return 0;
}