#include<iostream>
using namespace std;

//write a program to read a date and print the day name of week.

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

void ShowDate(short Year,short Month,short Day)
{
    cout<<"The date: "<<Day<<"/"<<Month<<"/"<<Year<<endl;
}

short GetDayOrder(short Year,short Month,short Day)
{
    short A=0,Y=0,M=0,D=0;
    A=(14 -Month)/12;
    Y= Year - A;
    M= Month +(12 *A)-2;
    
    return (Day+Y+ (Y/4) - (Y/100) + (Y/400) + ((31*M)/12)) % 7; 
}

string GetDayName(short DayOrder)
{   
    string DayName[7]={"Sunday","Monday","Tuesday","Wednesday","Thursday","Friday","Saturday"};
    return DayName[DayOrder];

}

int main()
{
    short Year=ReadNumber();
    short Month=ReadNumberInRange(1,12,"Please enter a month number");
    short Day=ReadNumberInRange(1,31,"Please enter a Day number");
    cout<<endl;
    short DayOrder=GetDayOrder(Year,Month,Day);
    
    ShowDate(Year,Month,Day);
    cout<<"The Day Order: "<<DayOrder <<endl;
    cout<<"Day Name: "<<GetDayName(DayOrder)<<endl;


    return 0;
}