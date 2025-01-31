#include <iostream>
using namespace std;

//# write a program print all perfect numbers from 1 to N.
float ReadPositiveNumber(string MSG){
    float Num=0;
    do{
        cout<< MSG <<endl;
        cin>> Num;
    }while(Num < 0);
    return Num;
}

bool IsPerfectNumber(int Num){
    int result=0;
    for(int i=1; i<Num; i++){

        if(Num % i == 0)
            result+= i;
        
    }
    return Num == result;
}

void ChekPerfectNumbersFrom1ToN(int Num_N){
     
     for(int i=1; i<= Num_N; i++){

        if(IsPerfectNumber(i))
            cout<< i <<endl;
        
     }
}
int main(){

    ChekPerfectNumbersFrom1ToN(ReadPositiveNumber("Enter a Positive number:"));
    return 0;
}