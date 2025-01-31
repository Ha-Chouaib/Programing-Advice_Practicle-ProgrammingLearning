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

float TotalBillAfterFeeAndTaxes(float TotalBill){
    TotalBill*= 1.1;
    TotalBill*=1.16;
    return TotalBill;
}

void ShowNewTotBill(float OldTotBill){

    cout<<"Total bill= "<<OldTotBill <<endl;
    cout<<"\n******************************\n";
    cout<<"Total bill after fee and taxe= "<<TotalBillAfterFeeAndTaxes(OldTotBill) <<endl;
    cout<<"******************************\n";
}
int main(){

    ShowNewTotBill(ReadPositiveNumber("Add the total bill: "));
    return 0;
}