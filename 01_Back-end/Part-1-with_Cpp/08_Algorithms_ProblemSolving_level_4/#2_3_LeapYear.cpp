#include <iostream>
using namespace std;

//Write a program to check if the year is a leap year or not;
//!\ All Years which are perfecty divisible by 4 are leap year.
//->Except for centry years those ending by 00 which are leap years if they only divisible by 400.

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

int main()
{
    short Year=ReadNumber();
    IsLeapYear(Year)? cout<<"<<"<<Year<<">> Is a leap Year"<<endl : cout<<"<<"<<Year<<">> Not a leap Year"<<endl;
}