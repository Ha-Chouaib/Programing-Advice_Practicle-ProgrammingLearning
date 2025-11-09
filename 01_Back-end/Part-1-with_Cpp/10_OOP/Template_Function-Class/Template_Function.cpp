#include<iostream>
using namespace std;

template<typename T> T Sum( T Num1, T Num2)
{
    return (T) Num1 + Num2;
}

int main()
{
    short ShortNum1= 10;
    short ShortNum2= 20;

    double DoubleNum1=98.835385;
    double DoubleNum2=2.835385;

    cout<<"Short Sum Result"<<Sum(ShortNum1,ShortNum2);
    cout<<"Double Sum Result"<<Sum(DoubleNum1,DoubleNum2);
    //It Makes The Function Dynamic Accept Any Data Type.
}