#include <iostream>
#include <cmath>
using namespace std;

struct stDuration {
    int NumOfDays, NumOfHours, NumOfMin, NumOfSec;
};
float ReadPositiveNumber(string MSG){
    float Num=0;
    do{
        cout<< MSG <<endl;
        cin>> Num;
    }while(Num < 0);
    return Num;
}

stDuration SecondsToDurations(int TotSeconds)
{
    stDuration Durations;

    const int SecondsPerDays  = 24 *60 *60;
    const int SecondsPerHours = 60 *60;
    const int SecondsPerMin   = 60;

    int Remainder= 0;

    Durations.NumOfDays  = floor(TotSeconds / SecondsPerDays);
    Remainder= TotSeconds % SecondsPerDays;
    Durations.NumOfHours = floor(Remainder / SecondsPerHours);
    Remainder%= SecondsPerHours;
    Durations.NumOfMin   = floor(Remainder / SecondsPerMin);
    Remainder%= SecondsPerMin; 
    Durations.NumOfSec   = Remainder;

    return Durations;
}  

void ShowTheClock(stDuration Durations){

    cout<< endl ;
    cout<<Durations.NumOfDays  <<":"
        <<Durations.NumOfHours <<":"
        <<Durations.NumOfMin   <<":"
        <<Durations.NumOfSec   <<endl;
}

int main(){

    int TotalSeconds= ReadPositiveNumber("Enter the number of Seconds you have:");
    ShowTheClock(SecondsToDurations(TotalSeconds));

    return 0;
}