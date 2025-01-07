#include <iostream>
using namespace std;

//write a program print Iverted Number Pattern.

float ReadPositiveNumber(string MSG){
    float Num=0;
    do{
        cout<< MSG <<endl;
        cin>> Num;
    }while(Num < 0);
    return Num;
}

void PrintInvertedNumberPattern(int Num){
    cout<<endl;
    for(int i=Num; i>=1; i--){

        for(int y=0; y < i ;y++){
            
            cout<< i ;
        }
        cout<< endl;
    }
}
int main(){
    
    int Num=ReadPositiveNumber("enter a positive number:");
    PrintInvertedNumberPattern(Num);

    return 0;
}