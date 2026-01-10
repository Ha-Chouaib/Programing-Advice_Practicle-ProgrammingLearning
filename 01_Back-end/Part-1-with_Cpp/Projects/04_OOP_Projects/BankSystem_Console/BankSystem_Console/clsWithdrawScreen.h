#pragma once
#include<iostream>
#include"clsScreen.h"
#include"clsBankClient.h"
#include"clsInputValidate.h"
#include"clsUtil.h"

using namespace std;


class clsWithdrawScreen : protected clsScreen
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
            AccountNumber = clsInputValidate<string>::ReadString("InValid Account Number Please Try again!");
        }
        return AccountNumber;
    }

public:

    static void DepositScreen()
    {
        _DrawScreenHeader("Transactions", "- Withdraw Screen -");
        string AccountNumber = _ReadAccountNumber();

        clsBankClient Client = clsBankClient::Find(AccountNumber);
        _printClientCard(Client);

        double Amount = 0;
        Amount = clsInputValidate<double>::ReadNumber("Please Enter Withdraw Amount");

        if (clsUtil::AreYouSure("Are you Sure To Withdraw [ " + to_string(Amount) + " ]? (Y/N)."))
        {

            if (Amount > Client.AccountBallace())
            {
                cout << "The Entered Amount is Exceeds the Balance[ " << Client.AccountBallace() << " ]\n";
                if (clsUtil::AreYouSure("Do You Still Want Complete this Operation? (Y/N)"))
                {
                    Amount = clsInputValidate<double>::ReadNumber("Please Enter an Other Valid Amount?");
                }
                else
                {
                    cout << "\nThe Operation Has Been Ignored.\n";
                }

            }


            if (Client.Withdraw(Amount))
            {
                cout << "\nThe Operation Done Successfully\n";
                cout << "\nThe Client Balance become << " << Client.AccountBallace() << " >>" << endl;
            }

        }
        else
        {
            cout << "\nThe Operation Ignored SuccessFully\n";
        }
    }
};
