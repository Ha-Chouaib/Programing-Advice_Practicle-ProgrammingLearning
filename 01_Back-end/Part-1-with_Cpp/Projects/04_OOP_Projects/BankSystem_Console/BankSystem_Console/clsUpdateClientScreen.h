#pragma once
#include<iostream>
#include"clsScreen.h"
#include"clsBankClient.h"


using namespace std;

class clsUpdateClientScreen : protected clsScreen
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

    static clsBankClient::enUpdateOptions _ReadUpdateOption()
    {
        return (clsBankClient::enUpdateOptions)clsInputValidate<short>::ReadNumberInRange(0, 2, "Get Your Option: ");
    }

    static void _ReadCustomInf(clsBankClient& Client)
    {
        cout << "\n(First Name)--> [ " << Client.FirstName() << " ]" << endl;
        if (clsUtil::AreYouSure("Update ? (Y/N)."))
        {
            Client.SetFirstName(clsInputValidate<string>::ReadString("First Name: "));
        }

        cout << "\n(Last Name)--> [ " << Client.LastName() << " ]" << endl;
        if (clsUtil::AreYouSure("Update ? (Y/N)."))
        {
            Client.SetLastName(clsInputValidate<string>::ReadString("Last Name: "));
        }

        cout << "\n(Email)--> [ " << Client.Email() << " ]" << endl;
        if (clsUtil::AreYouSure("Update ? (Y/N)."))
        {
            Client.SetEmail(clsInputValidate<string>::ReadString("Email: "));
        }

        cout << "\n(Phone number)--> [ " << Client.Phone() << " ]" << endl;
        if (clsUtil::AreYouSure("Update ? (Y/N)."))
        {
            Client.SetPhone(clsInputValidate<string>::ReadString("Phone: "));
        }

        cout << "\n(PinCode)--> [ " << Client.PinCode() << " ]" << endl;
        if (clsUtil::AreYouSure("Update ? (Y/N)."))
        {
            Client.SetPinCode(clsInputValidate<string>::ReadString("Pin_Code: "));
        }

        cout << "\n(Balance)--> [ " << Client.AccountBallace() << " ]" << endl;
        if (clsUtil::AreYouSure("Update ? (Y/N)."))
        {
            Client.SetAccountBAllance(clsInputValidate<double>::ReadNumber("Ballance: "));
        }
    }

    static void _UpdatedObject(clsBankClient& Client, clsBankClient::enUpdateOptions Option)
    {

        switch (Option)
        {
        case clsBankClient::enUpdateOptions::eIgnore:

            Client.SetIsIgnored(true);
            break;

        case clsBankClient::enUpdateOptions::eAll:

            _ReadClientInfo(Client);
            break;

        case clsBankClient::enUpdateOptions::eCustom:

            _ReadCustomInf(Client);
            break;

        default:

            Client.SetIsIgnored(true);
            break;
        }
    }

    static void _ShowUpdateOptionsMenu(clsBankClient& Client)
    {
        cout << "\n- - - - - - - - - - - - - - - -\n";
        cout << clsUtil::Tabs(3) << "\nUpdate Options:" << endl;
        cout << "\n- - - - - - - - - - - - - - - -\n\n";

        cout << "[0]-->(Ignore Operation) // [1]-->(Update All) // [2]-->(Update Custom Inf)" << endl;

        _UpdatedObject(Client, _ReadUpdateOption());
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

    static void UpdateClient()
    {
        if (!CheckAccessPermissionRights(clsBankUser::enPermissions::pUpdateClient))
        {
            return;
        }
        _DrawScreenHeader(".Update Client Field.");

        string AccountNumber = clsInputValidate<string>::ReadString("Enter AccountNumber");

        while (!clsBankClient::IsClientExist(AccountNumber))
        {
            cout << "The Accout [ " << AccountNumber << " ] Not Exist, Please Enter a Valid acount Number." << endl;
            AccountNumber = clsInputValidate<string>::ReadString(": ");
        }

        clsBankClient Client = clsBankClient::Find(AccountNumber);
        _printClientCard(Client);

        _ShowUpdateOptionsMenu(Client);

        if (!Client.IsIgnored())
        {
            clsBankClient::enSaveResult SaveResult;
            SaveResult = Client.Save();

            switch (SaveResult)
            {
            case clsBankClient::enSaveResult::svFaildEmptyObject:
                cout << "\nError Empty Object the Update Operation Faild \n";
                break;
            case clsBankClient::enSaveResult::svSucceeded:
                cout << "\nAccount Updated Successfully \n";
                _printClientCard(Client);
                break;

            default:
                cout << "\nUnexpected Error!" << endl;
                break;
            }
        }
        else
        {
            cout << "\nThe Operation Has Been Ignored Successfully." << endl;
            Client.SetIsIgnored(false);
        }
    }



};



