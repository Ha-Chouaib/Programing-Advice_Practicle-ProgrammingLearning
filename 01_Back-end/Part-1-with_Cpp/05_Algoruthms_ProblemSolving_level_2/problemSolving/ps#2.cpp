#include <iostream>
#include <cmath>
using namespace std;


//# Write a programe print all Prime numbers from 1 to N

enum enPrimeOrNot{Prinme=1, NotPrime=2};

float ReadPositiveNumber(string MSG){
    float Num=0;
    do{
        cout<< MSG <<endl;
        cin>> Num;
    }while(Num < 0);
    return Num;
}
enPrimeOrNot IsPrime(int Num){

    int HalfNum= round(Num/2);
   
    for(int i=2; i<=HalfNum; i++){

        if(Num % i == 0)
            return enPrimeOrNot::NotPrime;
    }

    return enPrimeOrNot::Prinme;
}
void ShowPrimeNumbersFrom1ToN(float Num){

    for(int i=1; i<=Num; i++){
        if(IsPrime(i) == enPrimeOrNot::NotPrime)
            continue;
        cout<< i <<endl;
        
    }
}

int main(){
    ShowPrimeNumbersFrom1ToN(ReadPositiveNumber("Add a Positive number:"));
    return 0;
}