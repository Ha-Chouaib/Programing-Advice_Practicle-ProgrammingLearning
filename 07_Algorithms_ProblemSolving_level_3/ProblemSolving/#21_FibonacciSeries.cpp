#include<iostream>

using namespace std;
//-> write a program to print fibonacci series of 10.

void PrintFibonacci(short To)
{   
    short FibNumber=0;
    short Prev1=1,Prev2=0;

    cout<<"1    ";
    for(short i=1; i< To; i++)
    {
       FibNumber= Prev1 + Prev2;

       cout<< FibNumber <<"     ";
       Prev2=Prev1;
       Prev1=FibNumber;
      
    }
}

int main()
{
    PrintFibonacci(10);

    return 0;
}