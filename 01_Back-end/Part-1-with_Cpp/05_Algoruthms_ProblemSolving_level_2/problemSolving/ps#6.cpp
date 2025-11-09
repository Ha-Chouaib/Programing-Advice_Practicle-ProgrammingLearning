#include <iostream>
using namespace std;

//# write a program that returns the Sum of a number digits.

float ReadPositiveNumber(string MSG){
    float Num=0;
    do{
        cout<< MSG <<endl;
        cin>> Num;
    }while(Num < 0);
    return Num;
}

int GetDigitsSum(int Num){

    int Remaindre=0;
    int Result= 0;
    while(Num > 0){
        Remaindre= Num % 10;
        Num/=10;
        Result+= Remaindre; 
    }

    return Result;
    
}

template<typename Param> // To keep the parameter type Dynamic "you can name it any"
void ShowResult(Param Result, string BeforMSG="",string AfterMSG="" ){

    cout<<endl << BeforMSG << Result<< AfterMSG <<endl;
}

int main(){
    int Number=ReadPositiveNumber("Please enter apositive number:");
    ShowResult(GetDigitsSum(Number),"Digits sum Is: ");

    return 0;
}