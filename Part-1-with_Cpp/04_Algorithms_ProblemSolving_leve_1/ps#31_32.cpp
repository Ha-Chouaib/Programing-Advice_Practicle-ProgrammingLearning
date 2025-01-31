#include <iostream>
#include <string>
using namespace std;


short ReadNumber(){

    short num;
    cout<< "Enter a number: ";
    cin>>num;
     return num;
}
short ReadPower(){
    short Pow;
    cout<<"please enter the power: ";
    cin>>Pow;
    return Pow;
}

int PowOfNumber(short number, short Power){

    if(Power == 0)
        return 1;
    int Result=1;
    for(int i=1; i<= Power; i++){
        Result*=number;
    }

    return Result;
    
}

int main(){

    cout<< endl<< "The result is: " <<PowOfNumber(ReadNumber(),ReadPower())<<endl;
    return 0;
}