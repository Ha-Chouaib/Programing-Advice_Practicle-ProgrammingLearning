#include <iostream>
using namespace std;

void ReadNumbers(short& num1, short& num2){

    cout<<"Add the first number: ";
    cin>>num1;

    cout<<"Add the second number: ";
    cin>>num2;
}

void SwapNumbers(short& num1, short& num2){

    short Temp;
    Temp= num1;
    num1= num2;
    num2= Temp;
}

void DisplayNumbers(short num1, short num2){

    cout<<"\nThe first number is: "<< num1 << endl;
    cout<<"The second number is: "<<num2 << endl;
}

int main(){

    short num1, num2;
    ReadNumbers(num1,num2);
    DisplayNumbers(num1,num2);
    SwapNumbers(num1,num2);
    DisplayNumbers(num1,num2);
    

    return 0;
}