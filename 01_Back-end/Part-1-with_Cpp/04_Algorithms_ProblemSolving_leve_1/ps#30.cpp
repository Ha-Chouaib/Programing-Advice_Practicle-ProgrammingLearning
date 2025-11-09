#include <iostream>
using namespace std;

int ReadPositiveNums(string MSG){

    int Num;
    do{
        cout<< MSG <<endl;
        cin>>Num;
    }while(Num < 0);
    
    return Num;
}

float Fctorial(int number){
    float Factor=1;
    for(int i=number; i>1; i--){

        Factor *=i;
    }
    return Factor;
}

int main(){

    cout<< Fctorial(ReadPositiveNums("enter a positive number:"))<<endl;
    return 0;
}