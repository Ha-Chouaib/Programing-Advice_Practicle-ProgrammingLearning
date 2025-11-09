#pragma once
#include <iostream>
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
