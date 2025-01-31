#include <iostream>
#include <string>
#include <vector>
#include <fstream>
#include <iomanip>
#include <cctype>
#include <limits>

using namespace std;
const string FileName="ClientsData";


enum enMainMenuOptins
{
    eShowClientsList=1,
    eAddNewClient=2,
    eDeleteClient=3,
    eUpdateClientInf=4,
    eFindClient=5,
    Exit=6,
};

struct stSettings
{
    bool MarkClient=false;
    bool AddMore=true;
    bool IsUpadted=true;
};
struct stClientInf
{
    string AccountNumber="";
    string PinCode="";
    string FullName="";
    string Phone="";
    double AccountBalance=0;
    stSettings Settings;
    
    
};

string ReadString(string MSG)
{
    string str="";
    cout<< MSG <<endl;
    getline(cin>>ws , str);

    return str;
}

short ReadNumberInRange(short From, short To, string MSG)
{
    short num=0;
    do
    {
        cout<< MSG <<endl;
        cin>>num;
        if(cin.fail())
        {
            cin.clear();
            cin.ignore(std::numeric_limits<std::streamsize>::max());
            cout<<"<<Type Error>> Please enter an integer Input." <<endl;
            cin>>num;
        }

    } while (num<From || num > To);
    
    return num;
}

string Tabs(short HowmanyTabs)
{   string tabs="";
    for(short i=0; i<HowmanyTabs; i++)
    {
        tabs+="\t";
    }
    return tabs;
}

void DispalyMainMenu();

string RecordToLine(stClientInf ClientInf, string Separatore="#//#")
{
    string ClinetDataInLine="";
    ClinetDataInLine+= ClientInf.AccountNumber + Separatore;
    ClinetDataInLine+= ClientInf.PinCode + Separatore;
    ClinetDataInLine+= ClientInf.FullName + Separatore;
    ClinetDataInLine+= ClientInf.Phone + Separatore;
    ClinetDataInLine+= to_string(ClientInf.AccountBalance);

    return ClinetDataInLine;
}

void AddClientDataToFile(string FileName,string ClientData)
{
    fstream ClientInfo;
    ClientInfo.open(FileName, ios::out | ios::app);

    if(ClientInfo.is_open())
    {
        ClientInfo<< ClientData <<endl;
    }
    ClientInfo.close();
}

vector <string> Split(string LineData,string Separator)
{
    vector <string> Rcord;
    short pos=0;
    string Token="";
    while((pos= LineData.find(Separator)) != std::string::npos)
    {
        Token= LineData.substr(0,pos);
        if(Token != "")
        {
            Rcord.push_back(Token);
            Token.clear();
        }
        LineData.erase(0, pos +Separator.length());
    }
    if(LineData != "")
        Rcord.push_back(LineData);
    
    return Rcord;
}

stClientInf LineToRecord(string ClientData,string Separator="#//#")
{
    vector <string>vClient;
    stClientInf ClientInf;

    vClient= Split(ClientData,Separator);

    ClientInf.AccountNumber=vClient[0];
    ClientInf.PinCode=vClient[1];
    ClientInf.FullName=vClient[2];
    ClientInf.Phone=vClient[3];
    ClientInf.AccountBalance=stod(vClient[4]) ;
    
    return ClientInf;
}

vector <stClientInf> LoadClientDataFromFile(string FileName,string Separator="#//#")
{   
    vector <stClientInf> vClientInfo;

    fstream LoadData;
    LoadData.open(FileName,ios::in);
    if(LoadData.is_open())
    {
        string line="";
        stClientInf ClientInf;
        while(getline(LoadData, line))
        {
            ClientInf=LineToRecord(line,Separator);
            vClientInfo.push_back(ClientInf);
        }
    }
    LoadData.close();
    return vClientInfo;
}

