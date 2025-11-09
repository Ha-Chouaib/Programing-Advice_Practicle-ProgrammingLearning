#include <iostream>
#include <string>
#include <fstream>

using namespace std;
//Write a program read a structuer of Client info and save that recorod to a txt file as line
// the ask the user if he/she want to add More or not. if yes Read More And save to the file .if no end the program

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
    getline(cin >> ws, ClientInf.AccountNumber); //[ws]--> ignore all whigth spacses that can cause a problem to the grtline

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

void SaveDataToFile(string Data,string FileName)
{
    fstream SaveData;
    SaveData.open(FileName,ios::out | ios::app);
    if(SaveData.is_open())
    {
        SaveData <<Data <<endl;
    }
    SaveData.close();
}

void AddNewClient(string FileName)
{   stClientInf NewClient;
    string ClientData="";

    NewClient=GetClientInf();
    ClientData=RecordToLine(NewClient);
    SaveDataToFile(ClientData,FileName);
}

void AddClientsInfToFile(string FileName)
{   
   
    char AddMore='y';
    do
    {   cout<<"\nAdd New Client info:\n"<<endl;
       
        AddNewClient(FileName);

        cout<<"Client Added Successfully"<<endl;
        cout<<"\nDo you wanna add More Clients info? yes-->[Y_or_y]\\No-->[N_or-n]\n";
        cin>>AddMore;

    } while (toupper(AddMore) == 'Y');
    
}

int main()
{
    AddClientsInfToFile("ClientsInf.txt");
    return 0;
}