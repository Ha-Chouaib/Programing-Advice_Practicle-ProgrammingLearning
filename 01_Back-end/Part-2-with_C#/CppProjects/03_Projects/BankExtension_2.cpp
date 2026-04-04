#include <iostream>
#include <string>
#include <vector>
#include <fstream>
#include <iomanip>
#include <cctype>
#include <limits>

using namespace std;
const string ClinetFileName ="ClientsData.txt";
const string UsersFileName ="UsersData.txt";


enum enUserPermissions
{           
    pAll=-1,
    pShowClientList=1,
    pAddNewClient=2,
    pDeletClient=4,
    pUpdateClient=8,
    pFindClient=16,
    pTransaction=32,
    pManageUser=64
   
};
enum enUserOptions
{
    eListUsers=1,   eAddNewUsers=2,
    eDeleteUsers=3, eUpdateUsers=4,
    eFindUser=5,    eGoMainmenu=6,
};
enum enMainMenuOptins
{
    eShowClientsList=1,
    eAddNewClient=2,
    eDeleteClient=3,
    eUpdateClientInf=4,
    eFindClient=5,
    eTransaction=6,
    eManageUsers=7,
    eLogout=8,
};
enum enTransActionMenu
{
    eDeposit=1,
    eWithdraw=2,
    eTotalBalances=3,
    eMainMenu=4,
};


