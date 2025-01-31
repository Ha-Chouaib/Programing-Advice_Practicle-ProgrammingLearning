#pragma once 
#include <iostream>
#include<iomanip>
#include"clsScreen.h"
#include"../RootClasses/clsBankClient.h"
#include"../Libs/clsInputValidate.h"
#include"../Libs/clsUtil.h"
#include"../RootClasses/clsBankUser.h"
#include"../RootClasses/Global.h"
#include"../Libs/clsDate.h"

using namespace std;

class clsTransferScreen :protected clsScreen
{
    static clsBankClient _GetClientAccount(string MSG)
    {
        cout<<endl;
        string AccountNumber=clsInputValidate<string>::ReadString(MSG);
        
        while(!clsBankClient::IsClientExist(AccountNumber))
        {
            AccountNumber=clsInputValidate<string>::ReadString("Account Number Not Found Please Enter A Valid one!");   
        }
        
        clsBankClient Client=clsBankClient::Find(AccountNumber);
        return Client;

    }

    static double _ReadAmount()
    {
        return clsInputValidate<double>::ReadNumber("Please Enter The Amount To Transfer?");
    }

    static bool _ValidateAmount(double Amount,double ClientBAlance)
    {
        return (Amount <= ClientBAlance);
    }

    static void _PrintClientInfo(clsBankClient Client,string From_To)
    {   
        cout<<endl<<clsUtil::Tabs(2)<<"[ "<< From_To<<"-->( "<<Client.AccountNumber()<<" )" <<" ]";
        cout<<"\n========================================================\n";
        cout<<"| "<<left<<setw(30)<<"Client Name"<<"| "<<left<<setw(20)<<"Balance"<<" |";
        cout<<"\n========================================================\n";
        cout<<"| "<<left<<setw(30)<<Client.FullName()<<"| "<<left<<setw(20)<<Client.AccountBallace()<<" |";
        cout<<"\n========================================================\n";
    }

    

public:

    static void DisplayTransferScreen()
    {
        _DrawScreenHeader("Transacions","Transfer Screen");

        clsBankClient FromClient=_GetClientAccount("Enter Source Account Number");
        _PrintClientInfo(FromClient,"From");
        
        clsBankClient ToClient=_GetClientAccount("Enter Destination Account Number");
        _PrintClientInfo(ToClient,"To");

        double Amount=0;
        Amount=_ReadAmount();
        
        while(!_ValidateAmount(Amount,FromClient.AccountBallace()))
        {
            Amount=_ReadAmount();
            cout<<"The Amount Exceeds Your Balance [ "<<FromClient.AccountBallace()<<" ]"<<endl;
        }

        if(clsUtil::AreYouSure("Are You Sure To Send[ "+ to_string(Amount) + " ]? (Y/N)"))
        {
        
            if(FromClient.Transfer(Amount,ToClient))
            {   
                clsBankUser::stTransfersHistory TransHist;
                TransHist.Date_Time=Date::clsDate::Date_Time_ToString(Date::clsDate::GetCurrentDate_Time());
                TransHist.FromAccountNumber=FromClient.AccountNumber();
                TransHist.ToAccountNumber=ToClient.AccountNumber();
                TransHist.Amount=Amount;
                TransHist.AcountFromBalanceAfterSend=FromClient.AccountBallace();
                TransHist.AcountToBalanceAfterRecieve=ToClient.AccountBallace();
                
                cout<<"\nThe Amount[ "<<Amount<<" ] Sended Successfully"<<endl;
                _PrintClientInfo(FromClient,"From");

                cout<<"\n\nThe Amount[ "<<Amount<<" ] Received Successfully"<<endl;
                _PrintClientInfo(ToClient,"To");
                CurrentUser.RegisterTransfers(TransHist);

            }else
            {
                cout<<"\nUnexpected Error !";
                cout<<"\nthe Destination Imposible To be The Sender.\n";
            }
            
           
        }else
        {
            cout<<"\nThe Operation Ignored SuccessFully\n";
        }

        
        
        
    }
};