#pragma once
#include<iostream>
#include<vector>
#include<string>
#include<fstream>
#include"clsPerson.h"
#include"../Libs/clsString.h"


using namespace std;

class clsBankUser : public clsPerson
{   
    enum enMode{eEmptyMode=0, eUpdateMode=1,eAddNewMode=2};
    enMode _Mode;
    string _UserName;
    string _PassWord;
    int _Permissions;

    bool _MarkForDelete=false;
    bool _Ignored=false;

    
    string _ConvertCurrentUserObjectToLine(clsBankUser User,string Separator="#//#")
    {   Date::clsDate Date= Date::clsDate::GetCurrentDate_Time();
        string Line="";
        Line+=Date::clsDate::Date_Time_ToString(Date) + Separator;
        Line+=User.UserName() + Separator;
        Line+=Str::clsString::Encryption(User.Password(),5) + Separator;
        Line+=to_string(User.Permissions());
        return Line;
    }
    void _AddLoginHistoryToFile(string Data)
    {
        fstream Reg;
        Reg.open("TxtFiles/LoginRegister.txt", ios::out | ios::app);
        if(Reg.is_open())
        {
            Reg<< Data <<endl;
        }
        Reg.close();
    }    

    static clsBankUser _ConvertLineToUserObject(string Line, string Separator="#//#")
    {
        vector <string> vUserData;
        vUserData=Str::clsString::Split(Line,Separator);
        return clsBankUser(enMode::eUpdateMode,vUserData[0],vUserData[1],vUserData[2],vUserData[3],vUserData[4],Str::clsString::Decryption(vUserData[5],5),stod(vUserData[6]));
    }

    static string _ConverUserObjectToLine(clsBankUser User, string Separator="#//#")
    {
        string Line="";
        Line=User.FirstName() + Separator;
        Line+=User.LastName() + Separator;
        Line+=User.Email() + Separator;
        Line+=User.Phone() + Separator;
        Line+=User.UserName() + Separator;
        Line+=Str::clsString::Encryption(User.Password(),5) + Separator;
        Line+=to_string(User.Permissions());
        return Line;

    }

    static clsBankUser _GetEmptyUserObject()
    {
        return clsBankUser(enMode::eEmptyMode,"","","","","","",0);
    }

    static vector<clsBankUser> _LoadUserDataFromFile()
    {
        vector <clsBankUser> _vUser;
        fstream Data;
        Data.open("TxtFiles/UsersData.txt", ios::in);
        if(Data.is_open())
        {   
            string Line;
            while (getline(Data, Line))
            {   
                clsBankUser User=_ConvertLineToUserObject(Line);
                _vUser.push_back(User);
            }
            
        }
        Data.close();
        return _vUser;
    }
    
    static void _SaveUsersDataToFile(vector<clsBankUser>&_vUser )
    {
        fstream Data;
        Data.open("TxtFiles/UsersData.txt", ios::out);
        if(Data.is_open())
        {   
            string Line;
            for(clsBankUser &U : _vUser)
            {   
                if(U._MarkForDelete == false)
                {
                    Line=_ConverUserObjectToLine(U);
                    Data << Line <<endl;
                }
                
            }
        }
        Data.close();

    }
   
    static void _AddDataLineToFile(string DataLine)
   {
        fstream Data;
        Data.open("TxtFiles/UsersData.txt",ios::out | ios::app);
        if(Data.is_open())
        {
            Data<< DataLine <<endl;
        }
        Data.close();
   }
    
    void _Update()
    {
        vector <clsBankUser> _vUser;
        _vUser=_LoadUserDataFromFile();

        for(clsBankUser &U : _vUser )
        {
            if(U.UserName()== UserName())
            {
                U= *this;
                break;
            }
        }

        _SaveUsersDataToFile(_vUser);
    }
    void _AddNew()
    {
        _AddDataLineToFile(_ConverUserObjectToLine(*this));
    }
    
public:

    enum enPermissions
    {pAll=-1, pListClients=1, pAddNewClient=2, pDeleteClient=4, pUpdateClient=8,
     pFindClient=16, pTransactions=32, pManageUsers=64, pLogingHistory=128};

