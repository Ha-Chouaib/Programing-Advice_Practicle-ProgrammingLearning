#include<iostream>
using namespace std;

class clsPerson
{   
     
    string _FullName;
    class clsAddress
    {
    
        string _AddressLine1;
        string _AddressLine2;
        string _city;
        string _Country;
    public:
        clsAddress(string AddressLine1,string AddressLine2, string City, string Country)
        {
            
            _AddressLine1=AddressLine1;
            _AddressLine2=AddressLine2;
            _city =City;
            _Country=Country;

        }
        void SetAddressLine1(string AddressLine1)
        {
            _AddressLine1 = AddressLine1;
        }
        void SetAddressLine2(string AddressLine2)
        {
            _AddressLine2= AddressLine2;
        }
        void SetCity(string City)
        {
            _city= City;
        }
        void SetCountry(string Country)
        {
            _Country=Country;
        }


        string AddressLine1()
        {
            return _AddressLine1;
        }
        string AddressLine2()
        {
            return _AddressLine2;
        }
        string City()
        {
            return _city;
        }
        string Country()
        {
            return _Country;
        }

        void print()
        {
            cout<< "AddressLine (1) : " <<_AddressLine1 <<endl; 
            cout<< "AddressLine (2) : " <<_AddressLine1 << endl;
            cout<< "City            : " <<_city         << endl;
            cout<< "Country         : " <<_Country      << endl;
        }

    };
public:
    
    clsAddress Address;

    clsPerson(string FullName, string AddressLine1,string AddressLine2, string City, string Country)
        :Address( AddressLine1, AddressLine2,  City,  Country)
    {
       _FullName= FullName ;
    }

   void SetFullName(string FullName)
   {
        _FullName=FullName;
   }
   string FullName()
   {
    return _FullName;
   }

};



int main()
{

    clsPerson P1("Chouaib Hadadi","Buliding 02","Gaton","Amo","Tiz");

    
    cout<<"\nFull Name: "<< P1.FullName() <<endl;
    P1.Address.print();
    return 0;
}

