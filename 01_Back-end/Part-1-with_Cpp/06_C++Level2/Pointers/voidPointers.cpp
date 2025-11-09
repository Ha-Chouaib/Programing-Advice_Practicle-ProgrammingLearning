#include <iostream>
using namespace std;


int main()
{
    void * ptr; //--> it's a generic pointer. you can point it at any type of variables you wants.

    int a=23;
    float f=4.4;
    char c='o';

    ptr= &a;
    cout<< "[a] Value: "<< a <<endl;
    cout<< "[a] Address: "<< &a <<endl;
    cout<< "[a] Address using the pointer: "<< ptr <<endl;

    cout<<endl;
    cout<<endl;
    
//Here you point to deferent type of variable whith the same pointer
    ptr=&f;
    cout<< "[f] Value: "<< f <<endl;
    cout<< "[f] Address: "<< &f <<endl;
    cout<< "[f] Address using the pointer: "<< ptr <<endl;

    cout<<endl;
    cout<<endl;

    ptr=&c;
    cout<< "[c] Value: "<< c <<endl;
    cout<< "[c] Address: "<< &c <<endl;
    cout<< "[c] Address using the pointer: "<< ptr <<endl;

    cout<<endl;
    cout<<endl;
//But if we want access the values using the pointer we have to use:
//# *(static_cast<Data Type*>(pointer name)). instead of (*ptr) because the pointer is GENERIC he don't now who is he.

    ptr=&a;
    cout<<"[a] value using void pointer: "<< *(static_cast<int*>(ptr)) <<endl;

    ptr=&f;
    cout<<"[f] value using void pointer: "<< *(static_cast<float*>(ptr)) <<endl;

    ptr=&c;
    cout<<"[c] value using void pointer: "<< *(static_cast<char*>(ptr)) <<endl;



    return 0;
}