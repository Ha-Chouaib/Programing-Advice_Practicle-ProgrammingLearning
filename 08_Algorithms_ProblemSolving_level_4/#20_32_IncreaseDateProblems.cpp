#include<iostream>
using namespace std;


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

struct stDate{ short Day=0,Month=0,Year=0;};
stDate ReadDate()
{
    stDate Date;
    Date.Day=ReadNumberInRange(1,31,"Please enter a day:");
    Date.Month=ReadNumberInRange(1,31,"Please enter a Month:");
    Date.Year=ReadNumber("Plear Enter a Year:");

    return Date;
}

bool IsLastDayInMonth(stDate Date)
{
    return (NumberOfDaysInMonth(Date.Year ,Date.Month) == Date.Day);
}

bool IsLastMonthInYear(short Month)
{
    return(Month == 12);
}

stDate IncreaseDateByOneDay(stDate Date)
{
    if(IsLastDayInMonth(Date))
    {
        Date.Day=1;
        if(IsLastMonthInYear(Date.Month))
        {
            Date.Month=1;
            Date.Year ++;
        }else
        {
            Date.Month +=1;
        }
    }else
    {
        Date.Day++;
    }
    return Date;
}

stDate IncreaseDateByXDays(stDate Date,short HowManyDaysToAdd)
{
    for(short i=0; i< HowManyDaysToAdd; i++)
    {
        Date= IncreaseDateByOneDay(Date);
    }
    return Date;
}

stDate IncreaseDateByOneWeek(stDate Date)
{
    return IncreaseDateByXDays(Date,7);
}

stDate IncreaseDateByXWeeks(stDate Date,short HowManyWeeksToAdd)
{
    for(short i=0; i<HowManyWeeksToAdd; i++)
    {
        Date=IncreaseDateByOneWeek(Date);
    }
    return Date;
}

stDate IncreaseDateByOneMonth(stDate Date )
{
    if(Date.Month == 12)
    {
        Date.Month=1;
        Date.Year++;
    }else
    {
        Date.Month++;
    }
    
    short DaysInMonth=0;
    DaysInMonth= NumberOfDaysInMonth(Date.Year,Date.Month);
    
    if(Date.Day > DaysInMonth)
    {
        Date.Day=DaysInMonth;
    }
    return Date;

}

stDate IncreaseDateByXMonths(stDate Date, short HowManyMonthToAdd)
{
    for(short i=0; i<HowManyMonthToAdd; i++)
    {
        Date=IncreaseDateByOneMonth(Date);
    }
    return Date;
}

stDate IncreaseDateByOneYear(stDate Date)
{
    Date.Year++;
    return Date;
}

stDate IncreaseDateByXYears(stDate Date, short HowManyYearsToAdd)
{
    for(short i=0; i<HowManyYearsToAdd; i++)
    {
        Date= IncreaseDateByOneYear(Date);
    }
    return Date;
}

stDate IncreaseDateByXYearsFaster(stDate Date, short HowManyYearsToAdd)
{
    Date.Year+=HowManyYearsToAdd;
    return Date;
}

stDate IncreaseDateByOneDecade(stDate Date)
{
    Date.Year+=10;
    return Date;
}

stDate IncreaseDateByXDecades(stDate Date, short HowManyDecatesToAdd)
{
    for(short i=0;i<HowManyDecatesToAdd ; i++)
    {
        Date= IncreaseDateByOneDecade(Date);
    }
    return Date;
}

stDate IncreaseDateByXDecadesFaster(stDate Date, short HowManyDecatesToAdd)
{
    Date.Year+= HowManyDecatesToAdd *10;
    return Date;
}

stDate IncreaseDateByOneCentury(stDate Date)
{
    Date.Year+= 100;
    return Date;
}

stDate IncreaseDateByOneMillennium(stDate Date)
{
    Date.Year+=1000;
    return Date;
}

int main()
{   
    stDate Date=ReadDate();
    stDate AddOneDay=IncreaseDateByOneDay(Date);
    stDate AddXDays=IncreaseDateByXDays(AddOneDay,10);
    stDate AddOneWeek=IncreaseDateByOneWeek(AddXDays);
    stDate AddXWeeks=IncreaseDateByXWeeks(AddOneWeek,10);
    stDate AddOneMonth=IncreaseDateByOneMonth(AddXWeeks);
    stDate AddXMonths=IncreaseDateByXMonths(AddOneMonth,5);
    stDate AddOneYear=IncreaseDateByOneYear(AddXMonths);
    stDate AddXYears=IncreaseDateByXYears(AddOneYear,10);
    stDate AddXYearsFaster=IncreaseDateByXYearsFaster(AddXYears,10);
    stDate AddOneDecade=IncreaseDateByOneDecade(AddXYearsFaster);
    stDate AddXDecades=IncreaseDateByXDecades(AddOneDecade,10);
    stDate AddXDecadesFaster=IncreaseDateByXDecadesFaster(AddXDecades,10);
    stDate AddOneCentury=IncreaseDateByOneCentury(AddXDecadesFaster);
    stDate AddOneMillennium=IncreaseDateByOneMillennium(AddOneCentury);
    
    printf("The Old Date: %d/%d/%d \n",Date.Day,Date.Month,Date.Year);
    cout<<"\nDate After:"<<endl;
    printf("Adding One Day is:   %d/%d/%d \n",AddOneDay.Day,AddOneDay.Month,AddOneDay.Year);
    printf("Adding 10 Days is:   %d/%d/%d \n",AddXDays.Day,AddXDays.Month,AddXDays.Year);
    printf("Adding One Week is:  %d/%d/%d \n",AddOneWeek.Day,AddOneWeek.Month,AddOneWeek.Year);
    printf("Adding 10 Weeks is:  %d/%d/%d \n",AddXWeeks.Day,AddXWeeks.Month,AddXWeeks.Year);
    printf("Adding One Month is: %d/%d/%d \n",AddOneMonth.Day,AddOneMonth.Month,AddOneMonth.Year);
    printf("Adding 5 Months is:  %d/%d/%d \n",AddXMonths.Day,AddXMonths.Month,AddXMonths.Year);
    printf("Adding One Year is:  %d/%d/%d \n",AddOneYear.Day,AddOneYear.Month,AddOneYear.Year);
    printf("Adding 10 Year is:   %d/%d/%d \n",AddXYears.Day,AddXYears.Month,AddXYears.Year);
    printf("Adding 10 Year (Faster) is:   %d/%d/%d \n",AddXYearsFaster.Day,AddXYearsFaster.Month,AddXYearsFaster.Year);
    printf("Adding one Decade is:   %d/%d/%d \n",AddOneDecade.Day,AddOneDecade.Month,AddOneDecade.Year);
    printf("Adding 10 Decades is:   %d/%d/%d \n",AddXDecades.Day,AddXDecades.Month,AddXDecades.Year);
    printf("Adding 10 Decades (Faster) is:   %d/%d/%d \n",AddXDecadesFaster.Day,AddXDecadesFaster.Month,AddXDecadesFaster.Year);
    printf("Adding One Century is:   %d/%d/%d \n",AddOneCentury.Day,AddOneCentury.Month,AddOneCentury.Year);
    printf("Adding One Century is:   %d/%d/%d \n",AddOneMillennium.Day,AddOneMillennium.Month,AddOneMillennium.Year);

    return 0;
}