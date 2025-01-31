#include<iostream>
using namespace std;



class clsPerson
{
    short _ID=0;
    string _FirstName="";
    string _LastName="";
    string _Email="";
    string _Phone="";

public:

    
    clsPerson(short ID,string FirstName, string LastName,string Email,string Phone)
    {
        _ID=ID;
        _FirstName=FirstName;
        _LastName=LastName;
        _Email=Email;
        _Phone=Phone;
    }

    void SetFirstName(string FirstName)
    {
        _FirstName= FirstName;
    }

    void SetLastName(string LastName)
    {
        _LastName= LastName;
    }

    void SetEmail(string Email)
    {
        _Email=Email;
    }

    void SetPhone(string Phone)
    {
        _Phone=Phone;
    }

    short ID()
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
    string Email()
    {
        return _Email;
    }
    string Phone()
    {
        return _Phone;
    }

    void print()
    {
        cout <<"\nInf:" <<endl;
        cout<<"=============================\n";
        cout<<"ID        : "    <<_ID <<endl;
        cout<<"First Name: "    <<_FirstName <<endl;
        cout<<"Last Name : "    <<_LastName  <<endl;
        cout<<"Full Name : "    <<FullName() <<endl;
        cout<<"Email     : "    <<_Email     <<endl;
        cout<<"Phone     : "    <<_Phone     <<endl;
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

class clsEmployee :public clsPerson 
{
    string _Title="";
    float _Salary=0;
    string _Departement="";
public:

    //Here We Solve The Constructor Parameterized problem by sending to the Base class the parameters it need thorugh the Subclass
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

int main()
{
    clsEmployee Employee(8888,"Chouaib", "Hadadi","G@gmail.com","0976543902","TechLead","SoftEng",99998376);
    
    Employee.print();//To Solve the Problem We should Overriding<< new func with same name and params>> the function in the subclass and then
                    // build a new one and reUse the old one that locate in the superclass and add your changes.

    Employee.SendEmail("Hello","How Are You Doing Buddy");
    Employee.SendSMS("Hi Man what's up my nigga how is life ?");

    return 0;
}