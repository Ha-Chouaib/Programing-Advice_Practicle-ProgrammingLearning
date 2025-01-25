#include<iostream>
#include <ctime>

using namespace std;


int main()
{
    time_t t= time(0);

    tm* stNow= localtime(&t);

    cout<<"Year: "<<stNow->tm_year +1900 <<endl;//--> must add 1900 becuase the date start by default from it
    cout<<"Month: "<<stNow->tm_mon + 1 <<endl;//--> add also 1 because it start from 0
    cout<<"Day"<<stNow->tm_mday <<endl;
    cout<<"Hour"<<stNow->tm_hour <<endl;
    cout<<"Minutes: "<<stNow->tm_min <<endl;
    cout<<"Seconds: "<<stNow->tm_sec <<endl;
    cout<<"Week Day: "<<stNow->tm_wday <<endl;
    cout<<"year Day: "<<stNow->tm_yday <<endl;
    cout<<"Hours of daylight savings time: "<<stNow->tm_isdst <<endl; //--> check if the hour has been increased by 1hour for winter time.
     


    return 0;
}