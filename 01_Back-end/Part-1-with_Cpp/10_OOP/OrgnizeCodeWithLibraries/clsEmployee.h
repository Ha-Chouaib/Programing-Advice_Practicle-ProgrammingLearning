#pragma once
#include<iostream>
#include"clsPerson.h"
using namespace std;

class clsEmployee :public clsPerson 
{
    string _Title="";
    float _Salary=0;
    string _Departement="";
public:

    clsEmployee(int ID,string FirstName,string LastName,string Email,string Phone,string Title,string Departement,float Salary)
        : clsPerson(ID,FirstName,LastName,Email,Phone)
    {
        _Title=Title;
        _Departement=Departement;
        _Salary=Salary;
    }

    void SetTitle(string Title)
    {
        _Title=Title;
    }
    void SetSalary(double Salary)
    {
        _Salary=Salary;
    }
    void SetDepartement(string Departement)
    {
        _Departement=Departement;
    }

    string Title()
    {
        return _Title;
    }
    string Departement()
    {
        return _Departement;
    }
    double Salary()
    {
        return _Salary;
    }

    void print()
    {
        //<< clsPerson::print() >>Here to ReUse the SuperClass Method.

        cout <<"\nInf:" <<endl;
        cout<<"=============================\n";
        cout<<"ID         : "    << ID()         <<endl;//You Could only access the methods those in public field
        cout<<"First Name : "    << FirstName()  <<endl;//You Can Not Access the private Data Members
        cout<<"Last Name  : "    << LastName()   <<endl;//Only Public Members And Proected Ones.
        cout<<"Full Name  : "    << FullName()   <<endl;
        cout<<"Email      : "    << Email()      <<endl;
        cout<<"Phone      : "    << Phone()      <<endl;
        cout<<"Title      : "    << _Title       <<endl;
        cout<<"Departement: "    << _Departement <<endl;
        cout<<"Salary     : "    << _Salary      <<endl;
        cout<<"=============================\n\n";
    }


};
