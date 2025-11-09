#include <iostream>
using namespace std;
//write a program count all digits frequency in a number.

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

void AllDigitSFrequency(int Number){

    cout<< endl;
    for(int i=0; i<10; i++){

        short digitFrequency=0;
        digitFrequency = DigitFrequency(Number,i);

        if(digitFrequency > 0){

            cout<< " Digit frequency of "<< i <<" is "<<digitFrequency << " Time(s)"<<endl;
        }
    }

}

int main(){
    int Number= ReadPositiveNumber("Please enter a positive number:");
    AllDigitSFrequency(Number);

    return 0;
}