#include <iostream>
#include <cmath>
using namespace std;

//do your sqrt() function same as C++ ones

float ReadNumber(){
    float num= 0;
    cout<<"plesae enter a number: ";
    cin>> num;

    return num;
}



float MySqrtFunction(float Number)
{   
    return pow(Number, .5);
}


int main()
{   float Num= ReadNumber();

    cout<<"\nMy MySqrtFunction function result is: "<<MySqrtFunction(Num) <<endl;
    cout<<"\nC++ sqrt result is: "<< sqrt(Num)<<endl;

    return 0;
}