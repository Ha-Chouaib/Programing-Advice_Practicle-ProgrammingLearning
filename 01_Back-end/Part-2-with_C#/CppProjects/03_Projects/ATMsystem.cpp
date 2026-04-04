#include <iostream>
#include <string>
#include <vector>
#include <fstream>
#include <iomanip>
#include <cctype>
#include <limits>

using namespace std;
const string ClinetFileName ="ClientsData.txt";

int ReadPositiveNumber(string MSG)
{
    int num=0;
    do
    {
        cout<< MSG <<endl;
        cin>>num;

        while(cin.fail())
        {
            cin.clear();
            cin.ignore(std::numeric_limits<std::streamsize>::max());
            cout<<"\nPlease Enter an Integer\n";
            cin>>num;
        }
        if(num < 0 )
            cout<<"\nPlease Enter a Positve number\n";

    } while (num < 0);
    return num;
}

short ReadNumberInRange(short From, short To,string MSG)
{
    short num=0;
    do
    {
        cout<< MSG <<endl;
        cin>>num;

        while(cin.fail())
        {
            cin.clear();
            cin.ignore(std::numeric_limits<std::streamsize>::max());
            cout<<"\nPlease Enter an Integer\n";
            cin>>num;
        }
        

    } while (num < From || num > To);
    return num;
}

string ReadString(string MSG)
{
    string str;
    cout<< MSG <<endl;
    getline(cin >> ws, str);
    return str;
}

char ReadChar(string MSG)
{
    char Char;
    cout<< MSG <<endl;
    cin>>Char;
    return Char;
}

enum enQuickWithdraw
{
    e20=1,   e50=2,
    e100=3,  e200=4,
    e400=5,  e600=6,
    e800=7,  e1000=8,
    eExit=9
};
enum enMainMenuOptions
{
    eQuickWithdraw=1,   eNormalWithdraw=2,
    eDeposit=3,         eCheckBalance=4,
    eLogout=5
};

struct stClientLoginInf
{
    string AccountNumber="";
    string Pin_Code="";
};
struct stClient
{   
    string Name="";
    string phone="";
    string OriginAcountNumber="";
    string OriginPinCode="";
    stClientLoginInf LoginInf;
    int sWithdraw=0;
    double sDeposit=0;
    double Ballance=0;
};

stClient CurrentClient;

void ShowQuickWithdrawMenu();
void ShowMainMenu();
void GoBackToMainMenu();
void Login();
vector<string>Split(string Str, string Separator="#//#")
{
    vector <string>vSplit;
    short pos=0;
    string Token="";
    while((pos= Str.find(Separator)) != std::string::npos)
    {
        Token=Str.substr(0,pos);
        if(Token != "")
        {
            vSplit.push_back(Token);
        }
        Token.clear();
        Str.erase(0,pos + Separator.length());
    }
    if(Str !="")
        vSplit.push_back(Str);
    return vSplit;
}

stClient ConvertClientDataLineToRecord(string ClientData,string Separator="#//#")
{   
    vector<string>vData=Split(ClientData);
    stClient Client;

    Client.OriginAcountNumber=vData[0];
    Client.OriginPinCode=vData[1];
    Client.Name=vData[2];
    Client.phone=vData[3];
    Client.Ballance=stoi(vData[4]);

    return Client;
}

string ConvertClientDAtaRecordToLine(stClient ClientRecord,string Separator="#//#")
{
    string Line="";
    Line=ClientRecord.OriginAcountNumber + Separator;
    Line+=ClientRecord.OriginPinCode + Separator;
    Line+= ClientRecord.Name + Separator;
    Line+= ClientRecord.phone + Separator;
    Line+= to_string(ClientRecord.Ballance);

    return Line;
}

vector<stClient> LoadClientsDataFromFile()
{
    vector<stClient>vClient;
    fstream Load;
    Load.open(ClinetFileName, ios::in);
    if(Load.is_open())
    {   
        string Line;
        while (getline(Load, Line))
        {
            vClient.push_back(ConvertClientDataLineToRecord(Line));
        }
    }
    Load.close();
    return vClient;
}

void UpdateClientsFileData(vector <stClient> &vUpdatedData)
{
    fstream Update;
    Update.open(ClinetFileName, ios::out);

    if(Update.is_open())
    {
        for(stClient &Rec : vUpdatedData)
        {
            Update<< ConvertClientDAtaRecordToLine(Rec) <<endl;
        }
    }

    Update.close();
}

enQuickWithdraw GetQuickWithdrawOption()
{
    return (enQuickWithdraw) ReadNumberInRange(1,9,"Please Enter Your Option (1)-->(9)");
}

