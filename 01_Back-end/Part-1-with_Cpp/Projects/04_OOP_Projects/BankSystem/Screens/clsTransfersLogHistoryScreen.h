#pragma once
#include<iostream>
#include<iomanip>
#include"clsScreen.h"
#include"../RootClasses/clsBankUser.h"
#include"../Libs/clsUtil.h"

using namespace std;

class clsTransfersLogScren : protected clsScreen
{
    static void _ListTranserLog(clsBankUser::stTransfersHistory TransHist)
    {
        cout<<"| "<<left<<setw(25)<<TransHist.Date_Time
            <<"| "<<left<<setw(15)<<TransHist.FromAccountNumber
            <<"| "<<left<<setw(15)<<TransHist.ToAccountNumber
            <<"| "<<left<<setw(10)<<TransHist.Amount
            <<"| "<<left<<setw(20)<<TransHist.AcountFromBalanceAfterSend
            <<"| "<<left<<setw(20)<<TransHist.AcountToBalanceAfterRecieve
            <<"| "<<left<<setw(10)<<TransHist.UserName<<" |"<<endl;
    }

public:

    static void DisplayTransfersHistoryList()
    {
        vector<clsBankUser::stTransfersHistory>vTransHist=clsBankUser::GetTransfersLogData();
        _DrawScreenHeader("Transactions","Transfers History");
        

        cout<<clsUtil::Tabs(6)<<"<< "<<to_string(vTransHist.size())<<" >> Record(s)"<<endl;
        cout<<"==================================================================================================================================\n";

        cout<<"| "<<left<<setw(25)<<"Date-Time"
            <<"| "<<left<<setw(15)<<"<< From.Acc >>"
            <<"| "<<left<<setw(15)<<"<< To.Acc >>"
            <<"| "<<left<<setw(10)<<"Amount"
            <<"| "<<left<<setw(20)<<"Balance-->[Sender]"
            <<"| "<<left<<setw(20)<<"Balance-->[Receiver]"
            <<"| "<<left<<setw(10)<<"User"<<" |"<<endl;
        cout<<"==================================================================================================================================\n";
        cout<<"| "<<left<<setw(25)<<""<<"| "<<left<<setw(15)<<""<<"| "<<left<<setw(15)<<""
            <<"| "<<left<<setw(10)<<""<<"| "<<left<<setw(20)<<""<<"| "<<left<<setw(20)<<""<<left<<setw(10)<<"|"<<endl;

        if(vTransHist.size()==0)
        {
            cout<<clsUtil::Tabs(6)<<"\n.No History To Show.\n";
        }else
        {
            for(clsBankUser::stTransfersHistory &H : vTransHist)
            {
                _ListTranserLog(H);
            cout<<"-----------------------------------------------------------------------------------------------------------------------------------\n";

            }

        }
    
    }
};
