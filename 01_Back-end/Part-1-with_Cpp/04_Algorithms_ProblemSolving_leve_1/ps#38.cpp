#include <iostream>
using namespace std;
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

    int HalfNum= Num/2;

    for(int i=2; i<=HalfNum; i++){

        if(Num % i == 0)
            return enPrimeOrNot::NotPrime;
    }

    return enPrimeOrNot::Prinme;
}
void DisplayNumbertype(float Num){

    switch (IsPrime(Num))
    {
    case enPrimeOrNot::Prinme :
        cout<< "Is a prime Number."<<endl;
        break;
    case enPrimeOrNot::NotPrime :
        cout<<"Is not a prome number."<<endl;
        break;
    
    
    }

}
int main(){

     DisplayNumbertype(ReadPositiveNumber("Add a Positive Number:"));
    return 0; 
}