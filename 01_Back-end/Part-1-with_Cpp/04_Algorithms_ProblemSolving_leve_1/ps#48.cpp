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

float MonthlyIntallment(float LoanAmount, float HowMonthNeeded){

        return (float) LoanAmount / HowMonthNeeded;
}

template<typename Param> // To keep the parameter type Dynamic "you can name it any"
void ShowResult(Param Result, string BeforMSG="",string AfterMSG="" ){

    cout<<endl << BeforMSG << Result<< AfterMSG <<endl;
}
int main(){
    float LoanAmount= ReadPositiveNumber("Enter th Loan Amount:");
    float HowMonthNeeded= ReadPositiveNumber("How Many month you need:");
    ShowResult(MonthlyIntallment(LoanAmount, HowMonthNeeded),"you should pay "," Per month");

    return 0;
}