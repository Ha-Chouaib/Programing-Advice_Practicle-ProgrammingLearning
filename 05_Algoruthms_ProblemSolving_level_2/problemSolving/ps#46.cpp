#include<iostream>
#include <cmath>
using namespace std;
//do your abs() function same as C++ ones

float ReadNumber(){
    float num= 0;
    cout<<"plesae enter a number: ";
    cin>> num;

    return num;
}

float ToAbsoluteNum(float Number)
{
    
    if(Number >= 0)
        return Number;
    else
        return Number * -1;

}

int main()
{   
    float Number=ReadNumber();
    
    cout<<"\nMy absolute number= "<<ToAbsoluteNum(Number) <<endl;
    cout<<"\n C++ ABS = "<<  abs(Number) << endl;



    return 0;
}