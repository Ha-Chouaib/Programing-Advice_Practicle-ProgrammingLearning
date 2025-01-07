#include <iostream>
using namespace std;

//write a program return a number with reverce Digits  [123]--->[321].

float ReadPositiveNumber(string MSG){
    float Num=0;
    do{
        cout<< MSG <<endl;
        cin>> Num;
    }while(Num < 0);
    return Num;
}

int ReverceDigits(int Num){

    int Remainder=0, RevNum=0;
    while(Num > 0){
        Remainder= Num %10;
        Num/= 10;
        RevNum= RevNum * 10 + Remainder;
        
    }
    return RevNum;
}

template<typename Param> // To keep the parameter type Dynamic "you can name it any"
void ShowResult(Param Result, string BeforMSG="",string AfterMSG="" ){

    cout<<endl << BeforMSG << Result<< AfterMSG <<endl;
}

int main(){

    ShowResult(ReverceDigits(ReadPositiveNumber("Add a Positive number: ")),"Number Reverce is: ");
    return 0;
}