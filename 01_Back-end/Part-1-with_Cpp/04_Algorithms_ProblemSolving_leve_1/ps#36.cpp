#include <iostream>
using namespace std;

enum enOperationType{
    Add='+', Sbtruct= '-', Multiply= '*', Divide= '/'
};

float ReadNumber(string MSG){

    float Num=0;
    cout<<endl << MSG << endl;
    cin>>Num;

    return Num;
}

enOperationType OpeType(){

    char OpT;
    cout<<"please Add An operator [+\\-\\*\\/]: ";
    cin>> OpT;

    return  (enOperationType) OpT;
}

float CalcNumbers(float Num1, float Num2, enOperationType OpType){

    switch(OpType){

        case enOperationType::Add :
            return Num1 + Num2 ;
        case enOperationType::Sbtruct :
            return Num1 - Num2 ;
        case enOperationType::Multiply :
            return Num1 * Num2 ;
        case enOperationType::Divide :
            return Num1 / Num2;
        default :
            return Num1 + Num2;
    }
}

int main(){

    float Num1=ReadNumber("Add the first number: ");
    float Num2=ReadNumber("Add the second number: ");

    float Result=CalcNumbers(Num1, Num2, OpeType());
    cout<<"the result is: "<<Result<<endl;

    return 0;
}