#include <iostream>
using namespace std;

// a pointer (*) it's just a variable (countainer) that can store just the [ADDRESS] another normal variable
//---> it gives you full access to th RAM and access any thing inside it.

int main()
{
    int a=10;
    string b="any";

    cout<<"a value: "<< a <<endl;
    cout<<"a Address: "<< &a <<endl;

    int * P= &a;//--> Referencing
    cout<<"Pointer[P] Value: "<< P <<endl;
    cout<<endl;
    
    string * x= &b;
    cout<<"b value: "<< b <<endl;
    cout<<"b Address: "<<&b<<endl;
    cout<<"Pointer[x] value: "<< x <<endl;
    cout<<endl;

    string D="Change your path";
    x=&D; // Here you tell to the pointer [x] change your direction to [D] Address instead of [b]s.
     cout<<"D value: "<< D <<endl;
     cout<<"D Adress: "<<&D <<endl;

     cout<<"Pointer[x] Value: "<< x <<endl;





    return 0;
}