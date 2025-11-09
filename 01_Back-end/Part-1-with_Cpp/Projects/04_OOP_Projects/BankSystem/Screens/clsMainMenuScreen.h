#pragma once
#include <iostream>
#include"../Libs/clsInputValidate.h"
#include"../Libs/clsUtil.h"
#include"clsScreen.h"
#include"Clients/clsClientListScreen.h"
#include"Clients/clsAddNewClientScreen.h"
#include"Clients/clsDeleteClientScreen.h"
#include"Clients/clsUpdateClientScreen.h"
#include"Clients/clsFindClientScreen.h"
#include"clsTransactionScreen.h"
#include"Users/clsManageUsersScreen.h"
#include"clsLoginScreen.h"
#include"../RootClasses/clsBankUser.h"
#include"../RootClasses/Global.h"
#include"clsLoginHistoryScreen.h"
#include"Currency/clsCurrencyExchangeMenuScreen.h"
using namespace std;


class clsMainMenuScreen : protected clsScreen
{
    enum enMainMenuOption
    {
        eShowClientsList=1,     
        eAddNewClient=2,        
        eDeleteClient=3,        
        eUpdateClientInf=4, 
        eFindClient=5,
        eTransaction=6,
        eManageUsers=7,
        eLoginHistory=8,    
        eCurrencyExchange=9,    
        eLogout=10,    
    };

    static short _ReadMainMenuOption()
    {
       cout<<clsUtil::Tabs(5)<<"<< Get Your Option >>"<<endl;
       return clsInputValidate<short>::ReadNumberInRange(1,10,"Please Enter a number form [1]-->[10]?");
    }

    static void _GoBackToMainMenu()
    {
        cout<<"\nPress [Enter] Key to Go Back To Main Menu..."<<endl;
        cin.ignore();
        cin.get();
        DisplayMainMenuScreen();
    }

    static void _DisplayClientsListScreen()
    {
        clsClientListScreen::ShowClientList();
    }

    static void _DisplayAddNewClientScreen()
    {
        clsAddNewClientScreen::AddNewClient();
    }

    static void _DisplayDeleteClientScreen()
    {
        clsDeleteClientScreen::DeleteClient();
    }

    static void _DisplayUpdateClientScreen()
    {
        clsUpdateClientScreen::UpdateClient();
    }

    static void _DisplayFindClientScreen()
    {
        clsFindClientScreen::FindClient();
    }

    static void _DisplayTransactoinScreen()
    {
        clsTransactionScreen::TransactionMenu();
    }

    static void _DisplayManageUsersScreen()
    {
        clsManageUsersScreen::DisplayManageUsersMenu();
    }

    static void _LoginHistoryScreen()
    {
        clsLoginHistoryScreen::DiplayLoginHistoryScreen();
    }

    static void _CurrencyExchangeScreen()
    {
        clsCurrencyMenuScreen::DisplayCurrencyMenuScreen();
    }

    static void _Logout()
    {
        CurrentUser=clsBankUser::Find("","");
    }

    static void _MainMenuBrain(enMainMenuOption Option)
    {
        switch (Option)
        {
        case enMainMenuOption::eShowClientsList :
            system("clear");
            _DisplayClientsListScreen();
            _GoBackToMainMenu();
            break;
        case enMainMenuOption::eAddNewClient :
            system("clear");
            _DisplayAddNewClientScreen();
            _GoBackToMainMenu();
            break;
        case enMainMenuOption::eDeleteClient :
            system("clear");
            _DisplayDeleteClientScreen();
            _GoBackToMainMenu();
            break;
        case enMainMenuOption::eUpdateClientInf :
            system("clear");
            _DisplayUpdateClientScreen();
            _GoBackToMainMenu();
            break;
        case enMainMenuOption::eFindClient :
            system("clear");
            _DisplayFindClientScreen();
            _GoBackToMainMenu();
            break;
        case enMainMenuOption::eTransaction :
            system("clear");
            _DisplayTransactoinScreen();
            _GoBackToMainMenu();
            break;
        case enMainMenuOption::eManageUsers :
            system("clear");
            _DisplayManageUsersScreen();
            _GoBackToMainMenu();
            break;
        case enMainMenuOption::eLoginHistory :
            system("clear");
            _LoginHistoryScreen();
            _GoBackToMainMenu();
            break;
        case enMainMenuOption::eCurrencyExchange :
            system("clear");
            _CurrencyExchangeScreen();
            _GoBackToMainMenu();
            break;
        case enMainMenuOption::eLogout :
            system("clear");
            _Logout();
            
            break;
        
        default:
            _GoBackToMainMenu();
            break;
        }
    }
public:

    static void DisplayMainMenuScreen()
    {
        system("clear");
        _DrawScreenHeader("Main Screen");

        cout<<endl<<clsUtil::Tabs(5)<<"========================================\n\n";
        cout<<clsUtil::Tabs(7)<<"Main Menu\n";
        cout<<endl<<clsUtil::Tabs(5)<<"========================================\n\n";
        cout<<clsUtil::Tabs(6)<<"[1]-->(Show Clients List)\n";
        cout<<clsUtil::Tabs(6)<<"[2]-->(Add New Client---)\n";
        cout<<clsUtil::Tabs(6)<<"[3]-->(Delete Client----)\n";
        cout<<clsUtil::Tabs(6)<<"[4]-->(Update Client----)\n";
        cout<<clsUtil::Tabs(6)<<"[5]-->(Find Client------)\n";
        cout<<clsUtil::Tabs(6)<<"[6]-->(Transaction------)\n";
        cout<<clsUtil::Tabs(6)<<"[7]-->(Manage Users-----)\n";
        cout<<clsUtil::Tabs(6)<<"[8]-->(Login History----)\n";
        cout<<clsUtil::Tabs(6)<<"[9]-->(Currency Exchange)\n";
        cout<<clsUtil::Tabs(6)<<"[10]------>(Logout)\n";
        cout<<endl<<clsUtil::Tabs(5)<<"========================================\n\n";

        _MainMenuBrain((enMainMenuOption)_ReadMainMenuOption());
    }
};
