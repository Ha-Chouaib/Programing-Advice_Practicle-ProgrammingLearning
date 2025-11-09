#include <iostream>
using namespace std;

//write a program print Number Pattern.

float ReadPositiveNumber(string MSG){
    float Num=0;
    do{
        cout<< MSG <<endl;
        cin>> Num;
    }while(Num < 0);
    return Num;
}

void PrintNumberPattern(int Num){
    cout<<endl;
    for(int i=1; i<=Num; i++){

        for(int y=0; y < i ;y++){
            
            cout<< i ;
        }
        cout<< endl;
    }
}
int main(){

    PrintNumberPattern(ReadPositiveNumber("Enter a positive number: "));

    return 0;
}