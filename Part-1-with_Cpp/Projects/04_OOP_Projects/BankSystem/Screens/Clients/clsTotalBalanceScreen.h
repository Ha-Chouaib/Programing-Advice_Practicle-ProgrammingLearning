#pragma once
#include<iostream>
#include<iomanip>
#include"../clsScreen.h"
#include"../../RootClasses/clsBankClient.h"
#include"../../Libs/clsInputValidate.h"

using namespace std;

class clsTotalBalanceScreen :protected clsScreen
{
    static void _ListClientBalance(clsBankClient Client)
    {        
        cout<<clsUtil::Tabs(4)<<"| "<<left<<setw(15)<<Client.AccountNumber()
            <<"| "<<left<<setw(20)<<Client.FullName()
            <<"| "<<left<<setw(12)<<Client.AccountBallace()<<" |" <<endl;
    }

public:
    static void ShowTotalBalances()
    {
        _DrawScreenHeader("Transactions","Total Balances");

        vector<clsBankClient>vClients=clsBankClient::GetClientsData();
        cout<<endl<<clsUtil::Tabs(6)<<"[ Clients List ( "<<vClients.size()<<" )_Client ]\n";
        cout<<endl<<clsUtil::Tabs(4)<<"--------------------------------------------------------\n";
        cout<<clsUtil::Tabs(4)<<"| "<<left<<setw(15)<<"Account Number"
            <<"| "<<left<<setw(20)<<"Client Name"
            <<"| "<<left<<setw(12)<<"Balance"<<" |"<<endl;
        cout<<clsUtil::Tabs(4)<<"--------------------------------------------------------\n";
        cout<<endl<<clsUtil::Tabs(4)<<"| "<<left<<setw(15)<<""<<"| "<<left<<setw(20)<<""<<"| "<<left<<setw(12)<<""<<" |"<<endl;

        if(vClients.size()==0)
        {
            cout<<endl<<clsUtil::Tabs(5) <<"<< No Clients available in the System ! >>"<<endl;
        }else
        {   
            double TotalBalances=clsBankClient::GetTotalBalances();
            for(clsBankClient &C : vClients)
            {
                _ListClientBalance(C);
            }
            cout<<endl<< clsUtil::Tabs(6)<<"The Total Balances= [ "<<TotalBalances <<" ]"<<endl;
            cout<<clsUtil::Tabs(4)<<"<<< " <<clsUtil::NumberToTxt(TotalBalances) <<" >>>"<<endl;
        }
    }

};