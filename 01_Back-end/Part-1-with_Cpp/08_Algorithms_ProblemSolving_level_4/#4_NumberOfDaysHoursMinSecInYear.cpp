#include<iostream>
using namespace std;

//Write a program to print number of Day ,Hours,Minutes,Seconds in a Given Year.

short ReadNumber()
{
    short num=0;
    cout<<"Enter a number: "<<endl;
    cin>>num;
    return num;
}

bool IsLeapYear( short Year)
{
    return ((Year % 400 == 0 )|| (Year % 4 == 0 && Year % 100 !=0));
        
}

short NumberOfDaysInYear(short Year)
{   
    return IsLeapYear(Year)? 366 :365;
}

int NumberOfHoursInYear(short Year)
{
    return NumberOfDaysInYear(Year) * 24;
}

int NumberOfMinutesInYear(short Year)
{
    return NumberOfHoursInYear(Year) *60;
}

int NumberOfSecondsInYear(short Year)
{
    return NumberOfMinutesInYear(Year) * 60;
}
int main()
{   
    short Year=ReadNumber();

    cout<<"Number Of Days In Year << "<<Year<<" >> is: "<<NumberOfDaysInYear(Year) <<endl;
    cout<<"Number Of Hours In Year << "<<Year<<" >> is: "<<NumberOfHoursInYear(Year) <<endl;
    cout<<"Number Of Minutes In Year << "<<Year<<" >> is: "<<NumberOfMinutesInYear(Year) <<endl;
    cout<<"Number Of Seconds In Year << "<<Year<<" >> is: "<<NumberOfSecondsInYear(Year) <<endl;

    return 0;
}