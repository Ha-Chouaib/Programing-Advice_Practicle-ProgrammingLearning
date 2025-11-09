#include <iostream>
using namespace std;

struct stEmployee
{
    string FirstName="";
    string LastName="";
    float Salary=0;
};

int main()
{   stEmployee Employee, *pointer;

    Employee.FirstName="Chouaib";
    Employee.LastName="Hadadi";
    Employee.Salary=450382;

    cout<<Employee.FirstName <<endl;
    cout<<Employee.LastName <<endl;
    cout<<Employee.Salary <<endl;

    cout<<endl;

    pointer= &Employee;

    cout<< pointer->FirstName <<endl;
    cout<< pointer->LastName <<endl;
    cout<< pointer->Salary <<endl;



    return 0;
}