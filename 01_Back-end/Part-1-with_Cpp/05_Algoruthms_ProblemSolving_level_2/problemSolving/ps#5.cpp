#include <iostream>
#include <string>
using namespace std;

//write a program that  Print a number in reverce Digits.

float ReadPositiveNumber(string MSG){
    float Num=0;
    do{
        cout<< MSG <<endl;
        cin>> Num;
    }while(Num < 0);
    return Num;
}

void PrintNumberInReverceDigits(int Num){

    int Remainder=0;
    while(Num> 0){
        Remainder = Num% 10;
        Num/= 10;
        cout<< Remainder <<endl;
    }
}
int main(){

    PrintNumberInReverceDigits(ReadPositiveNumber("Enter a number: "));
    return 0;
}