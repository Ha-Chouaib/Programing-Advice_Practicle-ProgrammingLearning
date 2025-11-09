#include <iostream>
using namespace std;


int main ()
{   
    int a=10,b=9;
    int *p= &a;// --> Referencing

    cout<<"a value: "<< a<<endl;
    cout<<"a Address: "<< &a<<endl;
    cout<< "The pointer of [a]= "<< p <<endl;
    cout<<"The value of[a] using the pointer: "<< *p;

    cout<< endl;
    cout<< endl;

    *p=100;//---> we call it Dereferencing. /!\ the Value of a using the pointer.

    cout<< "a Value after changing with pointer: "<< a <<endl;
    cout<< *p <<endl;

    a=1000;

    cout<<"value of a aftre changing it using \"a\" itself " << *p <<endl;
    cout<< endl;
    return 0;
}