short QuickWithdrawAmount()
{   
    enQuickWithdraw QuickOption;
    QuickOption=GetQuickWithdrawOption();

    switch (QuickOption)
    {
    case enQuickWithdraw::e20 :
        return 20;
    case enQuickWithdraw::e50 :
        return 50;
    case enQuickWithdraw::e100 :
        return 100;
    case enQuickWithdraw::e200 :
        return 200;
    case enQuickWithdraw::e400 :
        return 400;
    case enQuickWithdraw::e600 :
        return 600;
    case enQuickWithdraw::e800 :
        return 800;
    case enQuickWithdraw::e1000 :
        return 1000;
    case enQuickWithdraw::eExit :
        return 0;
    
    default:
        return 0;
    }
}

void UpdateClientInfo()
{
    vector<stClient>vClient=LoadClientsDataFromFile();
    for(stClient &C : vClient)
    {
        if(C.OriginAcountNumber == CurrentClient.OriginAcountNumber)
        {
            C=CurrentClient;
            break;
        }
    }
    UpdateClientsFileData(vClient);
}

void QuickWithdrawOperation()
{
    short Amount=QuickWithdrawAmount();
    if(Amount == 0)
    {
        GoBackToMainMenu();
    }
    if(Amount > CurrentClient.Ballance)
    {
        cout<<"The Amount You Add[ "<<Amount<<" ] Exceeds Your Ballance << "<<CurrentClient.Ballance<<" >>\n";
        cout<<"Press [Enter] key to Continue..."<<endl; 
        ShowQuickWithdrawMenu();
    }else
    {
        char AreYouSure=ReadChar("Are you sure to Complete this Operation? (y/n)?");
        if(toupper(AreYouSure)== 'Y')
        {            
            CurrentClient.Ballance-=Amount;
            UpdateClientInfo();
            cout<<"\nDone Successfuly your ballance Has Become << "<< CurrentClient.Ballance<<" >>"<<endl;
            GoBackToMainMenu();
        }else
        {
            cout<<"\nThe Operation Has Ignored Successfully."<<endl;
            char IsContinue=ReadChar("Do you still want withdraw Money? (y/n)");
            
            if(toupper(IsContinue)== 'Y')
            {
                ShowQuickWithdrawMenu(); 
            }else
            {
                GoBackToMainMenu();
            }
        }      
    }
}

void ShowQuickWithdrawMenu()
{
    system("clear");
    cout<<"\n----------------------------------------"<<endl;
    cout<<"\n\t\tQuick Withdraw Menu\n";
    cout<<"\n----------------------------------------"<<endl;
    printf("\t[1]->(20)     [2]->(50)\n");
    printf("\t[3]->(100)    [4]->(200)\n");
    printf("\t[5]->(400)    [6]->(600)\n");
    printf("\t[7]->(800)    [8]->(1000)\n");
    printf("\t    [9]-->(Exit)\n");
    QuickWithdrawOperation();
}

void NormalWithdraw()
{   
    bool IsExceeds=false;
    do
    {   
        system("clear");
        cout<<"\n----------------------------------------"<<endl;
        cout<<"\n\tNormal Withdraw Field\n";
        cout<<"\n----------------------------------------"<<endl;
        cout<<endl;

        if(IsExceeds)
        {
            cout<<"\nThe Amount exceeds your ballance you can Withdraw up to << "<<CurrentClient.Ballance <<" >>.\n\n";
        }
        CurrentClient.sWithdraw=ReadPositiveNumber("Please Enter withdraw Amount [Multiple fo 5's] ?");

        if(CurrentClient.Ballance < CurrentClient.sWithdraw)
            IsExceeds=true;
    }while(CurrentClient.sWithdraw % 5 != 0 || CurrentClient.Ballance < CurrentClient.sWithdraw);

    char AreYouSure='n';
    cout<<"\nAre you Sure to Copmlete This Operation? (y/n)\n";
    cin>>AreYouSure;
    if(toupper(AreYouSure) == 'Y')
    {
        CurrentClient.Ballance-=CurrentClient.sWithdraw;
        UpdateClientInfo();
        cout<<"\nDone successfuly your Ballance has become <<"<<CurrentClient.Ballance <<">>." <<endl;
        system("sleep 2");
        
    }else
    {
        cout<<"\nOperation Ignored successfully."<<endl;
        char IsCountinue='n';
        cout<< "\nDo you want continue withdrawing Money? (y/n)\n";
        if(toupper(IsCountinue)=='Y')
        {
            NormalWithdraw();
        }
    }
}

