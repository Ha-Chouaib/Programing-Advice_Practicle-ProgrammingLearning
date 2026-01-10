#pragma once
#include<iostream>
#include<iomanip>
#include"clsScreen.h"
#include"clsBankClient.h"
#include"clsInputValidate.h"
#include"clsListUserScreen.h"
#include"clsAddNewUserScreen.h"
#include"clsDeleteUserScreen.h"
#include"clsUpdateUserScreen.h"
#include"clsFindUserScreen.h"

using namespace std;

class clsManageUsersScreen : protected clsScreen
{
    enum enManageUsersOptions
    {
        eListUsers = 1,
        eAddNewUser = 2,
        eDeleteUser = 3,
        eUpdateUser = 4,
        eFindUser = 5,
        eMainMenu = 6,
    };

    static short _ReadManageOptions()
    {
        return clsInputValidate<short>::ReadNumberInRange(1, 6, "Please Get Your Option From (1) To (6)");
    }

    static void _GoBackToManageUsersMenu()
    {
        cout << "\nPress [Enter] Key To Go Back To Manage Users Menu...\n";
        cin.ignore();
        cin.get();
        DisplayManageUsersMenu();
    }
    static void _ListUsersScreen()
    {
        clsListUsersScreen::ShowUsersList();
    }
    static void _AddNewUserScreen()
    {
        clsAddNewUserScreen::DisplayAddNewUserScreen();
    }
    static void _DeleteUserScreen()
    {
        clsDeleteUserScreen::DeleteUserScreen();
    }
    static void _UpdateUserScreen()
    {
        clsUpdateUserScreen::UpdateUserScreen();
    }
    static void _FindUserScreen()
    {
        clsFindUserScreen::FindUserScreen();
    }
    static void _BackToMainMenu()
    {
        //cout<<"Back To Main Menu Screen\n";
    }

    static void _ManageUsersBrain(enManageUsersOptions Option)
    {
        switch (Option)
        {
        case enManageUsersOptions::eListUsers:
            system("clear");
            _ListUsersScreen();
            _GoBackToManageUsersMenu();
            break;
        case enManageUsersOptions::eAddNewUser:
            system("clear");
            _AddNewUserScreen();
            _GoBackToManageUsersMenu();
            break;
        case enManageUsersOptions::eDeleteUser:
            system("clear");
            _DeleteUserScreen();
            _GoBackToManageUsersMenu();
            break;
        case enManageUsersOptions::eUpdateUser:
            system("clear");
            _UpdateUserScreen();
            _GoBackToManageUsersMenu();
            break;
        case enManageUsersOptions::eFindUser:
            system("clear");
            _FindUserScreen();
            _GoBackToManageUsersMenu();
            break;
        case enManageUsersOptions::eMainMenu:
            system("clear");
            _BackToMainMenu();
            break;

        default:
            _GoBackToManageUsersMenu();
            break;
        }
    }

public:

    static void DisplayManageUsersMenu()
    {
        if (!CheckAccessPermissionRights(clsBankUser::enPermissions::pManageUsers))
        {
            return;
        }
        system("clear");
        _DrawScreenHeader("Manage Users Screen", "Manage Menu");
        cout << endl << clsUtil::Tabs(5) << "========================================\n\n";
        cout << clsUtil::Tabs(6) << "[1]-->(List Users-------)\n";
        cout << clsUtil::Tabs(6) << "[2]-->(Add New Users----)\n";
        cout << clsUtil::Tabs(6) << "[3]-->(Delete User------)\n";
        cout << clsUtil::Tabs(6) << "[4]-->(Update User------)\n";
        cout << clsUtil::Tabs(6) << "[5]-->(Find User--------)\n";
        cout << clsUtil::Tabs(6) << "[6]-->(Back To Main Menu)\n";
        cout << endl << clsUtil::Tabs(5) << "========================================\n\n";

        _ManageUsersBrain((enManageUsersOptions)_ReadManageOptions());
    }

};


