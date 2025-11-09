#pragma once
#include<iostream>
#include"clsScreen.h"
#include"../RootClasses/clsBankClient.h"
#include"../Libs/clsInputValidate.h"
#include"Clients/clsDepositScreen.h"
#include"Clients/clsWithdrawScreen.h"
#include"Clients/clsTotalBalanceScreen.h"
#include"clsTransferScreen.h"
#include"clsTransfersLogHistoryScreen.h"
using namespace std;

class clsTransactionScreen :protected clsScreen
{
    enum enTransactionOptions
    {   eDeposit=1, 
        eWithdraw=2,
        eTotalBalance=3,
        eTransfer=4,
        eTransfersLog=5,
        eMainMenu=6,
    };

    static short _ReadTransOption()
    {
        return clsInputValidate<short>::ReadNumberInRange(1,6,"Please Get Your Option From (1) To (6)");
    }

    static void _BackToTransactionMenu()
    {
        cout<<"\nPress [Enter] Key To Go Back To Transaction Menu\n";
        cin.ignore();
        cin.get();
        TransactionMenu();

    }

    static void _Deposit()
    {
        clsDepositScreen::DepositScreen();
    }
    static void _Withdraw()
    {
        clsWithdrawScreen::DepositScreen();
    }
    static void _TotalBalance()
    {
        clsTotalBalanceScreen::ShowTotalBalances();
    }
    static void _Transfer()
    {
        clsTransferScreen::DisplayTransferScreen();
    }
    static void _TransfersLog()
    {
        clsTransfersLogScren::DisplayTransfersHistoryList();
        
    }
    static void _BackToMainMenu()
    {
        //cout<<"MainMenu Screen\n";
    }
    
    static void _TransactionBrain(enTransactionOptions Option)
    {
        switch (Option)
        {
        case enTransactionOptions::eDeposit :
            system("clear");
            _Deposit();
            _BackToTransactionMenu();
            break;
        case enTransactionOptions::eWithdraw :
            system("clear");
            _Withdraw();
            _BackToTransactionMenu();
            break;
        case enTransactionOptions::eTotalBalance :
            system("clear");
            _TotalBalance();
            _BackToTransactionMenu();
            break;
        case enTransactionOptions::eTransfer :
            system("clear");
            _Transfer();
            _BackToTransactionMenu();
            break;
        case enTransactionOptions::eTransfersLog :
            system("clear");
            _TransfersLog();
            _BackToTransactionMenu();
            break;
        case enTransactionOptions::eMainMenu :
            system("clear");
            _BackToMainMenu();          
            break;
        
        default:
            _BackToTransactionMenu();
            break;
        }
    }

public:

    static void TransactionMenu()
    {
        if(!CheckAccessPermissionRights(clsBankUser::enPermissions::pTransactions))
        {
            return;
        }
        system("clear");
        _DrawScreenHeader("Transaction Screen");

        cout<<endl<<clsUtil::Tabs(5)<<"========================================\n\n";
        cout<<clsUtil::Tabs(7)<<"Transaction Menu\n";
        cout<<endl<<clsUtil::Tabs(5)<<"========================================\n\n";
        cout<<clsUtil::Tabs(6)<<"[1]-->(Deposit----------)\n";
        cout<<clsUtil::Tabs(6)<<"[2]-->(Withdraw---------)\n";
        cout<<clsUtil::Tabs(6)<<"[3]-->(Total Balances---)\n";
        cout<<clsUtil::Tabs(6)<<"[4]-->(Transfer---------)\n";
        cout<<clsUtil::Tabs(6)<<"[5]-->(Transfers Log----)\n";
        cout<<clsUtil::Tabs(6)<<"[6]-->(Back To Main Menu)\n";
        cout<<endl<<clsUtil::Tabs(5)<<"========================================\n\n";

        _TransactionBrain((enTransactionOptions) _ReadTransOption());
        
    }

};
