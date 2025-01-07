#include <iostream>
#include <string>
#include <vector>
#include <fstream>
#include <iomanip>

using namespace std;

struct stClientInf
{
    string AccountNumber="";
    string PINCode="";
    string FullName="";
    string PhoneNumber="";
    double AccountBalance=0;

};

string ReadTxt(string MSG)
{   
    string Txt="";
    cout<< MSG <<endl;
    getline(cin, Txt);

    return Txt;
}


void GetDataFromFile(string FileName, vector <string> &vData)
{
    fstream GetData;
    GetData.open(FileName, ios::in);
    if(GetData.is_open())
    {
        string Line;
        while(getline(GetData, Line))
        {   
                vData.push_back(Line);
        }
    }
    GetData.close();
}

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

string GetClientInfByAccountNumber(string FileName, string AccountNumber)
{
    vector <string> vClient;
    GetDataFromFile(FileName, vClient);

    short FindClient=0;
    
    for(string &Line : vClient)
    {
        if((FindClient= Line.find(AccountNumber)) != std::string::npos)
        {
            return Line;
        }  
    }
    return "";
}

void ShowClientRecord(stClientInf ClientData)
{   
    cout<<"Client Account Number: " <<ClientData.AccountNumber <<endl;
    cout<<"Client Pin Code: "       <<ClientData.PINCode <<endl;
    cout<<"Client Full Name: "      <<ClientData.FullName <<endl;
    cout<<"Client Phone Number: "   <<ClientData.PhoneNumber <<endl;
    cout<<"Client Account Balance: " <<ClientData.AccountBalance <<endl;
}

void FindClientAccount(string FileName,string AccountNumber)
{
    stClientInf ClientInf;
    string ClientData=GetClientInfByAccountNumber(FileName,AccountNumber);
    if(ClientData != "")
    {
        ClientInf= LineToRecord(ClientData);
        cout<<"\nThe Account [ "<<AccountNumber<<" ] Detailes: \n\n";
        ShowClientRecord(ClientInf);
    }else
    {
        cout<<"The Account [ "<<AccountNumber<<" ] Not Found!"<<endl;
    }
}

int main()
{   string AccountNumber= ReadTxt("Please enter the Account Number?");
    FindClientAccount("ClientsInf.txt",AccountNumber);
    return 0;
}