    struct stLogHistData
    {
        string Date_Time="";
        string UserName="";
        string Password="";
        int Permisions=0;
    };
    struct stTransfersHistory
    {
        string Date_Time="";
        string FromAccountNumber="";
        string ToAccountNumber="";
        double Amount=0;
        double AcountFromBalanceAfterSend=0;
        double AcountToBalanceAfterRecieve=0;
        string UserName="";
    };

private:
    string _ConvertTransferRecordInfToLine(stTransfersHistory TransHistory,string Separator="#//#")
    {
        string Line="";
        Line+=TransHistory.Date_Time + Separator;
        Line+=TransHistory.FromAccountNumber + Separator;
        Line+=TransHistory.ToAccountNumber+ Separator;
        Line+=to_string(TransHistory.Amount) + Separator;
        Line+=to_string(TransHistory.AcountFromBalanceAfterSend) + Separator;
        Line+=to_string(TransHistory.AcountToBalanceAfterRecieve) + Separator;
        Line+=TransHistory.UserName;
        
        return Line;
    }
   
    static stTransfersHistory _ConvertLineToTransfersLogRecord(string Line, string Separator="#//#")
    {
        stTransfersHistory Hist;
        vector<string>vHist=Str::clsString::Split(Line,Separator);

        Hist.Date_Time=vHist[0];
        Hist.FromAccountNumber=vHist[1];
        Hist.ToAccountNumber=vHist[2];
        Hist.Amount= stod(vHist[3]);
        Hist.AcountFromBalanceAfterSend= stod(vHist[4]);
        Hist.AcountToBalanceAfterRecieve= stod(vHist[5]);
        Hist.UserName=vHist[6];
        return Hist;

    }

    void _AddTransfersHistoryToFile(string Line)
    {
        fstream Hist;
        Hist.open("TxtFiles/TransfersLogHistory.txt", ios::out | ios::app);
        if(Hist.is_open())
        {
            Hist<< Line <<endl;
        }
        Hist.close();
    }
   
    static vector<stTransfersHistory> _LoadTransfersHistoryFromFile()
    {   
        vector<stTransfersHistory> vTransLog;
        fstream TransFile;
        TransFile.open("TxtFiles/TransfersLogHistory.txt",ios::in);
        if(TransFile.is_open())
        {
            string Line="";
            while(getline(TransFile, Line))
            {   if(Line !="")
                {
                    vTransLog.push_back(_ConvertLineToTransfersLogRecord(Line));
                }
            }
        }
        TransFile.close();
        return vTransLog;
    }
    
    static stLogHistData _ConverLineToLoginHistRecord(string Line,string Separator="#//#")
    {
        stLogHistData Data;
        
        vector<string>vLoginHist=Str::clsString::Split(Line,Separator);
        Data.Date_Time=vLoginHist[0];
        Data.UserName= vLoginHist[1];
        Data.Password=Str::clsString::Decryption(vLoginHist[2],5);
        Data.Permisions=stoi(vLoginHist[3]);
        return Data;
    }
public:

     clsBankUser(enMode Mode, string FirstName,string LastName,string Email,string Phone,string UserName,string Password,int Permissions)
        : clsPerson(FirstName,LastName,Email,Phone)
    {
        _Mode=Mode;
        _UserName=UserName;
        _PassWord=Password;
        _Permissions=Permissions;
    }

    bool IsEmpty()
    {
        return _Mode == enMode::eEmptyMode;
    }
    void SetMarkForDelete(bool Mark)
    {
        _MarkForDelete=Mark;
    }

    void RegisterLogin()
    {
        _AddLoginHistoryToFile(_ConvertCurrentUserObjectToLine(*this));
    }
    void RegisterTransfers(stTransfersHistory stTransfersHist)
    {   stTransfersHist.UserName=_UserName;
        _AddTransfersHistoryToFile(_ConvertTransferRecordInfToLine(stTransfersHist));
    }

    static vector<stTransfersHistory> GetTransfersLogData()
    {
        return _LoadTransfersHistoryFromFile();   
    }

