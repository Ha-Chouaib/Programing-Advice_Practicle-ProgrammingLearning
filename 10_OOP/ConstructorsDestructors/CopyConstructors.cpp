#include<iostream>
using namespace std;

class clsAddress
{
private:
    string _AddressLine1;
    string _AddressLine2;
    string _POBox;
    string _ZipCode;

public:
    clsAddress(string AddressLine1,string AddressLine2,string POBox,string ZipCode)
    {
        _AddressLine1=AddressLine1;
        _AddressLine2=AddressLine2;
        _POBox=POBox;
        _ZipCode=ZipCode;
    }

    clsAddress(clsAddress &Old_Obj)//This One We call it Copy Constructor But the compiler do it By default
    {
        _AddressLine1=Old_Obj.GetAddressLine1();
        _AddressLine2=Old_Obj.GetAddressLine2();
        _POBox=Old_Obj.GetPOBox();
        _ZipCode=Old_Obj.GetZipCode();
    }
    //I don't need to do this copyConstructor just i should know about it.
    
    
    
    void SetAddressLine1(string AddressLine1)
    {
        _AddressLine1=AddressLine1;
    }
    void SetAddressLine2(string AddressLine2)
    {
        _AddressLine2=AddressLine2;
    }
    void SetPOBox(string POBox)
    {
        _POBox=POBox;
    }
    void SetZipCode(string ZipCode)
    {
        _ZipCode=ZipCode;
    }

    string GetAddressLine1()
    {
        return _AddressLine1;
    }
    string GetAddressLine2()
    {
        return _AddressLine2;
    }
    string GetPOBox()
    {
        return _POBox;
    }
    string GetZipCode()
    {
        return _ZipCode;
    }

    void PrintAddress()
    {
        cout<<"\nAddress Details: "<<endl;
        cout<<"--------------------------\n";
        cout<<"Address line 1: "<<_AddressLine1 <<endl;
        cout<<"Address line 2: "<<_AddressLine2 <<endl;
        cout<<"POBox: "<<_POBox<<endl;
        cout<<"ZipCode: "<<_ZipCode<<endl;

    }


};

int main()
{
    clsAddress Address1("ImmiYan Street","Il9asbt","52823","8888");
    Address1.PrintAddress();

    cout<<endl;
    clsAddress Address2=Address1;//Here Where the copy Constructor Comes in Copy all Old class Data Members the new one
                                    // You Can See it inside class above  
    Address2.PrintAddress();
    
    return 0;
}