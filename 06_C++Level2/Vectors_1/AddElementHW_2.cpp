#include <iostream>
#include <vector>
using namespace std;

struct stEmployeeInf
{
    string FirstName="";
    string LastName="";
    float Salary=0;
};

int main()
{
    vector <stEmployeeInf> vEmployees;

    stEmployeeInf TempEployee;

    TempEployee.FirstName="Chouaib";
    TempEployee.LastName="Hadadi";
    TempEployee.Salary=900000;
    vEmployees.push_back(TempEployee);


    TempEployee.FirstName="Ali";
    TempEployee.LastName="Gani";
    TempEployee.Salary=1029;
    vEmployees.push_back(TempEployee);

    TempEployee.FirstName="Mbark";
    TempEployee.LastName="Hadadi";
    TempEployee.Salary=10000;
    vEmployees.push_back(TempEployee);

    for(stEmployeeInf &Employee :vEmployees)
    {
        cout<<"First Name: "<<Employee.FirstName <<endl;
        cout<<"Last Name: "<<Employee.LastName <<endl;
        cout<<"Salary: "<<Employee.Salary <<endl;
        cout<<endl;
    }
    return 0;
}
