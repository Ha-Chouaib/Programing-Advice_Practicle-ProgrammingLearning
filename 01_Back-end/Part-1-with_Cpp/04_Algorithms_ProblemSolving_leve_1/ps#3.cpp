#include <iostream>
#include <string>
using namespace std;


enum enNumType{Odd=1, Even=2};

int ReadNum(){

    int number;
    cout<<"please enter the number: ";
    cin>> number;
    return number;
}

enNumType CheckNumType( int Num){

    int result = Num %2;
    if(result == 0)
        return enNumType::Even;
    else
        return enNumType::Odd ;
}

void ShowNumType(enNumType numType){

    if(numType == enNumType::Even)
        cout<<"the number is: Even number "<<endl;
    else
        cout<< "The number is: Odd number" <<endl;
}


int main(){

    ShowNumType(CheckNumType(ReadNum()));

    return 0;
}
