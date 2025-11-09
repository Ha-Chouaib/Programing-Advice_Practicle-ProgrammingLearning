#include <iostream>
#include <string>
using namespace std;

int ReadNumber(){
    int num= 0;
    cout<<"plesae enter a number: ";
    cin>> num;

    return num;
}

float Calculate_Half_Number(int Num){

    return (float)Num  / 2;
}

void DisplyResult(int Num){

    string result;
    result ="The Halfe of "+ to_string(Num) + " is: " + to_string(Calculate_Half_Number(Num));
    cout<<endl << result <<endl;

}

int main(){

    DisplyResult(ReadNumber());
    return 0;
}