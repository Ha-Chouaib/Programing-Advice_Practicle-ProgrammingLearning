#include<vector>
#include<iostream>
using namespace std;

struct stEmployees
{
    string FirstName="";
    string LastName="";
    float Salary=0;
};

void ReadEmployeesInf(vector <stEmployees> &vEmployees)
{
    stEmployees TempEmployee;
    char AddMore='N';
    do
    {   cout<<"First Name: ";
        cin>>TempEmployee.FirstName;
        cout<<"Last Name: ";
        cin>>TempEmployee.LastName;
        cout<<"Salary: ";
        cin>>TempEmployee.Salary;

        vEmployees.push_back(TempEmployee);

        cout<<"Do you want Add More [yes]-->(Y)\\ [No]-->(N)."<<endl;
        cin>>AddMore;
        
    } while (AddMore== 'Y'|| AddMore=='y');
    
}

void PrintEmployees(vector <stEmployees> &vEmployees)
{
    for(stEmployees &Employee : vEmployees)
    {
        cout<<"First Name: "<<Employee.FirstName <<endl;
        cout<<"Last Name: "<<Employee.LastName <<endl;
        cout<<"Salary: "<<Employee.Salary <<endl;
        cout<<endl;
    }
}

int main()
{
    vector <stEmployees> vEmployees;
    ReadEmployeesInf(vEmployees);
    PrintEmployees(vEmployees);

    return 0;
}