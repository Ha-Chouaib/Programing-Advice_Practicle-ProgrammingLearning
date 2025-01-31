#include<iostream>
using namespace std;

class clsMobile //Interface == (Abstruct class) != Abstruction principle) == Contract
{   
    // The [Abstuct class] it Forces the Heirs to Emplement Those [Pure virtual fuctions]
    //The [Pure Virtual Fuction] it's like Unique Form the Heirs Should Follow Ether Inthe Name Or Parameters 100% Identical. 

    //If The Class Have at least One [pure virtual function] the Whole class considered like an Interface
    virtual void Dial(string PhoneNumber)=0;
    virtual void SendSMS(string PhoneNumber, string MSG)=0;
    virtual void TakePicture()=0;
};

class clsFreeYound : public clsMobile
{
    void Dial(string PhoneNumber)
    {

    }
    void SendSMS(string PhoneNumber, string MSG)
    {

    };
    void TakePicture()
    {
        
    };
};


int main()
{
    clsFreeYound M5;

    return 0;
}