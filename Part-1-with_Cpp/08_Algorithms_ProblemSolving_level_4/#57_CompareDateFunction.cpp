#include<iostream>
using namespace std;

//write a programe Read tow Dayse and Make a function that Compare if the Dates are Equal
//  Day1 After Than Day2 or the opposite.

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
int main()
{ 
    stDate Date1=ReadDate();
    cout<<endl;
    stDate Date2=ReadDate();
    
    printf("\n\nCompare Result [%d]\n",CompareDates(Date1,Date2));
    return 0;
}