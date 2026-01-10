#pragma once
#include<iostream>
#include"clsScreen.h"
#include"clsBankClient.h"
#include"clsInputValidate.h"
#include"clsUtil.h"

using namespace std;


class clsDepositScreen : protected clsScreen
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

    static string _ReadAccountNumber()
    {
        string AccountNumber = clsInputValidate<string>::ReadString("Please Enter Account Number?");
        while (!clsBankClient::IsClientExist(AccountNumber))
        {
            string AccountNumber = clsInputValidate<string>::ReadString("InValid Account Number Please Try again!");
        }
        return AccountNumber;
    }

public:

    static void DepositScreen()
    {
        _DrawScreenHeader("Transactions", "+ Deposit Screen +");
        string AccountNumber = _ReadAccountNumber();

        clsBankClient Client = clsBankClient::Find(AccountNumber);
        _printClientCard(Client);

        double Amount = 0;
        Amount = clsInputValidate<double>::ReadNumber("Please Enter Deposit Amount");

        if (clsUtil::AreYouSure("Are you Sure To Add [ " + to_string(Amount) + " ]? (Y/N)."))
        {
            Client.Deposit(Amount);
            cout << "\nThe Amount Added Successfully\n";
            cout << "\nThe Client Balance become << " << Client.AccountBallace() << " >>" << endl;
        }
        else
        {
            cout << "\nThe Operation Ignored SuccessFully\n";
        }
    }
};
