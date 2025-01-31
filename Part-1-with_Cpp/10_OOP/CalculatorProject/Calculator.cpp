#include<iostream>
#include<string>
#include<cmath>
using namespace std;


class clsCalculator
{
   
   
    float _LastNumber=0, _PreviousResult=0, _Result=0;

    string _LastOperation="Clear";

    bool _IsZero(float Num)
    {
        return (Num == 0); 
    }
    


public:
    void Add(float Number)
    {
        _LastNumber=Number;
        _PreviousResult= _Result;
        _LastOperation="Adding";
        _Result+=Number;
    }
    void Sub(float Number)
    {   
        _LastNumber=Number;
        _PreviousResult= _Result;
        _LastOperation="Substructing";
        _Result-=Number;
    }
    void Multiplay(float Number)
    {
        _LastNumber=Number;
        _PreviousResult= _Result;
        _LastOperation="Multiplaying";
        _Result*=Number;
    }
    void Divide(float Number)
    {
        _LastNumber=Number;
        _PreviousResult= _Result;
        _LastOperation="Dividing";
        
        _IsZero(Number)? _Result/=1 : _Result/= Number;
        
    }
    void Result()
    {   
        cout<< "Result After "<< _LastOperation <<" " << _LastNumber << " is: "<<_Result <<endl;
    }
    void CancelLastOperation()
    {
        _LastNumber=0;
        _LastOperation="Cancelling Last Operation";
        _Result= _PreviousResult;
    }
    float GetFinalResult()
    {
        return _Result;
    }
    void Clear()
    {   
        _LastNumber=0;
        _LastOperation="";
        _PreviousResult=0;
        _Result=0;
    }
};

int main()
{
    clsCalculator Calc;
    
    
    return 0;
}
