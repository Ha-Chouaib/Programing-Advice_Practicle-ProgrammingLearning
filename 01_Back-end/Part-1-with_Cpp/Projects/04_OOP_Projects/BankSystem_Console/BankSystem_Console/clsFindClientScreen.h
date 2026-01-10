
#pragma once
#include<iostream>
#include"clsScreen.h"
#include"clsBankClient.h"
#include"clsInputValidate.h"

using namespace std;


class clsFindClientScreen : protected clsScreen
{
    static void _printClientCard(clsBankClient Client)
    {

        cout << endl << clsUtil::Tabs(2) << "  << Client Card >>" << endl;
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

    static void FindClient()
    {
        if (!CheckAccessPermissionRights(clsBankUser::enPermissions::pFindClient))
        {
            return;
        }
        _DrawScreenHeader("* Find Client Screen *");
        string AccountNumber = clsInputValidate<string>::ReadString("Enter Account Number?");

        while (!clsBankClient::IsClientExist(AccountNumber))
        {
            string AccountNumber = clsInputValidate<string>::ReadString("Not Found! Please Enter a Valid Account Number?");

        }
        clsBankClient Client = clsBankClient::Find(AccountNumber);
        if (!Client.IsEmpty())
            _printClientCard(Client);
        else
            cout << "\nThe Client Has No Data To Show\n";

    }

};