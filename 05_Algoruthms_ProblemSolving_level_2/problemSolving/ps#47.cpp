#include <iostream>
#include <cmath>
using namespace std;

//do your round() function same as C++ ones


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

int MyRoundResult(float Number)
{   
    int intPart= (int)Number;
    float FractionPart=GetFractionPart(Number);

       if(abs(FractionPart) >= .5)
       { 
            if(Number > 0)
                return intPart ++;
            else
                return intPart --;
       }else
        {
            return intPart;
        }

}


int main()
{   float Num= ReadNumber();

    cout<<"\nMy round function result is: "<<MyRoundResult(Num) <<endl;
    cout<<"\nC++ round result is: "<< round(Num)<<endl;

    return 0;
}