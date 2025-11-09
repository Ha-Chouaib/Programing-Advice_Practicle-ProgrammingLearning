#include <iostream>
using namespace std;

//write a program that take a number and gives you an output that number as separate Digits. 

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

void NumToSeparateDigits(int Num){

    int Remainder=0;
    while(Num > 0){
        Remainder= Num %10;
        Num/= 10;
    
        cout<< Remainder <<endl;
        
    }
    
}


int main(){
    int Number= ReadPositiveNumber("Enter a positive number:");
    NumToSeparateDigits( ReverceDigits (Number) );
    return 0;
}