bool CachClientByAccountNumber(string FileName, string AccountNumber,vector <stClientInf> &vClientsData, bool MarkClient=true )
{   
    
    vClientsData=LoadClientDataFromFile(FileName);
    for(stClientInf &Rec : vClientsData)
    {
        if(Rec.AccountNumber == AccountNumber)
        {   
            if(MarkClient)
                Rec.Settings.MarkClient = true;
            return true;
        }
    }
    return false;
}

stClientInf ReadClientInf(string FileName,vector <stClientInf> &vClientInf)
{
    stClientInf Client;
    char stillAdd='Y';
    Client.AccountNumber=ReadString("Account Number: ");

    while(CachClientByAccountNumber(FileName,Client.AccountNumber,vClientInf) && toupper(stillAdd)=='Y')
    {
        cout<<"The Account <<"<<Client.AccountNumber<<">> Is Alrady exist, please choose another account number."<<endl;
        cout<<"\nDo you still want Add a Client? (y/n)"<<endl;
        cin>>stillAdd;
        if(toupper(stillAdd)=='Y')
            Client.AccountNumber=ReadString("Account Number: ");
        else
        {
            for(stClientInf &vClient : vClientInf)
            {
                if(Client.AccountNumber == vClient.AccountNumber)
                {
                    vClient.Settings.AddMore=false;
                    return vClient;
                }
            }
        }
    }
    
    Client.PinCode=ReadString("Pin Code: ");
    Client.FullName=ReadString("Full Name: ");
    Client.Phone=ReadString("Phone Number: ");
    Client.AccountBalance=stod(ReadString("Account Balance: "));
  
    return Client;
}

void AddNewClients(string FileName,vector<stClientInf> vClientInf,string Separator="#//#")
{   
    cout<<"\n++++++++++++++++++++++++++++++++++\n";
    cout<< Tabs(2)<<"Adding Clients Field."<<endl;
    cout<<"\n++++++++++++++++++++++++++++++++++\n";

    string Client;
    stClientInf sClientinf;
    
    char stillAdd='Y';
    char addMore='Y';
    
    do
    {
        sClientinf=ReadClientInf(FileName,vClientInf);
        if(!CachClientByAccountNumber(FileName,sClientinf.AccountNumber,vClientInf,false))
        {
            Client=RecordToLine(sClientinf,Separator);

            AddClientDataToFile(FileName, Client);

            cout<<"Client Added successfully."<<endl;
        }
        if(sClientinf.Settings.AddMore)
        {
            cout<<"Do you Wanna Add More?(y/n)"<<endl;
            cin>>addMore;
        }else
        {
            addMore='n';
        }
        
    } while (toupper(addMore) == 'Y');
    
    
}

void UpdateFileData(string FileName, vector <stClientInf> &vClientsData)
{
    fstream updateData;
    updateData.open(FileName, ios::out);
    if(updateData.is_open())
    {   
        string line="";
        for(stClientInf &Rec : vClientsData)
        {
            line=RecordToLine(Rec);
            updateData << line <<endl;
        }
    }
    updateData.close();

}

void DisplayClientInfo(stClientInf ClientInf)
{
    cout<<"\n==================[Account Number]<<"<<ClientInf.AccountNumber<<">>=================="<<endl;
    cout<<endl;
    cout<<"Pin Code: "<<ClientInf.PinCode<<endl;
    cout<<"Full Name: "<<ClientInf.FullName<<endl;
    cout<<"Phone Number: "<<ClientInf.Phone<<endl;
    cout<<"Account Balance: "<<ClientInf.AccountBalance<<endl;
    cout<<"\n======================================================\n";
}

vector<stClientInf> RemoveAccount(vector<stClientInf> &vClientInf)
{   
    vector <stClientInf> vClientData;
    for(stClientInf &Client : vClientInf)
    {
        if(!Client.Settings.MarkClient)
        {
            vClientData.push_back(Client);
        }
    }
    return vClientData;
}

