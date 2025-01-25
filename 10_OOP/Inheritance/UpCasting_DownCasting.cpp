#include<iostream>
using namespace std;


class clsPerson
{
public:
    string FullName="Chouaib Hadadi";
};

class clsEmployee : public clsPerson
{
public:
    string Title="CEO";
};

int main()
{
    clsEmployee Employee1;
    cout<< Employee1.FullName <<endl;
    
    clsPerson * Person1= &Employee1; // UpCasting When The Base class point the the Drived one
    cout<<"Full name By Upcasting"<<Person1->FullName<<endl;
    
    // clsPerson Person2;
    // clsEmployee * Employee2 =&Person2; --> DownCasting And It's Imposible to the Drived class point the Base one. 
    return 0;
}