struct stSettings
{
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

struct stUsersInfo
{
    string FullName="";
    string PassWord="";
    int Permissions=0;
};

int * CurrentUserPermissions;

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

string ChangStrCase(string Str, bool ToLower=true)
{  
    for(int i=0; i<Str.length(); i++)
    {
        if(ToLower)
            Str[i]=char(tolower(Str[i]));
        else
            Str[i]=char(toupper(Str[i]));
    }
    return Str;
}

void Login();
void DispalyMainMenu();
void DisplayTransActionMenu();
void DisplayManageUsersMenu();
void GoBackToMainMenu();
void GoBackToManageMenu();

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

bool CachClientByAccountNumber(string FileName,vector<stClientInf> &vClientInf, string AccountNumber )
{   
    vector <stClientInf> vClientsData;
    vClientsData=LoadClientDataFromFile(FileName);
    for(stClientInf &Rec : vClientsData)
    {
        if(Rec.AccountNumber == AccountNumber)
        {   
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

    while(CachClientByAccountNumber(FileName,vClientInf,Client.AccountNumber) && toupper(stillAdd)=='Y')
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

bool CheckAccessPermission(enUserPermissions Permission)
{   
    if((* CurrentUserPermissions & Permission) == enUserPermissions::pAll)
        return true;
    if((* CurrentUserPermissions & Permission) == Permission)
        return true;
    else 
        return false;
}

void ShowPermissionDeniedMSG()
{
    printf("\n            <<! Access Denied !>>           \n\n");
    printf("You Have No Permission To This Operation.\n");
    printf("Please contact your Admin.\n");
    cout<<"\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n\n";
}

void AddNewClients(string FileName,vector<stClientInf> &vClientInf,string Separator="#//#")
{   
    if(!CheckAccessPermission(enUserPermissions::pAddNewClient))
    {
        ShowPermissionDeniedMSG();
        GoBackToMainMenu();
        return;
    }
    
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
        if(!CachClientByAccountNumber(FileName,vClientInf,sClientinf.AccountNumber))
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

vector<stClientInf> RemoveAccount(vector<stClientInf> &vClientInf,string AccountNumber)
{   
    vector <stClientInf> vClientData;
    for(stClientInf &Client : vClientInf)
    {
        if(Client.AccountNumber != AccountNumber)
        {
            vClientData.push_back(Client);
        }
    }
    return vClientData;
}

void DeleteClientAccount(string FileName,vector <stClientInf>&vClientsInf )
{   
    if(!CheckAccessPermission(enUserPermissions::pDeletClient))
    {
        ShowPermissionDeniedMSG();
        GoBackToMainMenu();
        return;
    }
    cout<<"\n- - - - - - - - - - - - - - - - - - - - - - -\n";
    cout<<Tabs(2)<<"Delete Cleient Field."<<endl;
    cout<<"\n- - - - - - - - - - - - - - - - - - - - - - -\n";

    string AccountNumber= ReadString("Enter The Account Number?");
    vector<stClientInf>vNewClietsRecord;
    if(CachClientByAccountNumber(FileName,vClientsInf,AccountNumber))
    {   
        for(stClientInf &Rec : vClientsInf)
        {   
            if(Rec.AccountNumber == AccountNumber)
            {   
                char Del='n';
                DisplayClientInfo(Rec);

                cout<<"\nAre you sure to delete the Account? (y/n)"<<endl;
                cin>>Del;
                if(toupper(Del) == 'Y')
                {
                    vNewClietsRecord= RemoveAccount(vClientsInf,AccountNumber);
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
    
    return Client.Settings.IsUpadted;
    }
    return Client.Settings.IsUpadted=false;
}

void UpdateClientsInfo(string FileName,vector<stClientInf>&vClientInf)
{  
    if(!CheckAccessPermission(enUserPermissions::pUpdateClient))
    {
        ShowPermissionDeniedMSG();
        GoBackToMainMenu();
        return;
    }
    
    cout<<"\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n";
    cout<<Tabs(3)<<"Update Field."<<endl;
    cout<<"\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n";

    string AccountNumber= ReadString("Enter The Account Number?");

    if(CachClientByAccountNumber(FileName,vClientInf,AccountNumber))
    {   
        stClientInf UpdatedInf;
        for(stClientInf &Rec : vClientInf)
        {
            if(Rec.AccountNumber == AccountNumber)
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

double GetAmount(string despositORwithdraw)
{   
    double Amount=0;
    cout<<"Please Enter The "<< despositORwithdraw<<"Amount"<<endl;
    cin>> Amount;
    return Amount;
}

void DepositMoney(string FileName)
{
    cout<<"\n+++++++++++++++++++++++++++++++++++++++++++++++++\n\n";
    cout<<Tabs(2)<<"<< Deposit Field >>"<<endl;
    cout<<"\n+++++++++++++++++++++++++++++++++++++++++++++++++\n";

    vector<stClientInf> vClientInf;
    vClientInf= LoadClientDataFromFile(FileName);
    string AccountNumber= ReadString("Enter The Account Number?");

    if(CachClientByAccountNumber(FileName,vClientInf,AccountNumber))
    {   
        for(stClientInf &Rec : vClientInf)
        {
            if(Rec.AccountNumber == AccountNumber)
            {   
                double HowMuchToAdd=0;
                DisplayClientInfo(Rec);
                HowMuchToAdd= GetAmount("desposit");
                char AreyouSure='Y';
    
                cout<<"Are you sure to Add <<" <<HowMuchToAdd<<" >> ? (y/n)"<<endl;
                cin>>AreyouSure;

                if(toupper(AreyouSure)== 'Y')
                {
                    Rec.AccountBalance += HowMuchToAdd;
                    UpdateFileData(FileName,vClientInf);
                    cout<<"The Deposit Amount Added successfully."<<endl;
                    system("sleep 3");
                }
                
                break; 

            }
        }

    }else
    {
        cout<<"The Account << "<<AccountNumber <<" >> Not Found!"<<endl;
        cout<<"press [Enter] Key to go back to the Transaction screen."<<endl;
        cin.ignore();
        cin.get();
    }
}

void WithdrawMoney(string FileName)
{
    cout<<"\n- - - - - - - - - - - - - - - - - - - - - - - - - -\n\n";
    cout<<Tabs(2)<<"<< Withdraw Field >>"<<endl;
    cout<<"\n- - - - - - - - - - - - - - - - - - - - - - - - - -\n";

    vector<stClientInf> vClientInf;
    vClientInf=LoadClientDataFromFile(FileName);

    string AccountNumber= ReadString("Enter The Account Number?");
    if(CachClientByAccountNumber(FileName,vClientInf,AccountNumber))
    {   
        for(stClientInf &Rec : vClientInf)
        {
            if(Rec.AccountNumber == AccountNumber)
            {   
                double HowMuchToDeduct=0;
                DisplayClientInfo(Rec);
                HowMuchToDeduct= GetAmount("Withdraw");
                
                char AreyouSure='Y';
                while(Rec.AccountBalance < HowMuchToDeduct)
                {
                    cout<<"The amount exceeds the balance !!"<<endl;
                    cout<<"You can Withdraw up to [ "<<Rec.AccountBalance <<" ]."<<endl;
                    HowMuchToDeduct= GetAmount("Withdraw");
                    
                }
                
                cout<<"Are you sure to deduct the amount <<" <<HowMuchToDeduct <<" >> ? (y/n)"<<endl;
                cin>>AreyouSure;

                if(toupper(AreyouSure)== 'Y')
                {
                    Rec.AccountBalance -= HowMuchToDeduct;
                    UpdateFileData(FileName,vClientInf);
                    cout<<"The Amount Deducted successfully."<<endl;
                    system("sleep 3");
                }
                break; 

            }
        }

    }else
    {
        cout<<"The Account << "<<AccountNumber <<" >> Not Found!"<<endl;
        cout<<"press [Enter] Key to go back to the Transaction screen."<<endl;
        cin.ignore();
        cin.get();
    }

}

void ShowClientBalanceAsList(stClientInf Client)
{
    cout<<"| "<<setw(20)<<left <<Client.AccountNumber
        <<"| "<<setw(40)<<left <<Client.FullName
        <<"| "<<setw(20)<<left <<Client.AccountBalance;
        
}

void DisplayTotalBalancesList()
{
    vector <stClientInf> vClientsInf;
    vClientsInf =LoadClientDataFromFile(ClinetFileName);
    cout<<Tabs(4)<<"Clients List << "<<vClientsInf.size()<<" >> Client(s)"<<endl;

    cout<<"\n===============================================================================================================\n";
    cout<<"| "<<setw(20)<<left <<"Account Number"
        <<"| "<<setw(40)<<left <<"Client Name"
        <<"| "<<setw(20)<<left <<"Account Balance"<<endl;
        
    cout<<"\n===============================================================================================================\n";

    if(vClientsInf.size() != 0)
    {   double TotBalance=0;
        for(stClientInf &Client :vClientsInf)
        {
            ShowClientBalanceAsList(Client);
            TotBalance+=Client.AccountBalance;
            cout<<endl;
        }
        cout<<Tabs(4)<<"Total Balance <<"<< TotBalance<<">>"<<endl;
        cout<<"press [Enter] Key to go back to the Transaction screen."<<endl;
        cin.ignore();
        cin.get();
    }else
    {
        cout<<Tabs(4)<<"!!! Client List is << Empty >> !!!" <<endl;
        system("sleep 3");
    }
}

void FindClientByAccountNumber(string FileName)
{   
    if(!CheckAccessPermission(enUserPermissions::pFindClient))
    {
        ShowPermissionDeniedMSG();
        GoBackToMainMenu();
        return;
    }
    cout<<"\n- - - - - - - - - - - - - - - - - - - - - - - - - -\n\n";
    cout<<Tabs(2)<<"<< Find Client Field >>"<<endl;
    cout<<"\n- - - - - - - - - - - - - - - - - - - - - - - - - -\n";

    string AccountNumber= ReadString("Enter The Account Number?");
    vector<stClientInf>vClientsInf;
    vClientsInf=LoadClientDataFromFile(FileName);

    if(CachClientByAccountNumber(FileName,vClientsInf,AccountNumber))
    {   
        for(stClientInf &Rec : vClientsInf)
        {
            if(Rec.AccountNumber ==AccountNumber)
            {
                DisplayClientInfo(Rec);
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

void DisplayClientsList()
{
    if(!CheckAccessPermission(enUserPermissions::pShowClientList))
    {
        ShowPermissionDeniedMSG();
        GoBackToMainMenu();
        return;
    }
    
    vector <stClientInf> vClientsInf;
    vClientsInf=LoadClientDataFromFile(ClinetFileName);
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

//--------------------------UserField----------------------------
stUsersInfo LineToUserRecord(string UserData,string Separator="#//#")
{
    vector <string>vUser;
    stUsersInfo UserInf;

    vUser= Split(UserData,Separator);

    UserInf.FullName=vUser[0];
    UserInf.PassWord=vUser[1];
    UserInf.Permissions= stoi(vUser[2]);
    
    
    return UserInf;
}

vector <stUsersInfo> LoadUserDataFromFile(string FileName,string Separator="#//#")
{   
    vector <stUsersInfo> vUsers;

    fstream LoadData;
    LoadData.open(FileName,ios::in);
    if(LoadData.is_open())
    {
        string line="";
        stUsersInfo UserInf;
        while(getline(LoadData, line))
        {
            UserInf=LineToUserRecord(line,Separator);
            vUsers.push_back(UserInf);
        }
    }
    LoadData.close();
    return vUsers;
}

bool CatchUserByName(vector<stUsersInfo> &vUsersInf,string Name)
{
    for(stUsersInfo &User: vUsersInf)
    {
        if(User.FullName == Name)
        {
            return true;
            break;
        }   
    }
    return false;
}

int GetPermissions()
{
    int Permissions=0;
    char IsFullAccess='n';
    cout<<"\nDo you Want Give The User Full access? (y/n)";
    cin>>IsFullAccess;

    if(toupper(IsFullAccess) != 'Y')
    {
        cout<<"\n-----------[Permissions]-----------\n";
        char Yes_No='n';

        printf("\nShow Clients List (y/n)? ");
        cin>>Yes_No;
        if(toupper(Yes_No) == 'Y')
        {
            Permissions+=enUserPermissions::pShowClientList;
        }

        printf("\nAdd New Clients (y/n)? ");
        cin>>Yes_No;
        if(toupper(Yes_No) == 'Y')
        {
            Permissions+=enUserPermissions::pAddNewClient;            
        }

        printf("\nDelete Clients (y/n)? ");
        cin>>Yes_No;
        if(toupper(Yes_No) == 'Y')
        {
            Permissions+=enUserPermissions::pDeletClient;            
        }

        printf("\nUpdate Clients (y/n)? ");
        cin>>Yes_No;
        if(toupper(Yes_No) == 'Y')
        {
            Permissions+=enUserPermissions::pUpdateClient;
        }

        printf("\nFind Clients (y/n)? ");
        cin>>Yes_No;
        if(toupper(Yes_No) == 'Y')
        {
            Permissions+=enUserPermissions::pFindClient;          
        }

        printf("\nTransaction (y/n)? ");
        cin>>Yes_No;
        if(toupper(Yes_No) == 'Y')
        {
            Permissions+=enUserPermissions::pTransaction;
        }

        printf("\nManage Users (y/n)? ");
        cin>>Yes_No;
        if(toupper(Yes_No) == 'Y')
        {
            Permissions+=enUserPermissions::pManageUser;
        }

    }else
    {
        return Permissions=-1;
    }
    return Permissions;
}

stUsersInfo ReadUserInf()
{   
    vector<stUsersInfo>vUsers=LoadUserDataFromFile(UsersFileName);
    stUsersInfo User;
    User.FullName=ReadString("Enter Name: ");
    while(CatchUserByName(vUsers,User.FullName))
    {
        printf("\nThe user [%s] is Alrady existed please enter another name!\n",User.FullName.c_str());
        User.FullName=ReadString("Enter Name: ");
    }
    User.PassWord=ReadString("Please enter a password?");
    User.Permissions =GetPermissions();
    return User;
}

string UserRecordToLine(stUsersInfo UserInf, string Separatore="#//#")
{
    string UserDataInLine="";
    
    UserDataInLine=UserInf.FullName + Separatore;
    UserDataInLine+=UserInf.PassWord + Separatore;
    UserDataInLine+=to_string(UserInf.Permissions);
    return UserDataInLine;
}

void UpdateUserFileData(string FileName, vector <stUsersInfo> &vUsersInf)
{
    fstream updateData;
    updateData.open(FileName, ios::out);
    if(updateData.is_open())
    {   
        string line="";
        for(stUsersInfo &Rec : vUsersInf)
        {
            line=UserRecordToLine(Rec);
            updateData << line <<endl;
        }
    }
    updateData.close();

}

void AddUserDataToFile(string FileName,string UserData)
{
    fstream UserInfo;
    UserInfo.open(FileName, ios::out | ios::app);

    if(UserInfo.is_open())
    {
        UserInfo<< UserData <<endl;
    }
    UserInfo.close();
}

void ShowUserInfAsList(stUsersInfo User)
{
    cout<<"| "<<setw(40)<<left <<User.FullName
        <<"| "<<setw(15)<<left <<User.PassWord
        <<"| "<<setw(10)<<left <<User.Permissions;
        
}

void DisplayUsersList()
{
    vector <stUsersInfo> vUsersInfo;
    vUsersInfo =LoadUserDataFromFile(UsersFileName);
    cout<<Tabs(4)<<"Clients List << "<<vUsersInfo.size()<<" >> Client(s)"<<endl;

    cout<<"\n==============================================================================\n";
    cout<<"| "<<setw(40)<<left <<"User Name"
        <<"| "<<setw(15)<<left <<"Password"
        <<"| "<<setw(10)<<left <<"Permission"<<endl;
        
    cout<<"\n==============================================================================\n";

    if(vUsersInfo.size() != 0)
    {  
        for(stUsersInfo &User: vUsersInfo)
        {
            ShowUserInfAsList(User);
            cout<<endl;
        }
       
    }else
    {
        cout<<Tabs(4)<<"!!! Users List is << Empty >> !!!" <<endl;
    }
}

void AddNewUser()
{
    cout<<"\n++++++++++++++++++++++++++++++++++\n";
    cout<< Tabs(1)<<"Adding Users Field."<<endl;
    cout<<"\n++++++++++++++++++++++++++++++++++\n";
    
    stUsersInfo UserInf;
    char AddMore='Y';
    do{
        UserInf=ReadUserInf();
        char AreYouSure='Y';

        cout<<"Are you Sure to Add the user ["<<UserInf.FullName <<"] (y/n)?"<<endl;
        cin>>AreYouSure;

        if(toupper(AreYouSure)== 'Y')
        {
            AddUserDataToFile(UsersFileName,UserRecordToLine(UserInf));

            cout<<"\nUser Added SuccessFully.\n";
            system("sleep 2");
            system("clear");
        }else
        {   
            system("clear");
            cout<<"\nThe Operation Has Been Cancelled\n";    
        }
        cout<<"\nDo you wanna add More? (y/n)? ";
        cin>>AddMore;
        
    }while(toupper(AddMore) == 'Y');

    
}

void DisplayUserInf(stUsersInfo User)
{   cout<<"\n\n-------------------[ "<<User.FullName<<" ] Acount-------------------\n";
    
    printf("User Pin Code: [%s]\n",User.PassWord.c_str());
    printf("User Permissions: [%d]\n",User.Permissions);
    cout<<"\n-------------------------------------------------\n";
}

void RemoveUserAccount(stUsersInfo User)
{
    vector<stUsersInfo> vUsers=LoadUserDataFromFile(UsersFileName);
    vector<stUsersInfo> vUsers_New;

    for(stUsersInfo &stUser : vUsers)
    {
        if(User.FullName !=stUser.FullName )
        {
            vUsers_New.push_back(stUser);
        }
    }
    UpdateUserFileData(UsersFileName,vUsers_New);
}

void DeleteUser()
{   
    cout<<"\n++++++++++++++++++++++++++++++++++\n";
    cout<< Tabs(1)<<"Delete Users Field."<<endl;
    cout<<"\n++++++++++++++++++++++++++++++++++\n";
    vector<stUsersInfo> vUsers=LoadUserDataFromFile(UsersFileName);
    string UserName=ReadString("Enter User Name");
    char DelMore='n';

    
    do
    {
        if(ChangStrCase(UserName)  != "admin")
        {
             if(CatchUserByName(vUsers,UserName))
            {
                for(stUsersInfo &User : vUsers)
                {
                    if(User.FullName == UserName)
                    {   char AreYouSure='n';
                        DisplayUserInf(User);
                        cout<<"Are you Sure to Remove User Account? (y/n) "<<endl;
                        cin>>AreYouSure;
                        if(toupper(AreYouSure) == 'Y')
                        {
                            RemoveUserAccount(User);
                            cout<<"\nThe User Account Deleted Successfully" <<endl;
                            system("sleep 2");
                            system("clear");
                            break;
                        }else
                        {
                            system("sleep 2");
                            system("clear");
                            cout<<"\nThe Operation has been ignored"<<endl;
                            break;
                        }
                    }
                }
            }else
            {
                cout<<"\nThe User Account Not Exist\n";
            }
        }else
        {
            cout<<"\nYou Can Not Delete The Admin Acount !!!"<<endl;
        }

        cout<<"Do you Want Delete More Users (y/n) "<<endl;
        cin>>DelMore;
    } while (toupper(DelMore)=='Y');

}

stUsersInfo GetUpdatedUserInf(stUsersInfo User)
{
    User.PassWord=ReadString("Pin_Code: ");
    User.Permissions=GetPermissions();

    return User;
}

void UpdateUserInfo()
{
    cout<<"\n++++++++++++++++++++++++++++++++++\n";
    cout<< Tabs(1)<<"Update Users Field."<<endl;
    cout<<"\n++++++++++++++++++++++++++++++++++\n";
    vector<stUsersInfo> vUsers=LoadUserDataFromFile(UsersFileName);
    char UpdateMore='n';
    do
    {
        string UserName=ReadString("Enter User Name");
        if(CatchUserByName(vUsers,UserName))
        {
            for (stUsersInfo &User : vUsers)
            {
                if (User.FullName == UserName)
                {   char AreYouSure='n';
                    DisplayUserInf(User);

                    cout<<"\nAre you sure to update the "<<User.FullName<<"Account (y/n)\n";
                    cin>>AreYouSure;
                    if(toupper(AreYouSure) == 'Y')
                    {
                        User=GetUpdatedUserInf(User);
                        UpdateUserFileData(UsersFileName,vUsers);
                        cout<<"\nThe Account Updated successfully"<<endl;
                        system("sleep 2");
                        system("clear");
                        break;
                    }else
                    {
                        cout<<"\nThe Operation Has Been Ignored successfully"<<endl;
                        system("sleep 2");
                        system("clear");
                        break;
                    }
                }
            }
        }else
        {
            cout<<"\nThe user Count Doesn't Exist"<<endl;
        }
        cout<<"\nDo you wanna update More Users Info (y/n)"<<endl;
        cin>>UpdateMore;
    } while (toupper(UpdateMore)=='Y');
    

}

void FindUserByName()
{
    cout<<"\n++++++++++++++++++++++++++++++++++\n\n";
    cout<< Tabs(1)<<"Find Users Field."<<endl;
    cout<<"\n++++++++++++++++++++++++++++++++++\n";
    vector<stUsersInfo> vUsers=LoadUserDataFromFile(UsersFileName);
    char ShowMore='n';
    do
    {   
        string UserName=ReadString("Enter User Name");
        if(CatchUserByName(vUsers,UserName))
        {
           for(stUsersInfo &user : vUsers)
           {
                if(user.FullName == UserName)
                {
                    DisplayUserInf(user);
                    break;
                }
           } 
        }else
        {
            cout<<"\nUser Not Found!"<<endl;
        }
        cout<<"Do You wanna SearCh for one More User (y/n)? "<<endl;
        cin>>ShowMore;
        
    } while (toupper(ShowMore)== 'Y');
}

enUserOptions GetManageUsersOptions()
{
    return (enUserOptions) ReadNumberInRange(1,6,"Get Your Option From (1)-->(6)");
}

void ManageUsers(enUserOptions Option)
{
    switch (Option)
    {
    case enUserOptions::eListUsers :
        system("clear");
        DisplayUsersList();
        GoBackToManageMenu();
        break;
    case enUserOptions::eAddNewUsers  :
        system("clear");
        AddNewUser();
        GoBackToManageMenu();
        break;
    case enUserOptions::eDeleteUsers :
        system("clear");
        DeleteUser();
        GoBackToManageMenu();
        break;
    case enUserOptions::eUpdateUsers :
        system("clear");
        UpdateUserInfo();
        GoBackToManageMenu();
        break;
    case enUserOptions::eFindUser :
        system("clear");
        FindUserByName();
        GoBackToManageMenu();
        break;
    case enUserOptions::eGoMainmenu :
        DispalyMainMenu();
        break;
    
    default:
        break;
    }
}

void DisplayManageUsersMenu()
{
    if(!CheckAccessPermission(enUserPermissions::pManageUser))
    {
        ShowPermissionDeniedMSG();
        GoBackToMainMenu();
        return;
    }
    
    system("clear");
    cout<<"\n--------------------------------------------------------------\n";
    cout<<Tabs(3)<<"[ Manage Users Menu ]"<<endl;
    cout<<"\n--------------------------------------------------------------\n";

    cout<<Tabs(2)<<"[1] << Show Users List >>"<<endl;
    cout<<Tabs(2)<<"[2] << Add New Users >>"<<endl;
    cout<<Tabs(2)<<"[3] << Delete Users >>"<<endl;
    cout<<Tabs(2)<<"[4] << Update Users >>"<<endl;
    cout<<Tabs(2)<<"[5] << Find Users >>"<<endl;
    cout<<Tabs(2)<<"[6] << Back to main Menu >>"<<endl;
    cout<<"\n--------------------------------------------------------------\n";

    ManageUsers(GetManageUsersOptions());
}

void GoBackToManageMenu()
{
    cout<<"\nPress [Enter] Key To Go back To Manage users Menu ..."<<endl;
    cin.ignore();
    cin.get();
    DisplayManageUsersMenu();
}

//+++++++++++++++++++++++++++++++++++++++++^^userField^^+++++++++++++++++++++++++++++++++++++++++++++++


enMainMenuOptins GetUserOption()
{   
    short Opt=0;
    Opt=ReadNumberInRange(1,8,"Enter the option number you want from [1] To [8]");
    return (enMainMenuOptins) Opt;
}

enTransActionMenu GetTransActionOption()
{
     
    short Option=0;
    Option=ReadNumberInRange(1,4,"Enter the option number you want from [1] To [4]");
    return (enTransActionMenu) Option;
}

void TransactionClientsAccount(enTransActionMenu TransactionOption)
{
    
    switch (TransactionOption)
    {
    case enTransActionMenu::eDeposit :
        system("clear");
        DepositMoney(ClinetFileName);
        DisplayTransActionMenu();
        break;
    case enTransActionMenu::eWithdraw :
        system("clear");
        WithdrawMoney(ClinetFileName);
        DisplayTransActionMenu();
        break;
    case enTransActionMenu::eTotalBalances :
        system("clear");
        DisplayTotalBalancesList();
        DisplayTransActionMenu();
        break;
    case enTransActionMenu::eMainMenu :
        system("clear");
        DispalyMainMenu();
        
        break;
    
    default:
        system("clear");
        DisplayTransActionMenu();
        break;
    }
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
    vClientsInf=LoadClientDataFromFile(ClinetFileName);
    
    switch (userOption)
    {
    case enMainMenuOptins::eShowClientsList :
        system("clear");
        DisplayClientsList();
        GoBackToMainMenu();
        break;
    
    case enMainMenuOptins::eAddNewClient :
        system("clear");
        AddNewClients(ClinetFileName,vClientsInf);
        GoBackToMainMenu();
        
        break;

    case enMainMenuOptins::eDeleteClient :
        system("clear");
        DeleteClientAccount(ClinetFileName,vClientsInf);
        GoBackToMainMenu();
        break;

    case enMainMenuOptins::eUpdateClientInf :
        system("clear");
        UpdateClientsInfo(ClinetFileName,vClientsInf);
        GoBackToMainMenu();
        break;

    case enMainMenuOptins::eFindClient :
        system("clear");
        FindClientByAccountNumber(ClinetFileName);
        GoBackToMainMenu();
        break;

    case enMainMenuOptins::eTransaction :
        DisplayTransActionMenu();
        break;

    case enMainMenuOptins::eManageUsers :
        system("clear");
        DisplayManageUsersMenu();
        break;
    case enMainMenuOptins::eLogout :
        system("clear");
        Login();
        break;

    default:
        GoBackToMainMenu();
        break;
    }
}

void DisplayTransActionMenu()
{
    if(!CheckAccessPermission(enUserPermissions::pTransaction))
    {
        ShowPermissionDeniedMSG();
        GoBackToMainMenu();
        return;
    }
    
    system("clear");
    cout<<"\n--------------------------------------------------------------\n";
    cout<<Tabs(3)<<"[ Transaction Screen ]"<<endl;
    cout<<"\n--------------------------------------------------------------\n";

    cout<<Tabs(2)<<"[1] << Deposit Money >>"<<endl;
    cout<<Tabs(2)<<"[2] << Withdraw Money >>"<<endl;
    cout<<Tabs(2)<<"[3] << Total Balances >>"<<endl;
    cout<<Tabs(2)<<"[4] << Go Main Menu >>"<<endl;
    cout<<"\n--------------------------------------------------------------\n";
    enTransActionMenu TransOption=GetTransActionOption();
    TransactionClientsAccount(TransOption);
    
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
    cout<<Tabs(2)<<"[6] Transaction"<<endl;
    cout<<Tabs(2)<<"[7] Manage Users"<<endl;
    cout<<Tabs(2)<<"[8] Logout"<<endl;
    cout<<"\n``````````````````````````````````````````````````````````````\n";
    enMainMenuOptins userOption=GetUserOption();
    ProgramBrain(userOption);
}

void Login()
{
    cout<<"\n----------------------------------\n\n";
    cout<<Tabs(1)<<"<< Login >>"<<endl;
    cout<<"\n----------------------------------\n";
    vector<stUsersInfo> vUsers=LoadUserDataFromFile(UsersFileName);
    stUsersInfo User;
    char Invalid='Y';
    do
    {
        User.FullName=ReadString("Please Enter the User Name? ");
        User.PassWord=ReadString("Please Enter the User Password? ");
        for(stUsersInfo &stuser : vUsers)
        {
            if(stuser.FullName == User.FullName && stuser.PassWord == User.PassWord)
            {   
                CurrentUserPermissions= &stuser.Permissions;
                DispalyMainMenu();
                Invalid='N';
                    break;
            }
        }
        cout<<"\nWrong Password/UserName!"<<endl;
    } while (Invalid == 'Y');
    
    
}

int main()
{
    Login();
    

    return 0;
}