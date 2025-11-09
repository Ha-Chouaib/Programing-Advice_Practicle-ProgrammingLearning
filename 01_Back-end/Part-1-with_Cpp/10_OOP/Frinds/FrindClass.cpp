#include<iostream>
using namespace std;

class clsA
{
    short _PriVar;
public:
    short _PubVar;
    clsA()
    {
        _PriVar=90;
        _PubVar=2;
    }

    friend class clsB; //In the normal case the Drivedclass Inherits Just Protected and public.
        // By tag << frind class ... >>  it Can even Access The private Members.
        // But Only Inside the class. 
};

class clsB : public clsA
{
public:
    void Display(clsA A)
    {
        cout<<"Access private Var value from SuperClass ( "<< A._PriVar<<" )" <<endl;
        cout<<"Show Public Var value From Base class ( "<< A._PubVar <<" )" <<endl;
    }
};



int main()
{

    clsA A;
    clsB B;
    B.Display(A);


    return 0;
}