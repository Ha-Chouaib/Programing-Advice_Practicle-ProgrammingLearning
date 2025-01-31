#include<iostream>
using namespace std;


class clsA
{
    short _PriVar;

protected:
    short ProtVar;

public:
    short PubVar;


    clsA()
    {
        _PriVar=8;
        ProtVar=7;
        PubVar=6;
    }

    friend int Sum(clsA A); // the same concept of Frind class
    // the Frind Function Has the Access of all class Members.

};

int Sum(clsA A)
{
    return A.PubVar + A.ProtVar + A._PriVar;
}

int main()
{
    clsA A;
    cout<< Sum(A)<<endl;

    return 0;
}