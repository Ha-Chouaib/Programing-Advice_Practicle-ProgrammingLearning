#include <iostream>
using namespace std;

//Write a program to read a date and read also how many days add to it
 // then print the resul on the screen.

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

bool IsLeapYear( short Year)
{
    return ((Year % 400 == 0 )|| (Year % 4 == 0 && Year % 100 !=0));
        
}

short NumberOfDaysInMonth(short Year,short Month)
{
   short DaysOfMonth[12]={31,28,31,30,31,30,31,31,30,31,30,31};
   return ((Month == 2)? IsLeapYear(Year) ? 29 :28  : DaysOfMonth[Month-1]);

}

short TotalDaysFromBeginningOfYear(short Year,short Month,short Day)
{
    short TotDays=0;
    for(short i=1; i<=Month -1; i++)
    {
        TotDays+=NumberOfDaysInMonth(Year,i);
    } 

    return TotDays += Day;
}

struct stDate
{
    short NewYear=0;
    short NewMonth=0;
    short NewDays=0;

};

stDate AddDaysToDate(short Year,short Month,short Day,short AddDays)
{
    stDate Date;
    short RemainingDays=AddDays + TotalDaysFromBeginningOfYear(Year,Month,Day);
    short DaysFoMonth=0;

    Date.NewYear=Year;
    Date.NewMonth=1;
    while (true)
    {   DaysFoMonth= NumberOfDaysInMonth(Date.NewYear,Date.NewMonth);

        if(RemainingDays > DaysFoMonth)
        {
            Date.NewMonth++;
            RemainingDays-=DaysFoMonth;

            if(Date.NewMonth > 12)
            {
                Date.NewYear+=1;
                Date.NewMonth=1;
            }
        }else
        {
            Date.NewDays=RemainingDays;
            break;
        }
    }
    return Date;
    
}
int main()
{
    short Year=ReadNumber("please enter a Year:");
    short Month=ReadNumberInRange(1,12,"Please enter a month number:");
    short Day=ReadNumberInRange(1,31,"Please enter a Day number:");
    short HowManyDaysToAdd=ReadNumber("please enter how many days to add:");

    stDate UpdatedDate=AddDaysToDate(Year,Month,Day,HowManyDaysToAdd);

    printf("The Updated Date is: %d/%d/%d\n",UpdatedDate.NewDays,UpdatedDate.NewMonth,UpdatedDate.NewYear);


    return 0;
}