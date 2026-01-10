#pragma once
#include<iostream>
#include"clsScreen.h"
#include"clsBankUser.h"
#include"clsInputValidate.h"

using namespace std;


class clsFindUserScreen : protected clsScreen
{
    static void _printUserCard(clsBankUser User)
    {

        cout << endl << clsUtil::Tabs(2) << "  << User Card >>" << endl;
        cout << clsUtil::Tabs(2) << "<< User Name [ " << User.UserName() << " ] >>" << endl;
        cout << clsUtil::Tabs(1) << "==============================\n";
        cout << clsUtil::Tabs(1) << "FullName         : " << User.FullName() << endl;
        cout << clsUtil::Tabs(1) << "Email            : " << User.Email() << endl;
        cout << clsUtil::Tabs(1) << "Phone            : " << User.Phone() << endl;
        cout << clsUtil::Tabs(1) << "PassWord         : " << User.Password() << endl;
        cout << clsUtil::Tabs(1) << "Permissions      : " << User.Permissions() << endl;
        cout << clsUtil::Tabs(1) << "==============================\n";
    }


public:

    static void FindUserScreen()
    {
        _DrawScreenHeader("Manage Users", "* Find User Screen *");
        string UserName = clsInputValidate<string>::ReadString("Enter User Name?");

        while (!clsBankUser::IsUserExist(UserName))
        {
            UserName = clsInputValidate<string>::ReadString("Not Found! Please Enter a Valid User Name?");

        }
        clsBankUser User = clsBankUser::Find(UserName);
        if (!User.IsEmpty())
            _printUserCard(User);
        else
            cout << "\nThe User Has No Data To Show\n";

    }

};