void Deposit()
{
    char DepositMore='n';
    char AreYouSure='n';
    do
    {   
        system("clear");
        cout<<"\n----------------------------------------"<<endl;
        cout<<"\n\t\t Deposit Field\n";
        cout<<"\n----------------------------------------"<<endl;
        cout<<endl;

        CurrentClient.sDeposit=ReadPositiveNumber("Please Enter Deposit Amount?");

        
        cout<<"Are you Sure to Complete This Operation? (y/n)";
        cin>>AreYouSure;

        if(toupper(AreYouSure) == 'Y')
        {
            CurrentClient.Ballance+=CurrentClient.sDeposit;
            UpdateClientInfo();
            cout<<"\nDone successfuly your Ballance has become <<"<<CurrentClient.Ballance <<">>." <<endl;
            
        }else
        {
            cout<<"\nOperation Ignored successfully."<<endl;
        }
        
        cout<< "\nDo you want Deposit More Money? (y/n)";
        cin>>DepositMore;

    }while(toupper(DepositMore)== 'Y');

    
    
}

void CheckBallance()
{
    system("clear");
    cout<<"\n----------------------------------------"<<endl;
    cout<<"\n\t\t Ballance Field\n";
    cout<<"\n----------------------------------------"<<endl;
    cout<<endl;

    cout<<"\t\tYour Ballance is: [ "<< CurrentClient.Ballance<<" ]"<<endl;
    // printf("\t\tYour Ballance is: [ %d ]\n",);
}

enMainMenuOptions GetManiMenuOption()
{
    return (enMainMenuOptions) ReadNumberInRange(1,5,"Please Get Your Option (1)-->(5)");
}

void ATMsystem(enMainMenuOptions MainOption)
{
    switch (MainOption)
    {
    case enMainMenuOptions::eQuickWithdraw :
        ShowQuickWithdrawMenu();
        break;
    case enMainMenuOptions::eNormalWithdraw :
        NormalWithdraw();
        GoBackToMainMenu();
        break;
    case enMainMenuOptions::eDeposit :
        Deposit();
        GoBackToMainMenu();
        break;
    case enMainMenuOptions::eCheckBalance :
        CheckBallance();
        GoBackToMainMenu();
        break;
    case enMainMenuOptions::eLogout :
        Login();
        break;
    
    default:
        cout<<"\nUnexpected error accured\n";
        GoBackToMainMenu();
        break;
    }
}

void ShowMainMenu()
{
    system("clear");
    cout<<"\n--------------------------------------------------------------\n\n";
    cout<<"\t\t\t"<<"[ ATM Menu ]"<<endl;
    cout<<"\n--------------------------------------------------------------\n";

    cout<<"\t\t"<<"[1] << Quick Withdraw >>"<<endl;
    cout<<"\t\t"<<"[2] << Normal Withdraw >>"<<endl;
    cout<<"\t\t"<<"[3] << Deposit >>"<<endl;
    cout<<"\t\t"<<"[4] << Check Ballance >>"<<endl;
    cout<<"\t\t"<<"[5] << Logout >>"<<endl;
    cout<<"\n--------------------------------------------------------------\n";

    ATMsystem(GetManiMenuOption());
}

void GoBackToMainMenu()
{
    cout<<"\nPress [Enter] Key To go back to Main Menu..."<<endl;
    cin.ignore();
    cin.get();
    ShowMainMenu();
}

bool IsValidLogin()
{
    vector<stClient>VClient=LoadClientsDataFromFile();
    for(stClient C : VClient)
    {
        if(C.OriginAcountNumber == CurrentClient.LoginInf.AccountNumber && C.OriginPinCode == CurrentClient.LoginInf.Pin_Code)
        {  
            CurrentClient=C;
            return true;
        }
    }
    return false;    
}

void Login()
{
    bool InvalidLogin= false;
    do
    {
        system("clear");
        cout<<"\n----------------------------------------"<<endl;
        cout<<"\n\t\t<< Login >>\n";
        cout<<"\n----------------------------------------"<<endl;
        cout<<endl;
        
        if(InvalidLogin)
        {
            cout<<"\nInvalid AccountNumber/Password !\n"<<endl;
        }
        CurrentClient.LoginInf.AccountNumber=ReadString("Please enter the Account Number? ");
        CurrentClient.LoginInf.Pin_Code=ReadString("Please enter the Pin Code? ");
        
        InvalidLogin= !IsValidLogin();

    } while (InvalidLogin);

    ShowMainMenu();
}

int main()
{
    Login();
    return 0;
}



