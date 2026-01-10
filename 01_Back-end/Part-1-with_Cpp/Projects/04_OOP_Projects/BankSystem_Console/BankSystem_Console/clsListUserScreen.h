#pragma once
#include<iostream>
#include<iomanip>
#include"clsScreen.h"
#include"clsBankUser.h"

using namespace std;
class clsListUsersScreen : protected clsScreen
{
    static void _ListUserInfo(clsBankUser User)
    {

        cout << "| " << left << setw(15) << User.UserName()
            << "| " << left << setw(20) << User.FullName()
            << "| " << left << setw(12) << User.Phone()
            << "| " << left << setw(40) << User.Email()
            << "| " << left << setw(10) << User.Password()
            << "| " << left << setw(12) << User.Permissions() << endl;
    }


public:


    static void ShowUsersList()
    {
        vector<clsBankUser>vUsers = clsBankUser::GetUsersData();
        string Title = "[ Users List ]";
        string SubTitle = "<< " + to_string(vUsers.size()) + " >>" + " User(s)";

        _DrawScreenHeader(Title, SubTitle);

        cout << "------------------------------------------------------------------------------------------------------------------------\n";

        cout << "| " << left << setw(15) << "User Name"
            << "| " << left << setw(20) << "Full Name"
            << "| " << left << setw(12) << "Phone"
            << "| " << left << setw(40) << "Email"
            << "| " << left << setw(10) << "PassWord"
            << "| " << left << setw(12) << "Permissions" << endl;
        cout << "------------------------------------------------------------------------------------------------------------------------\n";
        cout << "| " << left << setw(15) << "" << "| " << left << setw(20) << "" << "| " << left << setw(12) << ""
            << "| " << left << setw(40) << "" << "| " << left << setw(10) << "" << "| " << left << setw(12) << "" << endl;
        if (vUsers.size() == 0)
        {
            cout << endl << clsUtil::Tabs(3) << "<< Empty ! >>" << endl;
        }
        else
        {
            for (clsBankUser& U : vUsers)
            {
                _ListUserInfo(U);
            }
        }

        cout << "------------------------------------------------------------------------------------------------------------------------\n";

    }


};
