#include <iostream>
using namespace std;

// write a program print a Letter Pattern.

float ReadPositiveNumber(string MSG){
    float Num=0;
    do{
        cout<< MSG <<endl;
        cin>> Num;
    }while(Num < 0);
    return Num;
}

void PrintLetterPattern(int Num){
    cout<<endl;
        
    for(int i= 65; i<65+Num; i++){
        
        for(int y=0; y < Num - (65 +Num -1 -i) ;y++){
            
            cout<< char(i) ;
        }
        cout<< endl;
        
    }
}
int main(){

    PrintLetterPattern(ReadPositiveNumber("Enter a positive number"));
    return 0;
}