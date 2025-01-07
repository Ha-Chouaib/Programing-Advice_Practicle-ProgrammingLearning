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

float TotalMonth(float LoanAmount, float monthlyInstallment){

        return (float) LoanAmount / monthlyInstallment;
}

template<typename Param> // To keep the parameter type Dynamic "you can name it any"
void ShowResult(Param Result, string BeforMSG="",string AfterMSG="" ){

    cout<<endl << BeforMSG << Result<< AfterMSG <<endl;
}
int main(){
    float LoanAmount= ReadPositiveNumber("Enter thr Loan Amount:");
    float MonthlyInstallment= ReadPositiveNumber("Add the monthly installment:");
    ShowResult(TotalMonth(LoanAmount, MonthlyInstallment),""," Month Needed To Pay");

    return 0;
}