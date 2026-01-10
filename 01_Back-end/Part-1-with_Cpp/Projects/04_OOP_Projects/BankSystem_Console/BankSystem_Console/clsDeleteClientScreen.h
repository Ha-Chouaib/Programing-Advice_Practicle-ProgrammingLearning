#pragma once
#include<iostream>
#include"clsBankClient.h"
#include"clsScreen.h"
using namespace std;

class clsDeleteClientScreen :protected clsScreen
{
    static void _printClientCard(clsBankClient Client)
    {

        cout << endl << clsUtil::Tabs(2) << "    << Client Card >>" << endl;
        cout << clsUtil::Tabs(2) << "<< Account Number [ " << Client.AccountNumber() << " ] >>" << endl;
        cout << clsUtil::Tabs(1) << "==============================\n";
        cout << clsUtil::Tabs(1) << "FirstName        : " << Client.FirstName() << endl;
        cout << clsUtil::Tabs(1) << "LastName         : " << Client.LastName() << endl;
        cout << clsUtil::Tabs(1) << "FullName         : " << Client.FullName() << endl;
        cout << clsUtil::Tabs(1) << "Email            : " << Client.Email() << endl;
        cout << clsUtil::Tabs(1) << "Phone            : " << Client.Phone() << endl;
        cout << clsUtil::Tabs(1) << "PassWord         : " << Client.PinCode() << endl;
        cout << clsUtil::Tabs(1) << "Ballance         : " << Client.AccountBallace() << endl;
        cout << clsUtil::Tabs(1) << "==============================\n";
    }

public:
    static void DeleteClient()
    {
        if (!CheckAccessPermissionRights(clsBankUser::enPermissions::pDeleteClient))
        {
            return;
        }
        _DrawScreenHeader("- Delete Client Screen -");
        string AccountNumber;
        AccountNumber = clsInputValidate<string>::ReadString("Enter Account Number?");
        while (!clsBankClient::IsClientExist(AccountNumber))
        {
            AccountNumber = clsInputValidate<string>::ReadString("Account Number Not Exist Please Enter a Valid One!");
        }

        clsBankClient Client = clsBankClient::Find(AccountNumber);
        _printClientCard(Client);

        if (clsUtil::AreYouSure("Are you Sure to Delete this Account? (Y/N)"))
        {
            if (Client.Delete())
            {
                cout << "\nThe Account Deleted Successfully.\n";
            }
            else
            {
                cout << "\nUnexpected Error The Account Not Deleted!\n";
            }

        }
        else
        {
            cout << "\nThe operation Has been Ignored Successfully.\n";
        }
    }

};
