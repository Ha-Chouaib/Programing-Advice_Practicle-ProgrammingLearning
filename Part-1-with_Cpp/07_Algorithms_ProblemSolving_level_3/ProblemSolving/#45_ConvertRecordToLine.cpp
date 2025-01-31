#include <iostream>
#include <string>

using namespace std;

//--> write a program read a bank client data record and then convert it to one line.

struct stClientInf
{
    string AccountNumber="";
    string PINCode="";
    string FullName="";
    string PhoneNumber="";
    double AccountBalance=0;

};

stClientInf GetClientInf()
{
    stClientInf ClientInf;

    cout<<"Enetr the account number: ";
    getline(cin, ClientInf.AccountNumber);

    cout<<"Enter the PIN Code: ";
    getline(cin, ClientInf.PINCode);

    cout<<"Enter The Full Name: ";
    getline(cin, ClientInf.FullName);

    cout<<"Enter the phone number: ";
    getline(cin, ClientInf.PhoneNumber);

    cout<<"Enter the Account balance: ";
    cin>>ClientInf.AccountBalance;

    return ClientInf;
}

string RecordToLine(stClientInf Client , string Separator="#//#")
{
    string InOneLine="";

    InOneLine+=Client.AccountNumber +Separator;
    InOneLine+=Client.PINCode +Separator;
    InOneLine+=Client.FullName +Separator;
    InOneLine+=Client.PhoneNumber +Separator;
    InOneLine+=to_string(Client.AccountBalance);

    return InOneLine;
}

int main()
{
    stClientInf ClientInf;
    ClientInf=GetClientInf();

    cout<<"\n\nThe Record for saving is:"<<endl;
    cout<<RecordToLine(ClientInf) <<endl;

    return 0;
}