void DeleteClientAccount(string FileName,vector <stClientInf>&vClientsInf )
{   
    cout<<"\n- - - - - - - - - - - - - - - - - - - - - - -\n";
    cout<<Tabs(2)<<"Delete Cleient Field."<<endl;
    cout<<"\n- - - - - - - - - - - - - - - - - - - - - - -\n";

    string AccountNumber= ReadString("Enter The Account Number?");
    vector<stClientInf>vNewClietsRecord;
    if(CachClientByAccountNumber(FileName,AccountNumber,vClientsInf))
    {   
        for(stClientInf &Rec : vClientsInf)
        {   
            if(Rec.Settings.MarkClient)
            {   
                char Del='n';
                DisplayClientInfo(Rec);

                cout<<"\nAre you sure to delete the Account? (y/n)"<<endl;
                cin>>Del;
                if(toupper(Del) == 'Y')
                {
                    vNewClietsRecord= RemoveAccount(vClientsInf);
                    UpdateFileData(FileName,vNewClietsRecord);
                    cout<<"The Account Deleted Successfully."<<endl;
                }
                break;
            }
        }
        
    }else
    {
        cout<<"The Account << "<<AccountNumber <<" >> Not Found!"<<endl;
    }
}

void UpdateClientRecord(stClientInf &OldRecord, stClientInf UpdatedRecord)
{   
        OldRecord.PinCode=UpdatedRecord.PinCode;
        OldRecord.FullName=UpdatedRecord.FullName;
        OldRecord.Phone=UpdatedRecord.Phone;
        OldRecord.AccountBalance=UpdatedRecord.AccountBalance;
        OldRecord.Settings.MarkClient=UpdatedRecord.Settings.MarkClient;
    
}

bool ReadInfoForUpdate(stClientInf &Client)
{
    
    
    char AreYouSuer='Y';
    cout<<"Are you sure to Update the Account?! (y/n)"<<endl;
    cin>>AreYouSuer;
    if(toupper(AreYouSuer) == 'Y')
    {
    Client.PinCode=ReadString("Pin Code: ");
    Client.FullName=ReadString("Full Name: ");
    Client.Phone=ReadString("Phone Number: ");
    Client.AccountBalance=stod(ReadString("Account Balance: "));
    Client.Settings.MarkClient=false;
    return Client.Settings.IsUpadted;
    }
    return Client.Settings.IsUpadted=false;
}

void UpdateClientsInfo(string FileName,vector<stClientInf>&vClientInf)
{  
    cout<<"\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n";
    cout<<Tabs(3)<<"Update Field."<<endl;
    cout<<"\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n";

    string AccountNumber= ReadString("Enter The Account Number?");

    if(CachClientByAccountNumber(FileName,AccountNumber,vClientInf))
    {   
        stClientInf UpdatedInf;
        for(stClientInf &Rec : vClientInf)
        {
            if(Rec.Settings.MarkClient)
            {   
                DisplayClientInfo(Rec);

                ReadInfoForUpdate(UpdatedInf);
                UpdateClientRecord(Rec,UpdatedInf);     
                break;
            }
        }
        if(UpdatedInf.Settings.IsUpadted)
        {
            UpdateFileData(FileName,vClientInf);
            cout<<"The Account Updated Successfully"<<endl;
        }
        
    }else
    {
        cout<<"The Account << "<<AccountNumber <<" >> Not Found!"<<endl;
    }
}

void FindClientByAccountNumber(string FileName,vector<stClientInf>&vClientsInf)
{   
    string AccountNumber= ReadString("Enter The Account Number?");

    if(CachClientByAccountNumber(FileName,AccountNumber,vClientsInf))
    {   
        for(stClientInf &Rec : vClientsInf)
        {
            if(Rec.Settings.MarkClient)
            {
                DisplayClientInfo(Rec);
                Rec.Settings.MarkClient=false;
                break;
            }
        }

    }else
    {
        cout<<"The Account << "<<AccountNumber <<" >> Not Found!"<<endl;
    }
}

