#include<iostream>
using namespace std;

//write a programe Read a Periods and a Date then Check if the date within the period or not.

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

bool IsDate1BeforDate2(stDate Date1, stDate Date2)
{   
return (Date1.Year < Date2.Year) ? true : ((Date1.Year == Date2.Year) ? (Date1.Month < Date2.Month ? true : (Date1.Month == Date2.Month ? Date1.Day < Date2.Day : false)) : false );
}

bool IsDate1EqualDate2(stDate Date1, stDate Date2)
{   
    return (Date1.Year == Date2.Year && Date1.Month == Date2.Month && Date1.Day == Date2.Day);
}

enum enCompareDates{Befor=-1, Equal=0, After=1};
enCompareDates CompareDates(stDate Date1,stDate Date2)
{
    return IsDate1BeforDate2(Date1,Date2)? enCompareDates::Befor :IsDate1EqualDate2(Date1,Date2)? enCompareDates::Equal : enCompareDates::After;
}
bool IsDateInPeriod(stPeriod Period, stDate Date)
{
    return (CompareDates(Date,Period.StartDate)== enCompareDates::After && CompareDates(Date,Period.EndDate)==enCompareDates::Befor);
}
int main()
{   
    cout<<"Enter Period\n";
    stPeriod Period=ReadPeriod();
    cout<<"\n\nEnter a date"<<endl;
    stDate Date=ReadDate();

    IsDateInPeriod(Period,Date)? printf("\nYes: Date is within the period.\n"):printf("\nNo: Date is Not within the period.\n");

    return 0;
}