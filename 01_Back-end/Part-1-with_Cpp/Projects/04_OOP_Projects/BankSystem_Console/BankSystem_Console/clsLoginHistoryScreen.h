#pragma once
#include<iostream>
#include<vector>
#include<iomanip>
#include<fstream>
#include"clsScreen.h"
#include"clsBankUser.h"
#include"clsString.h"
#include"clsUtil.h"
using namespace std;

class clsLoginHistoryScreen : protected clsScreen
{


    static void _ListUserLoginHistory(clsBankUser::stLogHistData Data)
    {
        cout << clsUtil::Tabs(3) << "|" << left << setw(30) << Data.Date_Time
            << "|" << left << setw(25) << Data.UserName
            << "|" << left << setw(20) << Data.Password
            << "|" << left << setw(15) << Data.Permisions << endl;
    }

public:

    static void DiplayLoginHistoryScreen()
    {
        if (!CheckAccessPermissionRights(clsBankUser::enPermissions::pLogingHistory))
        {
            return;
        }
        vector<clsBankUser::stLogHistData>vLogHist = clsBankUser::_GetHistoryLogingData();
        _DrawScreenHeader("Login History", ".[ " + to_string(vLogHist.size()) + " ] Record(s).");

        cout << endl << clsUtil::Tabs(3) << "===========================================================================================\n";
        cout << clsUtil::Tabs(3) << "|" << left << setw(30) << "Date/Time"
            << "|" << left << setw(25) << "User Name"
            << "|" << left << setw(20) << "Password"
            << "|" << left << setw(15) << "Permissions";
        cout << endl << clsUtil::Tabs(3) << "===========================================================================================\n";

        if (vLogHist.size() == 0)
        {
            cout << clsUtil::Tabs(6) << "\n[ No History To Show ]\n";
        }
        else
        {
            for (clsBankUser::stLogHistData R : vLogHist)
            {
                _ListUserLoginHistory(R);
            }
            cout << endl << clsUtil::Tabs(3) << "===========================================================================================\n";

        }

    }

};