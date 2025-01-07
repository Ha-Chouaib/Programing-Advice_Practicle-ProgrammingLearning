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

float CalcRemainder(float TotBill, float TotCashPaid){
    return TotCashPaid - TotBill;
}

void DisplayRemainder(){

    float Totbill=0, TotCashPaid=0;
    Totbill= ReadPositiveNumber("Enter The Total Bill:");
    TotCashPaid= ReadPositiveNumber("Enter Total Cash paid:");

    cout<<"\n$$$$$$$$$$$$$$$$$$$$$$$$$\n";
    cout<<"The Remainder= "<<CalcRemainder(Totbill, TotCashPaid) <<endl;
}
int main(){

    DisplayRemainder();

    return 0;
}