#pragma once
#include<iostream>
#include<iomanip>
#include"clsScreen.h"
#include"clsBankClient.h"
#include"clsUtil.h"

using namespace std;

class clsClientListScreen :protected clsScreen
{

    static void _ListClientInfo(clsBankClient Client)
    {

        cout << "| " << left << setw(15) << Client.AccountNumber()
            << "| " << left << setw(20) << Client.FullName()
            << "| " << left << setw(12) << Client.Phone()
            << "| " << left << setw(40) << Client.Email()
            << "| " << left << setw(10) << Client.PinCode()
            << "| " << left << setw(12) << Client.AccountBallace() << endl;
    }


public:


    static void ShowClientList()
    {
        if (!CheckAccessPermissionRights(clsBankUser::enPermissions::pListClients))
        {
            return;
        }
        vector<clsBankClient>vClients = clsBankClient::GetClientsData();
        string Title = "[ Clients List ]";
        string SubTitle = "<< " + to_string(vClients.size()) + " >>" + " Client(s)";

        _DrawScreenHeader(Title, SubTitle);

        cout << "------------------------------------------------------------------------------------------------------------------------\n";

        cout << "| " << left << setw(15) << "Account Number"
            << "| " << left << setw(20) << "Client Name"
            << "| " << left << setw(12) << "Phone"
            << "| " << left << setw(40) << "Email"
            << "| " << left << setw(10) << "Pin_Code"
            << "| " << left << setw(12) << "Balance" << endl;
        cout << "------------------------------------------------------------------------------------------------------------------------\n";
        cout << "| " << left << setw(15) << "" << "| " << left << setw(20) << "" << "| " << left << setw(12) << ""
            << "| " << left << setw(40) << "" << "| " << left << setw(10) << "" << "| " << left << setw(12) << "" << endl;
        if (vClients.size() == 0)
        {
            cout << endl << clsUtil::Tabs(3) << "<< Empty ! >>" << endl;
        }
        else
        {
            for (clsBankClient& C : vClients)
            {
                _ListClientInfo(C);
            }
        }

        cout << "------------------------------------------------------------------------------------------------------------------------\n";
    }


};
