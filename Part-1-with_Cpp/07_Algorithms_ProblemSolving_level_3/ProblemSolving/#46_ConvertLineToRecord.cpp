#include <iostream>
#include <string>
#include <vector>

using namespace std;


//--> write a program  To convert A line of data to Record.

struct stClientInf
{
    string AccountNumber="";
    string PINCode="";
    string FullName="";
    string PhoneNumber="";
    double AccountBalance=0;

};

//-> First Method:
stClientInf CovertLineToRecord(string LineOfData, string Separator="#//#")
{   
    stClientInf ClientInf;
    string Record="";
    short pos=0;
    while((pos=LineOfData.find(Separator)) != std::string::npos)
    {
        Record=LineOfData.substr(0,pos);
        LineOfData.erase(0,pos+ Separator.length());

        if(ClientInf.AccountNumber == "")
        {
            ClientInf.AccountNumber=Record;
            Record="";
        }            
        if(ClientInf.PINCode == "")
        {
            ClientInf.PINCode=Record;
            Record="";
        }   
        if(ClientInf.FullName == "")
        {
            ClientInf.FullName=Record;
            Record="";
        }    
        if(ClientInf.PhoneNumber == "")
        {
            ClientInf.PhoneNumber=Record;
            Record="";
        }   
 }

    if(LineOfData != "")
        ClientInf.AccountBalance= stod(LineOfData);
    
    return ClientInf;
}

//-->Second Method:
void MySplit(string str, vector <string>& vSplitstr, string Delimiter)
{
    string Token="";
    short pos=0;
    

    while((pos= str.find(Delimiter)) != std::string::npos)
    {
        Token=str.substr(0, pos);

        if(Token != "")
        {     
            vSplitstr.push_back(Token);
        }
        
        Token.clear();
        str.erase(0, pos + Delimiter.length());
    }

    if(str != "")
        vSplitstr.push_back(str);
}

stClientInf LineToRecord(string LineOfData, string Separator="#//#")
{
    stClientInf ClientInf;
    vector <string> vRecord;
    MySplit(LineOfData, vRecord, Separator);

    ClientInf.AccountNumber =vRecord[0];
    ClientInf.PINCode =vRecord[1];
    ClientInf.FullName =vRecord[2];
    ClientInf.PhoneNumber =vRecord[3];
    ClientInf.AccountBalance=stod(vRecord[4]);

    return ClientInf;

}


void ShowRecord(stClientInf ClientData)
{
    cout<<"Client Account Number: " <<ClientData.AccountNumber <<endl;
    cout<<"Client Pin Code: "       <<ClientData.PINCode <<endl;
    cout<<"Client Full Name: "      <<ClientData.FullName <<endl;
    cout<<"Client Phone Number: "   <<ClientData.PhoneNumber <<endl;
    cout<<"Client Account Balance: " <<ClientData.AccountBalance <<endl;
}
int main()
{   string LineOfData="A4242e#//#2435#//#Chouaib Hadadi#//#0642669110#//#456782.000000";

    cout<<"Client Record: "<<endl;

    cout<<"First Method: "<<endl;
    ShowRecord(CovertLineToRecord(LineOfData));
    cout<<endl;
    cout<<"Second Method: "<<endl;
    ShowRecord(LineToRecord(LineOfData));
    return 0;
}