#include<iostream>
using namespace std;

//Write a program to print total days from the beginning of Year.
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

short TotalDaysFromBeginningOfYearYear(short Year,short Month,short Day)
{
    short TotDays=0;
    for(short i=1; i<=Month -1; i++)
    {
        TotDays+=NumberOfDaysInMonth(Year,i);
    } 

    return TotDays += Day;
}

int main()
{
    short Year=ReadNumber();
    short Month=ReadNumberInRange(1,12,"Please enter a month number");
    short Day=ReadNumberInRange(1,31,"Please enter a Day number");

    cout<<"Number Of Days From the begining of Year <<"<<Year<<">> is: [ "<<TotalDaysFromBeginningOfYearYear(Year,Month,Day)<<" ] Days."<<endl;

    return 0;
}