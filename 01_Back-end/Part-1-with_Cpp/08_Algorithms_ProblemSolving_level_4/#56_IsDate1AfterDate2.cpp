#include<iostream>
using namespace std;

//write a programe Read tow Dayse and Check if Day1 After Than Day2

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

bool IsDate1AfterDate2(stDate Date1, stDate Date2)
{
    return (!IsDate1BeforDate2(Date1,Date2) && !IsDate1EqualDate2(Date1,Date2));   
}

int main()
{ 
    stDate Date1=ReadDate();
    cout<<endl;
    stDate Date2=ReadDate();
    if(IsDate1AfterDate2(Date1,Date2))
    {
        cout<<"Yes Date 1 is After Date 2"<<endl;
    }else
    {
        cout<<"No Date 1 is not After Date 2"<<endl;
    }
    return 0;
}