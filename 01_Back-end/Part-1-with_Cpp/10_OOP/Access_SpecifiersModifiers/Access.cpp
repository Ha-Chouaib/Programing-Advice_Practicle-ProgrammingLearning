/*
                Access Specifiers = (Modifiers)

We have 3 Modifieres that control the accessablity of a Class Members:
    (1)[private]--> Accessible only inside the class
    (2)[protected]-->Accessible Inside the Class And Also Classes Inherits this class 
    (3)[public]-->Accessible by all

*/

#include<iostream>
#include<string>
using namespace std;

class clsPerson
{
private:
    short Var1=2;
    short Func1()
    {
        return Var1 +2;
    }

protected:
    int Var2=392;
    string Func2()
    {
        return " Func1: " + to_string(Func1()) + " Var2: " + to_string(Var2);
    }

public:
    string FirstName="";
    string LastName=""; //Data Member
    short Age=0;
    string PersonInf()//Method Member
    {
        return "Full Name: "+FirstName + " " +LastName+ " #//# Age: " + to_string(Age) + " #//# "+Func2();
    }

};


int main()
{
    clsPerson Person1;
    Person1.FirstName="Chouaib";
    Person1.LastName="Hadadi";
    Person1.Age=22;

    cout<<"Person1: "<<Person1.PersonInf()<<endl;

    return 0;
}