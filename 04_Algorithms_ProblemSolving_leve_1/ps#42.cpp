#include <iostream>
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

stDuration ReadDurationinfo(){
    stDuration Duration;
    Duration.NumOfDays= ReadPositiveNumber("Ente Number Of Days:");
    Duration.NumOfHours= ReadPositiveNumber("Ente Number Of Hours:");
    Duration.NumOfMin= ReadPositiveNumber("Ente Number Of Minutes:");
    Duration.NumOfSec= ReadPositiveNumber("Ente Number Of Seconds:");

    return Duration;
}

int DuratinInSecond(stDuration Dur){

    int TotSeconds=0;
    TotSeconds =  Dur.NumOfDays * 24 *60 *60;
    TotSeconds+= Dur.NumOfHours *60 *60;
    TotSeconds+= Dur.NumOfMin *60;
    TotSeconds+= Dur.NumOfSec;
    return TotSeconds;
}

template<typename Param> // To keep the parameter type Dynamic "you can name it any"
void ShowResult(Param Result, string MSG=""){

    cout<<endl << MSG << Result <<endl;
}
int main(){
    int TotalSeconds= DuratinInSecond(ReadDurationinfo());
    ShowResult(TotalSeconds,"Total seconds is: ");
    return 0;
}