#include <iostream>
#include <cmath>
using namespace std;

enum enOddOrEven{Odd=1, Even=2};

short ReadNumber(){

    short num;
    cout<<"please enter the number: ";
    cin>>num;

    return num;
}


enOddOrEven IsOddNumber(short Number){

    if(Number % 2 ==0)
        return enOddOrEven::Even;
    else
        return enOddOrEven::Odd;
    
}

int SumOfOddNumbers(short Num){

    int Sum=0;
    
    for(int i= 0; i<Num; i++){
        if(IsOddNumber(i)==enOddOrEven::Odd){
            Sum+=i;
        }
    }

    return Sum;
}

void ShowResults(int OddSum){
    cout<<"Sum of odd Numbers result is: "<< OddSum<<endl;
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
    ShowResults(SumOfOddNumbers(ReadNumber()));
    
    return 0;
}