#pragma once
#include<iostream>
#include"clsUtil.h"
#include"Global.h"
#include"clsBankUser.h"
#include"clsDate.h"

using namespace std;

class clsScreen
{

protected:

    static void _DrawScreenHeader(string Title, string SubTitle = "")
    {
        Date::clsDate Date;
        cout << endl << clsUtil::Tabs(5) << "----------------------------------------------\n\n";
        cout << clsUtil::Tabs(7) << Title << endl;

        if (SubTitle != "")
        {
            cout << clsUtil::Tabs(6) << "********************************\n\n";
            cout << clsUtil::Tabs(7) << SubTitle << endl;
        }
        cout << endl << clsUtil::Tabs(5) << "<< " << Date.DateToString() << " >> (User)-->[ " << CurrentUser.UserName() << " ]";
        cout << endl << clsUtil::Tabs(5) << "----------------------------------------------\n";

    }

    static bool CheckAccessPermissionRights(clsBankUser::enPermissions Permission)
    {
        if (!CurrentUser.CheckAccessPermissions(Permission))
        {
            cout << endl << clsUtil::Tabs(5) << "======================================================\n";
            cout << clsUtil::Tabs(6) << "Access Denied! You Have No Access To This Field\n";
            cout << clsUtil::Tabs(7) << "Please Contact Your Admin.";
            cout << endl << clsUtil::Tabs(5) << "======================================================\n";
            return false;
        }
        else
        {
            return true;
        }
    }


};
