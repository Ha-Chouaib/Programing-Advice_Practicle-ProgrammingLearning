#include <iostream>
using namespace std;

// Integer formating.

int main()
{
    int x=11, y=2;
    printf("the number x= %d and y= %d\n",x,y);

    printf("I can countrole the width of  the number: %0*d \n",2,x); // how many degits you want the number to be
    printf("I can countrole the width of  the number: %0*d \n",10,x);
    printf("I can countrole the width of  the number: %0*d \n",8,x);
    printf("I can countrole the width of  the number: %0*d \n",6,x);

    printf("the sum of %d and %d =%d\n",x,y, x+y);// for the calculation

    return 0;
}