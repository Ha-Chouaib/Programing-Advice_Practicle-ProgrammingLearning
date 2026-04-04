#pragma once
#include<iostream>
#include"clsScreen.h"
#include"clsBankUser.h"
#include"clsMainMenuScreen.h"
#include"clsInputValidate.h"
#include"Global.h"

using namespace std;

class clsLoginScreen : protected clsScreen
{

    static bool _Login()
    {
        bool LoginFaild = false;
        string _UserName = "";
        string _Password = "";
        short _Faildcounter = 3;

        do
        {
            if (LoginFaild)
            {
                _Faildcounter--;
                if (_Faildcounter == 0)
                {
                    cout << "\n[Locked] You reached 3 Faild Trails\n";
                    return false;
                }
                system("cls");
                cout << "\nInvalid UserName/Password !" << endl;
                cout << "Please Try Again.[You still Have (" << _Faildcounter << ") Trail(s)]" << endl<<endl;
            }
         
            _UserName = clsInputValidate<string>::ReadString("UserName:");
            _Password = clsInputValidate<string>::ReadString("Password:");

            CurrentUser = clsBankUser::Find(_UserName, _Password);
            LoginFaild = CurrentUser.IsEmpty();

        } while (LoginFaild);
        CurrentUser.RegisterLogin();
        clsMainMenuScreen::DisplayMainMenuScreen();
        return true;
    }
public:

    static bool DisplayLoginScreen()
    {
        system("cls");
        _DrawScreenHeader("Login Screen");
        return _Login();
    }

};
