#include<iostream>
using namespace std;


class cls
{

public:
    short Var=0;
    static short Counter;//This Like a shared Variable of all class Objects
    // Must Be initialized directly bellow the class out side.
    cls()
    {
        Counter++;
    }

    void print()
    {
        cout<<"Var Value: "<<Var <<endl;
        cout<<"Counter Value: "<<Counter <<endl;
    }
};
short cls::Counter=0; // initilization bellow class and not in main function.

int main()
{
    
    //Here the Static member well not be changed across all class objects opposit of Normal data member
    cls A ,B ,C;
    A.Var=1;
    B.Var=2;
    C.Var=3;
    A.print();
    B.print();
    C.print();

    //I changed the static member just in one object and it changed in all the others
    A.Counter=100;
    cout<<"\nAfter Modifing counter by Object A\n";
    A.print();
    B.print();
    C.print();
    
    return 0;
}