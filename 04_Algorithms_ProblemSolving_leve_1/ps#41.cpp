#include <iostream>
using namespace std;

float ReadPositiveNumber(string MSG){
    float Num=0;
    do{
        cout<< MSG <<endl;
        cin>> Num;
    }while(Num < 0);
    return Num;
}

float HoursToDays(float NumOfHours){

    float HtD= NumOfHours /24;
    return HtD;
}

float HourstoWeeks(float NumOfHours){
    float HtW= NumOfHours /12 /7;
    return HtW;
}

float DaysToWeek(float NumOfDays){
    float DtW= NumOfDays /7;
    return DtW;
}

template<typename Param> // To keep the parameter type Dynamic "you can name it any"
void ShowResult(Param Result, string MSG=""){

    cout<<endl << MSG << Result <<endl;
}

int main(){
    float NumOfHours= ReadPositiveNumber("Enter Number of Hours:");  
    float NumOfDays= HoursToDays(NumOfHours);
    float NumOfWeeks= DaysToWeek(NumOfDays);
    ShowResult(NumOfHours, "Number Of hours is: ");
    ShowResult(NumOfDays, "Number Of Days is: ");
    ShowResult(NumOfWeeks, "Number Of Weeks is: ");

    return 0;
}