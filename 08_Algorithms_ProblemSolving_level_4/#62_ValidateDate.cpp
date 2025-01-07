#include<iostream>
using namespace std;

//write a programe Read a Date And Create a fuction to Validate this date.

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
    Date.Day= ReadNumber("Please enter a Day");//ReadNumberInRange(1,31,"Please enter a day:");
    Date.Month= ReadNumber("Pleae enter a month");//ReadNumberInRange(1,12,"Please enter a Month:");
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


bool IsValidDate(stDate Date)
{
    return ((Date.Day<=NumberOfDaysInMonth(Date.Year,Date.Month)&& Date.Day>0) && (Date.Month>0 && Date.Month <=12));
}

int main()
{   stDate Date=ReadDate();

    IsValidDate(Date)? printf("\nYes: Date is Valid \n") :printf("\nNo: Date is Not Valid\n");
    return 0;
}