#include <iostream>
using namespace std;

//write a program check if the number is a balindrome.--> [12321]

float ReadPositiveNumber(string MSG){
    float Num=0;
    do{
        cout<< MSG <<endl;
        cin>> Num;
    }while(Num < 0);
    return Num;
}
int ReverceDigits(int Num){

    int Remainder=0, RevNum=0;
    while(Num > 0){
        Remainder= Num %10;
        Num/= 10;
        RevNum= RevNum * 10 + Remainder;
        
    }
    return RevNum;
}
bool IsBalindromeNumber(int Num){
    return Num == ReverceDigits(Num);
}
void ShowResult(){
    int Num=ReadPositiveNumber("Enter a positive number: ");
    if(IsBalindromeNumber(Num))
        cout<<Num << " Is a Balindrome number." <<endl;
    else
        cout<< Num <<" Not a Balindrome number!"<<endl;
}
int main(){

    ShowResult();

    return 0;
}

