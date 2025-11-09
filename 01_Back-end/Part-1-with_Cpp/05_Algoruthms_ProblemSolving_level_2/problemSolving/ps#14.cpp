#include <iostream>
using namespace std;

//write a program that print Inverted Letter Pattern.

float ReadPositiveNumber(string MSG){
    float Num=0;
    do{
        cout<< MSG <<endl;
        cin>> Num;
    }while(Num < 0);
    return Num;
}

void PrintInvertedLetterPattern(int Num){
    cout<<endl;
        
    for(int i= 65+Num -1; i>=65; i--){
        
        for(int y=0; y < Num - (65 +Num -1 -i) ;y++){
            
            cout<< char(i) ;
        }
        cout<< endl;
        
    }
}
int main(){

    PrintInvertedLetterPattern(ReadPositiveNumber("Enter a positive number"));
    return 0;
}