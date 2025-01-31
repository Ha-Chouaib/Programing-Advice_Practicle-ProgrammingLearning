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

    //Thats what we mean By Constructor the name of the class as a function
    // If you do not add it the Combiler add it by default but empty.
    //and What we doing now is Overighting the default one and ignore it by this one below
    //with this Constructor we can control the class and Forcing the user to Fill the whole variables
    // and alot of things ...
    
    //As an example here i force the User to Set all those Data members and I prevented him from return empty class
    clsAddress(string AddressLine1,string AddressLine2,string POBox,string ZipCode)
    {
        _AddressLine1=AddressLine1;
        _AddressLine2=AddressLine2;
        _POBox=POBox;
        _ZipCode=ZipCode;
    }
    
    
    
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
    
    return 0;
}