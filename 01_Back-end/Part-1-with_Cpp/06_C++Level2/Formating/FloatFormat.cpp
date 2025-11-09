#include <iostream>
using namespace std;

// float and double formating.

int main()
{
    float PI=3.14159265;

    printf("Pecision spesification: %.*f\n",2,PI);// how many Degits After the point
    printf("Pecision spesification: %.*f\n",4,PI);
    printf("Pecision spesification: %.*f\n",5,PI);
    printf("Pecision spesification: %.*f\n",1,PI);

    float x=7.0,y=2.3;
    printf("float Devision of %.4f and %.4f Is: %.3f \n",x,y, x/y);

    return 0;
}