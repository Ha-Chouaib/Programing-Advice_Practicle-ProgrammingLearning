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


void DisplayOneClientInf(string ClientData, string separator)
{
    stClientInf ClientInf;
    ClientInf=LineToRecord(ClientData,separator);
    cout<<"| "<<setw(15)  <<left  << ClientInf.AccountNumber;
    cout<<"| "<<setw(10)  <<left  <<ClientInf.PINCode;
    cout<<"| "<<setw(40)  <<left  <<ClientInf.FullName;
    cout<<"| "<<setw(12)  <<left  <<ClientInf.PhoneNumber;
    cout<<"| "<<setw(12)  <<left  <<ClientInf.AccountBalance;
}

void DisplayClientsData(string FileName,string Separator="#//#")
{
    vector <string> VClientData;
    GetDataFromFile(FileName,VClientData);

     cout<<"                         Client List ("<<VClientData.size()<<") Client(s)."<<endl;
    cout<<"\n======================================================================================================\n\n";
    cout<<"| " <<setw(15) << left<<"Account Number"  
        <<"| " <<setw(10) << left<<"Pin Coce" 
        <<"| " <<setw(40) << left<<"Client Name" 
        <<"| " <<setw(12) << left<<"Phone"
        <<"| " <<setw(12) << left<<"Balance"<<endl;
    cout<<"\n======================================================================================================\n";

    for(short i=0; i<VClientData.size(); i++)
    {
        DisplayOneClientInf(VClientData[i],Separator);
        cout<<endl;
    }
    cout<<"******************************************************************************************************\n";
    
}
int main()
{

    DisplayClientsData("ClientsInf.txt");
    return 0;
}