    static vector<stLogHistData> _GetHistoryLogingData()
    {
        vector<stLogHistData>vHistData;
        fstream Hist;
        Hist.open("TxtFiles/LoginRegister.txt", ios::in);
        if(Hist.is_open())
        {
            string Line;
            while(getline(Hist, Line))
            {
                if(Line!="")
                {
                    vHistData.push_back(_ConverLineToLoginHistRecord(Line));
                }
            }

        }
        Hist.close();
        return vHistData;
    }

    void SetUserName(string userName)
    {
        _UserName=userName;
    }
    void SetPassWord(string PassWord)
    {
        _PassWord=PassWord;
    }
    void SetPermissions(int Permissions)
    {
        _Permissions=Permissions;
    }
    void SetIsIgnored(bool Ignored)
    {
        _Ignored=Ignored;
    }
   
    string UserName()
    {
        return _UserName;
    }
    string Password()
    {
        return _PassWord;
    }
    int Permissions()
    {
        return _Permissions;
    }

    bool IsMarkForDelete()
    {
        return _MarkForDelete;
    }
    bool IsIgnored()
    {
        return _Ignored;
    }
    
    static clsBankUser Find(string UserName)
    {
        
        fstream UsersData;
        UsersData.open("TxtFiles/UsersData.txt", ios::in);
        if(UsersData.is_open())
        {
            string Line;
            while(getline(UsersData, Line))
            {
                clsBankUser User= _ConvertLineToUserObject(Line);
                if(User.UserName() == UserName)
                {
                    UsersData.close();
                    return User;
                }
                
            }

        }
        UsersData.close();

        return _GetEmptyUserObject();
    }
    static clsBankUser Find(string UserName, string PassWord)
    {
        
        fstream ClientsData;
        ClientsData.open("TxtFiles/UsersData.txt", ios::in);
        if(ClientsData.is_open())
        {
            string Line;
            while(getline(ClientsData, Line))
            {
                clsBankUser User= _ConvertLineToUserObject(Line);
                if(User.UserName() == UserName && PassWord == User.Password())
                {
                    ClientsData.close();
                    return User;
                }

            }

        }
        ClientsData.close();

        return _GetEmptyUserObject();
    }

    enum enUpdateOptions{eIgnore= 0, eAll=1, eCustom=2};
    enum enSaveResult{svFaildEmptyObject=0,svSucceeded=1, svFaildAccountReserved=2};

    enSaveResult Save()
    {
        switch (_Mode)
        {
        case enMode::eEmptyMode :
            return enSaveResult::svFaildEmptyObject;
        
        case enMode::eUpdateMode :
            
            _Update();
            return  enSaveResult::svSucceeded;
        
        case enMode::eAddNewMode :

            if(IsUserExist(_UserName))
            {
                return enSaveResult::svFaildAccountReserved;
            }else
            {
                _AddNew();
                _Mode=enMode::eUpdateMode;
                return enSaveResult::svSucceeded;
            }
         
        default:

            return enSaveResult::svFaildEmptyObject; 
        }
    }

    static bool IsUserExist(string UserName)
    {
        clsBankUser User= clsBankUser::Find(UserName);
        return (!User.IsEmpty());
    }

    static clsBankUser GetAddNewClientObject(string UserName)
    {
        return clsBankUser(enMode::eAddNewMode,"","","","",UserName,"",0);
    }

    bool Delete()
    {
        vector<clsBankUser> vUser;
        vUser=_LoadUserDataFromFile();

        for(clsBankUser &U : vUser)
        {
            if(_UserName == U.UserName())
            {
                U._MarkForDelete=true;
                break;
            }
        }
        _SaveUsersDataToFile(vUser);
        *this=_GetEmptyUserObject();
        return true;
    }

    static vector<clsBankUser> GetUsersData()
    {
        return _LoadUserDataFromFile();
    }
    
    bool CheckAccessPermissions(enPermissions Permissions)
    {
        return((Permissions == enPermissions::pAll) || (( Permissions & _Permissions) == Permissions) ) ? true : false;
    }
};