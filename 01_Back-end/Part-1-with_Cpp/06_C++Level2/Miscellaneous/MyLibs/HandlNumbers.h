#pragma once
#include <iostream>
#include <cmath>
using namespace std;

namespace HandlNum
{
    
int GetDigitsSum(int Num)
    {
        int Remaindre=0;
        int Result= 0;
        while(Num > 0){
            Remaindre= Num % 10;
            Num/=10;
            Result+= Remaindre; 
        }

        return Result;
    }

int ReverceDigits(int Num)
    {
        int Remainder=0, RevNum=0;
        while(Num > 0){
            Remainder= Num %10;
            Num/= 10;
            RevNum= RevNum * 10 + Remainder;

        }
        return RevNum;
    }

int DigitFrequency(int Number, short Digit)
    {
        int Remainder=0, Frq=0;
        while(Number > 0){
            Remainder = Number % 10;
            Number/= 10;

            if(Remainder == Digit)
                Frq++;
        }
        return Frq;
    }

void SwapNumbers(int& num1, int& num2){

    short Temp;
    
    Temp= num1;
    num1= num2;
    num2= Temp;
}

}