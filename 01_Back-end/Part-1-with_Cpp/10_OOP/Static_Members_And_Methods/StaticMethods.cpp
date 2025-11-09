#include<iostream>
using namespace std;

class cls
{
public:

    // the static Method it's like a global function you can call it ether by class or by object 
    static short Func1()
    {
        return 1;
    }
    short Func2()
    {
        return 2;
    }
};

int main()
{   
    cout<<"Call Func1 By class:     " <<cls::Func1()<<endl;
    cls A;
    cout<< "Call Func1 By Object:   " <<A.Func1() <<endl;
    cout<<"Func2 You Can Call it only by Object:    "<< A.Func2() <<endl;
    return 0;
}