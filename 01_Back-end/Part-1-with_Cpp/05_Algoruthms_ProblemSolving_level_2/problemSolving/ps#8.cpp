#include <iostream>
#include <string>
using namespace std;
//write a program that count How many time a Digit repeated within a number.

float ReadPositiveNumber(string MSG){
    float Num=0;
    do{
        cout<< MSG <<endl;
        cin>> Num;
    }while(Num < 0);
    return Num;
}

int DigitFrequency(int Number, short Digit){

    int Remainder=0, Frq=0;
    while(Number > 0){
        Remainder = Number % 10;
        Number/= 10;

        if(Remainder == Digit)
            Frq++;
    }
    return Frq;
}

template<typename Param> // To keep the parameter type Dynamic "you can name it any"
void ShowResult(Param Result, string BeforMSG="",string AfterMSG="" ){

    cout<<endl << BeforMSG << Result<< AfterMSG <<endl;
}

int main(){
    int Number;
    short Digit;
    Number= ReadPositiveNumber("enter the Number:");
    Digit = ReadPositiveNumber("enter the Digit:"); 
    ShowResult(DigitFrequency(Number, Digit), "The Digit is: ", " Time(s)" );
    return 0;
}