void ShowClientInfAsList(stClientInf Client)
{
    cout<<"| "<<setw(15)<<left <<Client.AccountNumber
        <<"| "<<setw(15)<<left <<Client.PinCode
        <<"| "<<setw(40)<<left <<Client.FullName
        <<"| "<<setw(15)<<left <<Client.Phone
        <<"| "<<setw(30)<<left <<Client.AccountBalance;
}

void DisplayClientsList(vector <stClientInf> &vClientsInf)
{
    cout<<Tabs(4)<<"Clients List << "<<vClientsInf.size()<<" >> Client(s)"<<endl;

    cout<<"\n===============================================================================================================\n";
    cout<<"| "<<setw(15)<<left <<"Account Number"
        <<"| "<<setw(15)<<left <<"Pin Code"
        <<"| "<<setw(40)<<left <<"Client Name"
        <<"| "<<setw(15)<<left <<"Phone number"
        <<"| "<<setw(30)<<left <<"Account Balance";
    cout<<"\n===============================================================================================================\n";

    if(vClientsInf.size() != 0)
    {
        for(stClientInf &Client :vClientsInf)
        {
            ShowClientInfAsList(Client);
            cout<<endl;
        }
    }else
    {
        cout<<Tabs(4)<<"!!! Client List is << Empty >> !!!" <<endl;
    }
    
    
}

void Logout()
{
    cout<<"\n----------------------------------\n\n";
    cout<<Tabs(1)<<"Program Ends :)"<<endl;
    cout<<"\n----------------------------------\n";
}

enMainMenuOptins GetUserOption()
{   
    short Opt=ReadNumberInRange(1,6,"Enter the option number you want from [1] To [6]");
    return (enMainMenuOptins) Opt;
}

void GoBackToMainMenu()
{
    cout<<"Press [Enter] to go back to the Main Menu...";
    cin.ignore();
    cin.get();    
    DispalyMainMenu();

}

void ProgramBrain(enMainMenuOptins userOption)
{
    vector <stClientInf> vClientsInf;
    vClientsInf=LoadClientDataFromFile(FileName);
    
    switch (userOption)
    {
    case enMainMenuOptins::eShowClientsList :
        system("clear");
        DisplayClientsList(vClientsInf);
        GoBackToMainMenu();
        break;
    
    case enMainMenuOptins::eAddNewClient :
        system("clear");
        AddNewClients(FileName,vClientsInf);
        GoBackToMainMenu();
        
        break;

    case enMainMenuOptins::eDeleteClient :
        system("clear");
        DeleteClientAccount(FileName,vClientsInf);
        GoBackToMainMenu();
        break;

    case enMainMenuOptins::eUpdateClientInf :
        system("clear");
        UpdateClientsInfo(FileName,vClientsInf);
        GoBackToMainMenu();
        break;

    case enMainMenuOptins::eFindClient :
        system("clear");
        FindClientByAccountNumber(FileName,vClientsInf);
        GoBackToMainMenu();
        break;

    case enMainMenuOptins::Exit :
        system("clear");
        Logout();
        break;

    default:
        GoBackToMainMenu();
        break;
    }
}

void DispalyMainMenu()
{
    system("clear");
    cout<<"\n``````````````````````````````````````````````````````````````\n";
    cout<<Tabs(3)<<"Main Menu Screen."<<endl;
    cout<<"\n``````````````````````````````````````````````````````````````\n";

    cout<<Tabs(2)<<"[1] Show clients List"<<endl;
    cout<<Tabs(2)<<"[2] Add New clients"<<endl;
    cout<<Tabs(2)<<"[3] Delete client"<<endl;
    cout<<Tabs(2)<<"[4] Update client Info"<<endl;
    cout<<Tabs(2)<<"[5] Find client"<<endl;
    cout<<Tabs(2)<<"[6] Exit"<<endl;
    cout<<"\n``````````````````````````````````````````````````````````````\n";
    enMainMenuOptins userOption=GetUserOption();
    ProgramBrain(userOption);
}

int main()
{
    
    DispalyMainMenu();

    return 0;
}