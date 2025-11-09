#include<iostream>
using namespace std;


class clsPerson
{
private:
    string _FirstName;
    string _LastName;

public:

    void SetFirstName(string FirstName)//Set Property
    {
        _FirstName= FirstName;
    }

    string GetFirstName() // Get property
    {
        return _FirstName;
    }

    void SetLastName(string LastName)
    {
        _LastName= LastName;
    }

    string GetLastName()
    {
        return _LastName;
    }

    string FullName()
    {
        return _FirstName + " " + _LastName;
    }
};

int main()
{
    clsPerson Person1;

    Person1.SetFirstName("Chouaib");
    Person1.SetLastName("Hadadi");
    
    cout<<"(P1)-> First Name: "<<Person1.GetFirstName() <<endl;
    cout<<"(P1)-> Last Name: "<<Person1.GetLastName() <<endl;
    cout<<"(P1)-> Full Name: "<<Person1.FullName() <<endl;


    return 0;
}
