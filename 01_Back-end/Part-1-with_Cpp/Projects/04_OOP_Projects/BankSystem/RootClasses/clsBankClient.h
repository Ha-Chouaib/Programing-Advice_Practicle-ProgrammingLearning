#pragma once
#include<iostream>
#include<fstream>
#include<string>
#include<vector>
#include"clsPerson.h"
#include"../Libs/clsString.h"
#include"../Libs/clsUtil.h"

using namespace std;

class clsBankClient : public clsPerson
{
    enum enMode{eEmptyMode=0, eUpdateMode=1, eAddNewMode=2};
    enMode _Mode;

    string _AccountNumber="";
    string _PinCode="";
    double _AccountBallance=0; 


    bool _MarkForDelete=false;
    bool _IsIgnored=false;

    static clsBankClient _ConvertLineToClientObject(string Line, string Separator="#//#")
    {
        vector <string> vClientData;
        vClientData=Str::clsString::Split(Line,Separator);
        return clsBankClient(enMode::eUpdateMode,vClientData[0],vClientData[1],vClientData[2],vClientData[3],vClientData[4],Str::clsString::Decryption(vClientData[5],5),stod(vClientData[6]));
    }

    static string _ConverClientObjectToLine(clsBankClient Client, string Separator="#//#")
    {
        string Line="";
        Line=Client.FirstName() + Separator;
        Line+=Client.LastName() + Separator;
        Line+=Client.Email() + Separator;
        Line+=Client.Phone() + Separator;
        Line+=Client.AccountNumber() + Separator;
        Line+=Str::clsString::Encryption(Client.PinCode(), 5)  + Separator;
        Line+=to_string(Client.AccountBallace());
        return Line;

    }

    static clsBankClient _GetEmptyClientObject()
    {
        return clsBankClient(enMode::eEmptyMode,"","","","","","",0);
    }

    static vector<clsBankClient> _LoadClientDataFromFile()
    {
        vector <clsBankClient> _vClient;
        fstream Data;
        Data.open("TxtFiles/ClientsData.txt", ios::in);
        if(Data.is_open())
        {   
            string Line;
            while (getline(Data, Line))
            {   
                clsBankClient Client=_ConvertLineToClientObject(Line);
                _vClient.push_back(Client);
            }
            
        }
        Data.close();
        return _vClient;
    }
    
    static void _SaveClientsDataToFile(vector<clsBankClient>&_vClient )
    {
        fstream Data;
        Data.open("TxtFiles/ClientsData.txt", ios::out);
        if(Data.is_open())
        {   
            string Line;
            for(clsBankClient &C : _vClient)
            {   
                if(C._MarkForDelete == false)
                {
                    Line=_ConverClientObjectToLine(C);
                    Data << Line <<endl;
                }
                
            }
        }
        Data.close();

    }
   
    static void _AddDataLineToFile(string DataLine)
   {
        fstream Data;
        Data.open("TxtFiles/ClientsData.txt",ios::out | ios::app);
        if(Data.is_open())
        {
            Data<< DataLine <<endl;
        }
        Data.close();
   }
    
    void _Update()
    {
        vector <clsBankClient> _vClient;
        _vClient=_LoadClientDataFromFile();

        for(clsBankClient &C : _vClient )
        {
            if(C.AccountNumber()== AccountNumber())
            {
                C= *this;
                break;
            }
        }

        _SaveClientsDataToFile(_vClient);
    }
    void _AddNew()
    {
        _AddDataLineToFile(_ConverClientObjectToLine(*this));
    }
    
public:

    clsBankClient(enMode Mode,string FirstName,string LastName,string Email,string Phone,string AccountNumber,string PinCode, double AccountBallace)
                :clsPerson(FirstName,LastName,Email,Phone)
    {
        _Mode=Mode;
        _AccountNumber=AccountNumber;
        _PinCode=PinCode;
        _AccountBallance=AccountBallace;
    }
    
    bool IsEmpty()
    {
        return _Mode == enMode::eEmptyMode;
    }

    void SetPinCode(string PinCode)
    {
        _PinCode=PinCode;
    }
    void SetAccountBAllance(double AccountBallance)
    {
        _AccountBallance=AccountBallance;
    }
    void SetIsIgnored(bool IsIgnored)
    {
        _IsIgnored=IsIgnored;
    }
    void SetMarkForDelete(bool Mark)
    {
         _MarkForDelete= Mark;
    }

    string AccountNumber()
    {
        return _AccountNumber;
    }
    string PinCode()
    {
        return _PinCode;
    }
    double AccountBallace()
    {
        return _AccountBallance;
    }
    bool IsIgnored()
    {
        return _IsIgnored;
    }
    bool IsMarkForDelete()
    {
        return _MarkForDelete;
    }

    static clsBankClient Find(string AccountNumber)
    {
        
        fstream ClientsData;
        ClientsData.open("TxtFiles/ClientsData.txt", ios::in);
        if(ClientsData.is_open())
        {
            string Line;
            while(getline(ClientsData, Line))
            {
                clsBankClient Client= _ConvertLineToClientObject(Line);
                if(Client.AccountNumber() == AccountNumber)
                {
                    ClientsData.close();
                    return Client;
                }
                
            }

        }
        ClientsData.close();

        return _GetEmptyClientObject();
    }
    static clsBankClient Find(string AccountNumber, string PinCode)
    {
        
        fstream ClientsData;
        ClientsData.open("TxtFiles/ClientsData.txt", ios::in);
        if(ClientsData.is_open())
        {
            string Line;
            while(getline(ClientsData, Line))
            {
                clsBankClient Client= _ConvertLineToClientObject(Line);
                if(Client.AccountNumber() == AccountNumber && PinCode == Client.PinCode())
                {
                    ClientsData.close();
                    return Client;
                }

            }

        }
        ClientsData.close();

        return _GetEmptyClientObject();
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

            if(IsClientExist(_AccountNumber))
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

    static bool IsClientExist(string AccountNumber)
    {
        clsBankClient Client= clsBankClient::Find(AccountNumber);
        return (!Client.IsEmpty());
    }

    static clsBankClient GetAddNewClientObject(string AccountNumber)
    {
        return clsBankClient(enMode::eAddNewMode,"","","","",AccountNumber,"",0);
    }

    bool Delete()
    {
        vector<clsBankClient> vClient;
        vClient=_LoadClientDataFromFile();

        for(clsBankClient &C : vClient)
        {
            if(_AccountNumber == C.AccountNumber())
            {
                C._MarkForDelete=true;
                break;
            }
        }
        _SaveClientsDataToFile(vClient);
        *this=_GetEmptyClientObject();
        return true;
    }

    static vector<clsBankClient> GetClientsData()
    {
        return _LoadClientDataFromFile();
    }
    
    void Deposit(double Amount)
    {
        _AccountBallance+=Amount;
        Save();
    }
    bool Withdraw(double Amount)
    {
        if(Amount > _AccountBallance)
        {
            return false;
        }
        else{
            _AccountBallance-=Amount;
            Save();
        }
       return true;
    }
    bool Transfer(double Amount,clsBankClient &DestinationClient)
    {
        if((Amount > _AccountBallance) || (DestinationClient.AccountNumber() ==_AccountNumber))
        {
            return false;
        }
        Withdraw(Amount);
        DestinationClient.Deposit(Amount);
        return true;
    }
    static double GetTotalBalances()
    {
        vector<clsBankClient>vClients=_LoadClientDataFromFile();
        double Tot=0;
        for(clsBankClient &C : vClients)
        {
            Tot +=C.AccountBallace();
        }
        return Tot;  
    }
};