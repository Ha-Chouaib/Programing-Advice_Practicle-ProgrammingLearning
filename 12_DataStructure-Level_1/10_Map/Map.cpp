#include<iostream>
#include<map>

using namespace std;

int main()
{   //map == Dictionary In Other Programming Languages.
    map <string , double> Salary;// Map Needs < Key > And < Value >

    //Set
    Salary["Chouaib"]=99999;
    Salary["Morad"]=997260;
    Salary["Ahmad"]= 40032;

    cout<<"Map Content\n";
    for(const auto& pair :Salary)
    {
        cout<<"Employee: "<<pair.first <<"/ Salary: "<<pair.second <<endl;
    }

    cout<<"\nFind Chouaib's Salary.\n";
    string EmployeeName="Chouaib";
    //Get
    if(Salary.find(EmployeeName) != Salary.end())
    {
        cout<<EmployeeName <<"'s Salary: "<<Salary[EmployeeName] <<endl;
    }else
    {
        cout<<EmployeeName<<"'s Slaray Not Found\n";
    }

    EmployeeName="Ali";
    
    if(Salary.find(EmployeeName) != Salary.end())
    {
        cout<<EmployeeName <<"'s Salary: "<<Salary[EmployeeName] <<endl;
    }else
    {
        cout<<EmployeeName<<"'s Slaray Not Found\n";
    }




}