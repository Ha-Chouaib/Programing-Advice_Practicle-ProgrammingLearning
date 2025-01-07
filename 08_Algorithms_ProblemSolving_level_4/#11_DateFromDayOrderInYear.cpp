#include<iostream>
#include<cmath>
using namespace std;

//Write a program to print total days from the beginning of Year.
//-> then get the total days and convert back that result to Order date.

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

short GetTotalDaysFromBeginningOfYear(short Year,short Month,short Day)
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

//Mehtod 1:
void ConvertTotalDaysToDate(short TotDays,short Year)
{
    short DaysInYear=NumberOfDaysInYear(Year);
    short MonthsInTotDays= ceil((12 * TotDays)/DaysInYear) ;

    short DaysInMonths=0;
    for(short i=1; i<=MonthsInTotDays; i++)
    {
        DaysInMonths+=NumberOfDaysInMonth(Year,i);
    }
    short Day= TotDays - DaysInMonths;

    printf("\nThe Date is %d/%d/%d\n",Day,MonthsInTotDays + 1,Year);

}

//Method 2:
struct stDate
{
    short Days=0;
    short Month=0;
    short Year=0;
};
stDate GetDateFromTotalDaysInYear(short TotDays,short Year)
{
    stDate Date;
    short DaysOfMonth=0;
    short RemainingDays=TotDays;

    Date.Year=Year;
    Date.Month=1;

    while (true)
    {
        DaysOfMonth=NumberOfDaysInMonth(Year,Date.Month);
        if(RemainingDays > DaysOfMonth)
        {
            RemainingDays -= DaysOfMonth;
            Date.Month++;
        }else
        {
            Date.Days=RemainingDays;
            break;
        }
    }
    return Date;
}

int main()
{
    short Year=ReadNumber();
    short Month=ReadNumberInRange(1,12,"Please enter a month number");
    short Day=ReadNumberInRange(1,31,"Please enter a Day number");
    short TotalDaysFromBeginningOfYear=GetTotalDaysFromBeginningOfYear(Year,Month,Day);

    cout<<"\nNumber Of Days From the begining of Year <<"<<Year<<">> is: [ "<< TotalDaysFromBeginningOfYear<<" ] Days."<<endl;
    
    //solotion with 1st Method:
    ConvertTotalDaysToDate(TotalDaysFromBeginningOfYear,Year);

    //solotion with 2nd Method:
    stDate Date;
    Date=GetDateFromTotalDaysInYear(TotalDaysFromBeginningOfYear,Year);

    cout<<"The Date is: "<<Date.Days<<"/"<<Date.Month<<"/"<<Date.Year<<endl;
    return 0;
}