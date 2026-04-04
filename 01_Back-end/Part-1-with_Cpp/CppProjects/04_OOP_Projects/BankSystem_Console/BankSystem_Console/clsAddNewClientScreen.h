#pragma once
#include<iostream>
#include"clsScreen.h"
#include"clsBankClient.h"
#include"clsUtil.h"
#include"clsInputValidate.h"


using namespace std;

class clsAddNewClientScreen : protected clsScreen
{
    static void _ReadClientInfo(clsBankClient& Client)
    {
        Client.SetFirstName(clsInputValidate<string>::ReadString("Enter First Name: "));
        Client.SetLastName(clsInputValidate<string>::ReadString("Enter Last Name: "));
        Client.SetEmail(clsInputValidate<string>::ReadString("Enter Email: "));
        Client.SetPhone(clsInputValidate<string>::ReadString("Enter Phone: "));
        Client.SetPinCode(clsInputValidate<string>::ReadString("Pin_Code: "));
        Client.SetAccountBAllance(clsInputValidate<double>::ReadNumber("Enter Ballance: "));
    }

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
    static void AddNewClient()
    {
        if (!CheckAccessPermissionRights(clsBankUser::enPermissions::pAddNewClient))
        {
            return;
        }
        _DrawScreenHeader("+ Add New Client Screen +");

        string AccountNumber = clsInputValidate<string>::ReadString("Enter Account Number? ");
        while (clsBankClient::IsClientExist(AccountNumber))
        {
            AccountNumber = clsInputValidate<string>::ReadString("Account Number Reserved, Please Enter Another One: ");
        }

        clsBankClient NewClient = clsBankClient::GetAddNewClientObject(AccountNumber);
        _ReadClientInfo(NewClient);

        if (clsUtil::AreYouSure("Sure To Complete This Operation? (Y/N)."))
        {
            clsBankClient::enSaveResult SaveResult;
            SaveResult = NewClient.Save();

            switch (SaveResult)
            {
            case clsBankClient::enSaveResult::svSucceeded:

                cout << "\nThe Account Added Successfully\n";
                _printClientCard(NewClient);
                break;
            case clsBankClient::enSaveResult::svFaildAccountReserved:

                cout << "\nThe Operation Faild this Account Number Alrady Exist.\n";
                break;
            default:
                cout << "\nUnexpected Error!" << endl;
                break;
            }
        }
        else
        {
            cout << "\nThe Operation Has Been Ignored Successfully\n";
        }
    }

};
