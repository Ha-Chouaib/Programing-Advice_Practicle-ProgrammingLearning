#include<iostream>
using namespace std;

class clsPerson
{   
    //You are Free to Use Struct it's a normal thing. 
    struct stAddress
    {
        string AdressLine1;
        string AdressLine2;
        string city;
        string Country;
    };
public:
    string FullName;
    stAddress Address;

    clsPerson()
    {
        FullName="Chouaib Hadadi";
        Address.AdressLine1="Tiz";
        Address.AdressLine1="nit";
        Address.city="Oman";
        Address.Country="Qatar";
    }


};



int main()
{

   clsPerson P1;

   cout<<"Full Name: "<<P1.FullName<<endl;
   cout<<"City: "<<P1.Address.city <<endl;

    return 0;
}

