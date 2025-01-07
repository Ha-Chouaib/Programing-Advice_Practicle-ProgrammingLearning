#include <iostream>
using namespace std;

//-> write a program to print fibonacci series of 10 with Recursion.

void FibonacciRec(short To,short Prev1,short Prev2)
{  short FibNum=0;
     if(To >0)
    {   FibNum= Prev1 + Prev2;
        cout<< FibNum <<"   ";
        Prev2=Prev1;
        Prev1=FibNum;
        FibonacciRec(To-1,Prev1,Prev2);
    }


}

int main()
{  
    FibonacciRec(10,0,1);

    return 0;
}