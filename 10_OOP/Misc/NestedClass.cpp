#include<iostream>
using namespace std;

class clsPerson
{   
    //You are Free to Use Struct it's a normal thing. 
    class clsAddress
    {
    
        string _AdressLine1;
        string _AdressLine2;
        string _city;
        string _Country;
    public:
        clsAddress(string AddressLine1,string AddressLine2, string City, string Country)
        {
            
            _AdressLine1=AddressLine1;
            _AdressLine2=AddressLine2;
            _city =City;
            _Country=Country;

        }

        void print()
        {
            cout<<_AdressLine1 <<endl; 
            cout<<_AdressLine1<< endl;
            cout<<_city<< endl;
            cout<<_Country<< endl;
        }

    };
public:
    string FullName;
    
    clsAddress Address;

    clsPerson(string AddressLine1,string AddressLine2, string City, string Country)
        :Address( AddressLine1, AddressLine2,  City,  Country)
    {
       FullName="Chouaib Hadadi" ;
    }

   

};



int main()
{

    clsPerson P1("AddressLin1","AddressLine2","City","Country");

    cout<<P1.FullName <<endl;
    P1.Address.print();
    return 0;
}

