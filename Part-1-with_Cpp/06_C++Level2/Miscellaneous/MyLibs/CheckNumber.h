#pragma once
#include <iostream>
#include <cmath>
#include "HandlNumbers.h"

using namespace std;
using namespace HandlNum;

namespace CheckNum
{
    
    bool IsPrime(int Num){

        int HalfNum= round(Num/2);
    
        for(int i=2; i<=HalfNum; i++){

            if(Num % i == 0)
                return 0;
        }

        return 1;
    }

    bool IsPerfectNumber(int Num){
        int result=0;
        for(int i=1; i<Num; i++){

            if(Num % i == 0)
                result+= i;
        }
        return Num == result;
    }

    bool IsBalindromeNumber(int Num)
    {   // exampl: 123321
    return Num == ReverceDigits(Num);

    }
    
    bool IsOddNumber(short Number){

    if(Number % 2 ==0)
        return 0;
    else
        return 1;
    
}

}