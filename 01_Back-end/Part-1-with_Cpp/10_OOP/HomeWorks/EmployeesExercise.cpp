#include<iostream>
using namespace std;

class clsEmployee
{
    int    _ID=0;
    string _FirstName="";
    string _LastName="";
    string _Title="";
    string _Email="";
    string _Phone="";
    double _Salary=0;
    string _Departement="";

public:
    clsEmployee(int ID,string FirstName, string LastName, string Title, string Email,string Phone,string Departement,double Salary)
    {
        _ID=ID;
        _FirstName=   FirstName;
        _LastName=    LastName;
        _Title=       Title;
        _Email=       Email;
        _Phone=       Phone;
        _Salary=      Salary;
        _Departement= Departement;
    }

    void SetFirstName(string FirstName)
    {
        _FirstName= FirstName;
    }
    void SetLastName(string LastName)
    {
        _LastName=LastName;
    }
    void SetTitle(string Title)
    {
        _Title=Title;
    }
    void SetEmail(string Email)
    {
        _Email= Email;
    }
    void SetPhone(string Phone)
    {
        _Phone=Phone;
    }
    void SetSalary(double Salary)
    {
        _Salary=Salary;
    }
    void SetDepartement(string Departement)
    {
        _Departement=Departement;
    }


    int ID()
    {
        return _ID;
    }
    string FirstName()
    {
        return _FirstName;
    }
    string LastName()
    {
        return _LastName;
    }
    string FullName()
    {
        return _FirstName +" "+ _LastName;
    }
    string Title()
    {
        return _Title;
    }
    string Email()
    {
        return _Email;
    }
    string Phone()
    {
        return _Phone;
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
        cout <<"\nEmployee Inf" <<endl;
        cout<<"=============================\n";
        cout<<"ID         : "    <<_ID <<endl;
        cout<<"First Name : "    <<_FirstName <<endl;
        cout<<"Last Name  : "    <<_LastName  <<endl;
        cout<<"Full Name  : "    <<FullName() <<endl;
        cout<<"Email      : "    <<_Email     <<endl;
        cout<<"Phone      : "    <<_Phone     <<endl;
        cout<<"Title      : "    <<_Title     <<endl;
        cout<<"Departement: "    <<_Departement     <<endl;
        cout<<"Salary     : "    <<_Salary     <<endl;
        cout<<"=============================\n\n";

    }

    void SendEmail(string Subject, string Body)
    {
        cout<<"The Message Has been Sended Successfully to --> ( "<<_Email <<" )."<<endl;
        cout<<"Subject: "<<Subject <<endl;
        cout<<"Body: "<<Body <<endl;
        cout<<endl;
    }

    void SendSMS(string SMS)
    {
        cout<<"The following SMS Has been Sende Successfully to --> ( "<<_Phone <<" )."<<endl;
        cout<< SMS <<endl;
    }
    

};

int main()
{
    clsEmployee Employee1(9990,"ALi","Kamil","Moro","Ali.Moro@gmail.com","0678543219","El9asaba",998387.636);
    Employee1.print();

    Employee1.SendEmail("Hi there","The Project has been done perfectly.");
    Employee1.SendSMS("Hello Sir Please Send me The Features you wanna add.");  
    
    return 0;
}