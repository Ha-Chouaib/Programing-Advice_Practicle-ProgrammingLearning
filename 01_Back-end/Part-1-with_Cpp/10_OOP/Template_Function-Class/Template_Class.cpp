#include<iostream>
using namespace std;

template<class T>
class Calcolator
{
    T Num1;
    T Num2;
public:

    Calcolator( T Num1, T Num2)
    {
        this->Num1=Num1;
        this->Num2=Num2;
    }

    T Add()
    {
        return (T) Num1 + Num2 ;
    }
    T Sub()
    {
        return (T) Num1 - Num2;
    }
    T Mult()
    {
        return (T) Num1 * Num2;
    }
};

int main()
{
    short ShortNum1=1, ShortNum2=2;
    float FloatNum1=3.3, FloatNum2=4.4;

    Calcolator ShortCalc(ShortNum1, ShortNum2);
    Calcolator FloatCalc(FloatNum1, FloatNum2);

    cout<<"Short Add Result: "<<ShortCalc.Add()<<endl;
    cout<<"Float Add Result: "<<FloatCalc.Add()<<endl;
}

