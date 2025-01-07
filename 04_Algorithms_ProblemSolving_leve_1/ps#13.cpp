#include <iostream>
using namespace std;


void ReadNumbers(short &num1, short &num2, short &num3){

    cout<<"Add the First number: ";
    cin>> num1;

    cout<<"enter the second number: ";
    cin>> num2;

    cout<<"enter the third number: ";
    cin>>num3;

}

short MaxOfNumbers(short num1, short num2, short num3){
    
    if(num1 > num2)
    {
        if(num1 > num3)
            return num1;
        else
            return num3;
    }
    else 
    {
        if(num2 > num3)
            return num2;
        else
            return num3;
    }   
    
}

void ShowResults(short MaxNumber){
    
        cout<<"The Maximum Number is: "<<MaxNumber <<endl;
}

int main(){
    short num1,num2, num3;
    ReadNumbers(num1, num2, num3);
    ShowResults(MaxOfNumbers(num1, num2, num3));

    return 0;
}