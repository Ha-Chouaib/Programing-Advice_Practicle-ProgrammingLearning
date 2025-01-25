#include<iostream>
using namespace std;


class clsPerson
{
private:
    string _FirstName="";

public:

    void SetFirstName(string FirstName)
    {
        _FirstName= FirstName;
    }

    string GetFirstName()
    {
        return _FirstName;
    }
   /*  /!\ __declspec(property(get=GetFirstName, put=SetFirstName)) string FirstName; /!\ 
   
     but this method is spesific for Microsoft compiler (MSVC) not linux so well not work with me.
   */ 
};

int main()
{
    clsPerson P1;
    P1.SetFirstName("Chouaib");
    cout << P1.GetFirstName() <<endl;
    /*
    Normaly Here With __declspec(...) above Instead of  using methods members 
        we can use only like an alias name to set and also get.
    P1.FirstName="Chouaib";
    cout<< P1.FirstName <<endl;

    */
    
    return 0;
}