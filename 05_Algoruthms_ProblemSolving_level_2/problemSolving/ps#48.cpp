#include <iostream>
#include <cmath>
using namespace std;

//do your floor() function same as C++ ones


float ReadNumber(){
    float num= 0;
    cout<<"plesae enter a number: ";
    cin>> num;

    return num;
}

int MyFloorResult(float Number)
{   
    int intPart= (int)Number;

    if(Number > 0)
        return intPart;
    else
        return intPart -1;
}


int main()
{   float Num= ReadNumber();

    cout<<"\nMy Floor function result is: "<<MyFloorResult(Num) <<endl;
    cout<<"\nC++ Floor result is: "<< floor(Num)<<endl;

    return 0;
}