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

stDate DecreaseDateByOneDay(stDate Date)
{
    if(Date.Day==1)
    {   
        if(Date.Month!=1)
        {
            Date.Month--;
        }else
        {
            Date.Month=12;
            Date.Year--;
        } 
        Date.Day=NumberOfDaysInMonth(Date.Year,Date.Month);
    }else
    {
        
        Date.Day--;
    }
    return Date;
}

stDate DecreaseDateByXDays(stDate Date,short HowManyDaysToAdd)
{
    for(short i=0; i< HowManyDaysToAdd; i++)
    {
        Date= DecreaseDateByOneDay(Date);
    }
    return Date;
}

stDate DecreaseDateByOneWeek(stDate Date)
{
    return DecreaseDateByXDays(Date,7);
}

stDate DecreaseDateByXWeeks(stDate Date,short HowManyWeeksToAdd)
{
    for(short i=0; i<HowManyWeeksToAdd; i++)
    {
        Date=DecreaseDateByOneWeek(Date);
    }
    return Date;
}

stDate DecreaseDateByOneMonth(stDate Date )
{
    if(Date.Month == 1)
    {
        Date.Month=12;
        Date.Year--;
    }else
    {
        Date.Month--;
    }
    
    short DaysInMonth=0;
    DaysInMonth= NumberOfDaysInMonth(Date.Year,Date.Month);
    
    if(Date.Day > DaysInMonth)
    {
        Date.Day=DaysInMonth;
    }
    return Date;

}

stDate DecreaseDateByXMonths(stDate Date, short HowManyMonthToAdd)
{
    for(short i=0; i<HowManyMonthToAdd; i++)
    {
        Date=DecreaseDateByOneMonth(Date);
    }
    return Date;
}

stDate DecreaseDateByOneYear(stDate Date)
{
    Date.Year--;
    return Date;
}

stDate DecreaseDateByXYears(stDate Date, short HowManyYearsToAdd)
{
    for(short i=0; i<HowManyYearsToAdd; i++)
    {
        Date= DecreaseDateByOneYear(Date);
    }
    return Date;
}

stDate DecreaseDateByXYearsFaster(stDate Date, short HowManyYearsToAdd)
{
    Date.Year-=HowManyYearsToAdd;
    return Date;
}

stDate DecreaseDateByOneDecade(stDate Date)
{
    Date.Year-=10;
    return Date;
}

stDate DecreaseDateByXDecades(stDate Date, short HowManyDecatesToAdd)
{
    for(short i=0;i<HowManyDecatesToAdd ; i++)
    {
        Date= DecreaseDateByOneDecade(Date);
    }
    return Date;
}

stDate DecreaseDateByXDecadesFaster(stDate Date, short HowManyDecatesToAdd)
{
    Date.Year-= HowManyDecatesToAdd *10;
    return Date;
}

stDate DecreaseDateByOneCentury(stDate Date)
{
    Date.Year-= 100;
    return Date;
}

stDate DecreaseDateByOneMillennium(stDate Date)
{
    Date.Year-=1000;
    return Date;
}

int main()
{   
    stDate Date=ReadDate();
    stDate SubstructOneDay= DecreaseDateByOneDay(Date);
    stDate SubXDays=        DecreaseDateByXDays(SubstructOneDay,10);
    stDate SubOneWeek=      DecreaseDateByOneWeek(SubXDays);
    stDate SubXWeeks=       DecreaseDateByXWeeks(SubOneWeek,10);
    stDate SubOneMonth=     DecreaseDateByOneMonth(SubXWeeks);
    stDate SubXMonths=      DecreaseDateByXMonths(SubOneMonth,5);
    stDate SubOneYear=      DecreaseDateByOneYear(SubXMonths);
    stDate SubXYears=       DecreaseDateByXYears(SubOneYear,10);
    stDate SubXYearsFaster= DecreaseDateByXYearsFaster(SubXYears,10);
    stDate SubOneDecade=    DecreaseDateByOneDecade(SubXYearsFaster);
    stDate SubXDecades=     DecreaseDateByXDecades(SubOneDecade,10);
    stDate SubXDecadesFaster=DecreaseDateByXDecadesFaster(SubXDecades,10);
    stDate SubOneCentury=   DecreaseDateByOneCentury(SubXDecadesFaster);
    stDate SubOneMillennium= DecreaseDateByOneMillennium(SubOneCentury);
    
    printf("The Old Date: %d/%d/%d \n",Date.Day,Date.Month,Date.Year);
    cout<<"\nDate After:"<<endl;
    printf("SubstrucDe One Day is:   %d/%d/%d \n",SubstructOneDay.Day,SubstructOneDay.Month,SubstructOneDay.Year);
    printf("SubstrucDe 10 Days is:   %d/%d/%d \n",SubXDays.Day,SubXDays.Month,SubXDays.Year);
    printf("SubstrucDe One Week is:  %d/%d/%d \n",SubOneWeek.Day,SubOneWeek.Month,SubOneWeek.Year);
    printf("SubstrucDe 10 Weeks is:  %d/%d/%d \n",SubXWeeks.Day,SubXWeeks.Month,SubXWeeks.Year);
    printf("SubstrucDe One Month is: %d/%d/%d \n",SubOneMonth.Day,SubOneMonth.Month,SubOneMonth.Year);
    printf("SubstrucDe 5 Months is:  %d/%d/%d \n",SubXMonths.Day,SubXMonths.Month,SubXMonths.Year);
    printf("SubstrucDe One Year is:  %d/%d/%d \n",SubOneYear.Day,SubOneYear.Month,SubOneYear.Year);
    printf("SubstrucDe 10 Year is:   %d/%d/%d \n",SubXYears.Day,SubXYears.Month,SubXYears.Year);
    printf("SubstrucDe 10 Year (Faster) is:   %d/%d/%d \n",SubXYearsFaster.Day,SubXYearsFaster.Month,SubXYearsFaster.Year);
    printf("SubstrucDe one Decade is:   %d/%d/%d \n",SubOneDecade.Day,SubOneDecade.Month,SubOneDecade.Year);
    printf("SubstrucDe 10 Decades is:   %d/%d/%d \n",SubXDecades.Day,SubXDecades.Month,SubXDecades.Year);
    printf("SubstrucDe 10 Decades (Faster) is:   %d/%d/%d \n",SubXDecadesFaster.Day,SubXDecadesFaster.Month,SubXDecadesFaster.Year);
    printf("SubstrucDe One Century is:   %d/%d/%d \n",SubOneCentury.Day,SubOneCentury.Month,SubOneCentury.Year);
    printf("SubstrucDe One Milennium is:   %d/%d/%d \n",SubOneMillennium.Day,SubOneMillennium.Month,SubOneMillennium.Year);

    return 0;
}