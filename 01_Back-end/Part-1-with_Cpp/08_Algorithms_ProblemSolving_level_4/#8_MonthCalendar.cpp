#include<iostream>
#include<iomanip>
using namespace std;

//write a program to Read The Year and Month Number then print a Month Calendar.

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

short GetDayOrder(short Year,short Month,short Day)
{
    short A=0,Y=0,M=0,D=0;
    A=(14 -Month)/12;
    Y= Year - A;
    M= Month +(12 *A)-2;
    
    return (Day+Y+ (Y/4) - (Y/100) + (Y/400) + ((31*M)/12)) % 7; 
}

short NumberOfDaysInMonth(short Year,short Month)
{
   short DaysOfMonth[12]={31,28,31,30,31,30,31,31,30,31,30,31};
   return ((Month == 2)? IsLeapYear(Year) ? 29 :28  : DaysOfMonth[Month-1]);

}

string GetMonthName(short MonthNumber)
{
    string MonthName[12]={"January","February","March","April","May","June","July","August","september","October","November","December"};
    return MonthName[MonthNumber -1];
}

void MonthCalender(short Year,short MonthNumber)
{
    printf("\n\n--------------%s--------------\n\n",GetMonthName(MonthNumber).c_str());
    printf("  Sun  Mon  Tue  Wed  Thu  Fri  Sat\n");

    short i;
    for(i=0; i<GetDayOrder(Year,MonthNumber,1); i++)
    {
        printf("     ");
    }
    for(short z=1; z<=NumberOfDaysInMonth(Year,MonthNumber); z++)
    {
        printf("%5d",z);

        if(++i == 7)
        {
            i=0;
            printf("\n");
        }
        
    }
    printf("\n------------------------------------\n");
    cout<<endl;
}

int main()
{
    short Year=ReadNumber();
    short Month=ReadNumberInRange(1,12,"Please enter a month number");
    MonthCalender(Year,Month);

    return 0;
}