#include <iostream>
#include <cmath>
using namespace std;

//# write a program Check if the number is a perfect one or not. 

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

void ShowResult(int Num){

    if(IsPerfectNumber(Num))
        cout<<Num <<" is Perfect Number."<<endl;
    else 
        cout<<Num <<" Not a perfect Number"<<endl;
}

int main(){

    ShowResult(ReadPositiveNumber("Please a Positive number to check if it's a Perfet number or not:"));
    return 0;
}
