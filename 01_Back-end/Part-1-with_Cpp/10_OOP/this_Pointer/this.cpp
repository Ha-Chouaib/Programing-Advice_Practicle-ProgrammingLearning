#include<iostream>
using namespace std;

// << this >> is a pointer in cpp point the Current instance  variable or a class member
//We Can Use It:
// If You Have the Same Members Name Use this To Let the compiler to distinguish between the Class Member and the others
// Can be used also as a parameter to pass current Object to an other method ...
class clsEmployee
{

public:
    short ID;
    string FullName;
    float Salary;

    clsEmployee(short ID, string FullName,float Salary)
    {   //Variables with the same name.
        this->ID=ID;
        this->FullName=FullName;
        this->Salary=Salary;
    }

    static void Func1(clsEmployee Employee)
    {
        Employee.print();
    }

    void Func2()
    {
        Func1(*this);
    }

    void print()
    {
        cout<<"ID: "<<ID <<endl;
        cout<<"Full Name: "<<FullName <<endl;
        cout<<"Salary: "<<Salary<<endl;
    }
};


int main()
{

    clsEmployee E1(8888,"Chouaib Hadadi",8999);
    E1.Func2(); // Here the Func2 it's piont the OBject E1 to the Func1


    return 0;
}