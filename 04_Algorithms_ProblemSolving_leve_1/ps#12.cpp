#include <iostream>
using namespace std;
enum enIsEqual{Equal=0};
void ReadNumbers(short &num1, short &num2){

    cout<<"Add the First number: ";
    cin>> num1;

    cout<<"enter the second number: ";
    cin>> num2;

}

short MaxOfNumbers(short num1, short num2){

    if(num1 > num2)
        return num1;
    else if(num1 < num2)
        return num2;
    else 
        return enIsEqual::Equal;
}

void ShowResults(short MaxNumber){
    if(MaxNumber == enIsEqual::Equal)
        cout<<"The numbers are equal."<<endl;
    else
        cout<<"The Maximum Number is: "<<MaxNumber <<endl;
}

int main(){
    short num1,num2;
    ReadNumbers(num1, num2);
    ShowResults(MaxOfNumbers(num1, num2));

    return 0;
}