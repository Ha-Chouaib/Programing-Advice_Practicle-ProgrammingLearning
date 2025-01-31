#pragma once
#include<iostream>
#include"../clsScreen.h"
#include"../../RootClasses/clsBankUser.h"
#include"../../Libs/clsInputValidate.h"
#include"../../Libs/clsUtil.h"

using namespace std;

class clsDeleteUserScreen : protected clsScreen
{
    static void _printUserCard(clsBankUser User)
    {
        
        cout<<endl<<clsUtil::Tabs(2)<<"  << User Card >>" <<endl;
        cout<<clsUtil::Tabs(2)<<"<< User Name [ " <<User.UserName() <<" ] >>" <<endl;
        cout<<clsUtil::Tabs(1)<<"==============================\n";
        cout<<clsUtil::Tabs(1)<<"FullName         : "<<User. FullName()    <<endl;
        cout<<clsUtil::Tabs(1)<<"Email            : "<<User. Email()       <<endl;
        cout<<clsUtil::Tabs(1)<<"Phone            : "<<User. Phone()       <<endl;
        cout<<clsUtil::Tabs(1)<<"PassWord         : "<<User.Password()       <<endl;
        cout<<clsUtil::Tabs(1)<<"Permissions      : "<<User.Permissions() <<endl;
        cout<<clsUtil::Tabs(1)<<"==============================\n";
    }
public:
    static void DeleteUserScreen()
    {
        _DrawScreenHeader("Manage Users","- Delete User Screen -");
        string UserName;
        UserName=clsInputValidate<string>::ReadString("Enter User Name?");
        while(!clsBankUser::IsUserExist(UserName))
        {
            UserName=clsInputValidate<string>::ReadString("User Name Not Exist Please Enter a Valid One!");
        }

        clsBankUser User= clsBankUser::Find(UserName);
        _printUserCard(User);

        if(clsUtil::AreYouSure("Are you Sure to Delete this Account? (Y/N)"))
        {
            if(User.Delete())
            {
                cout<<"\nThe Account Deleted Successfully.\n";
            }
            else
            {
                cout<<"\nUnexpected Error The Account Not Deleted!\n";
            }

        }else
        {
            cout<<"\nThe operation Has been Ignored Successfully.\n";
        }
    }

};
