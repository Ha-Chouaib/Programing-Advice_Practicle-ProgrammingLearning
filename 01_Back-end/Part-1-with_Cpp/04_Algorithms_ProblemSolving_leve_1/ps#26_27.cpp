#include <iostream>
#include <cmath>
using namespace std;

short ReadNumber(){

    short num;
    cout<<"please enter the number: ";
    cin>>num;

    return num;
}

void PrintRange_1ToN(short Number, bool Reverce){

    if(Reverce){
        for(int i=Number ; i>= 1; i-- ){

            cout<< i <<endl;
        }
    }else{
        for(int i=1 ; i<= Number; i++ ){

            cout<< i <<endl;
        }
    }
    
}

int main(){

    PrintRange_1ToN(ReadNumber(), false);
    return 0;
}