#include <iostream>
#include <cmath>
using namespace std;

//do your ceil() function same as C++ ones

float ReadNumber(){
    float num= 0;
    cout<<"plesae enter a number: ";
    cin>> num;

    return num;
}

float GetFractionPart(float Number)
{
    return Number - (int)Number;
}

int MyCeilResult(float Number)
{   
    int intPart= (int)Number;
    float FractionPart=GetFractionPart(Number);

    if( FractionPart != 0)
    {
        if(Number > 0)
            return intPart +1;
        else
            return intPart ;
    }else
    {
        return intPart;
    }
}


int main()
{   float Num= ReadNumber();

    cout<<"\nMy Ceil function result is: "<<MyCeilResult(Num) <<endl;
    cout<<"\nC++ Ceil result is: "<< ceil(Num)<<endl;

    return 0;
}