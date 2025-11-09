#include <iostream>
#include <string>
using namespace std;

int ReadTotalSales(){

    int TotalSales;
    cout<<"Enter total sales: ";
    cin>>TotalSales;

    return TotalSales;
}

float GetComisionPercentage(int TotSales){

    if(TotSales >= 1000000)
        return 0.01;
    else if(TotSales >= 500000)
        return 0.02;
    else if(TotSales >= 100000)
        return 0.03;
    else if(TotSales >= 50000)
        return 0.05;
    else
        return 0.00;

}

float CalculateTotComission(float TotSal){
    return GetComisionPercentage(TotSal) * TotSal;
}

void DisplayResult(float TotComission){
    cout<<"The total comission is: "<<TotComission <<endl;
}
int main(){

    DisplayResult(CalculateTotComission(ReadTotalSales()));

    return 0;
}