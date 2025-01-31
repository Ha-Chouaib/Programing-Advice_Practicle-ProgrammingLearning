#pragma once
#include<iostream>
#include"../clsScreen.h"
#include"../../RootClasses/clsBankUser.h"
#include"../../Libs/clsInputValidate.h"
#include"../../Libs/clsUtil.h"

using namespace std;

class clsAddNewUserScreen :protected clsScreen
{

    static void _ReadUserInfo(clsBankUser& User)
    {
        User.SetFirstName(clsInputValidate<string>::ReadString("Enter First Name: "));
        User.SetLastName(clsInputValidate<string>::ReadString("Enter Last Name: "));
        User.SetEmail(clsInputValidate<string>::ReadString("Enter Email: "));
        User.SetPhone(clsInputValidate<string>::ReadString("Enter Phone: "));
        User.SetPassWord(clsInputValidate<string>::ReadString("Password: "));
        User.SetPermissions(_ReadPermissions());
    }

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

   static int _ReadPermissions()
    {
        int Permissions=0;
        
        if(!clsUtil::AreYouSure("Do you Want Give The User Full access? (y/n)"))
        {
            cout<<"\n-----------[Permissions]-----------\n";
            
            if(clsUtil::AreYouSure("Show Clients List (y/n)? "))
            {
                Permissions+=clsBankUser::enPermissions::pListClients;
            }
    
            if(clsUtil::AreYouSure("Add New Clients (y/n)? "))
            {
                Permissions+=clsBankUser::enPermissions::pAddNewClient;            
            }
    
            if(clsUtil::AreYouSure("Delete Clients (y/n)? "))
            {
                Permissions+=clsBankUser::enPermissions::pDeleteClient;            
            }
    
            
            if(clsUtil::AreYouSure("Update Clients (y/n)? "))
            {
                Permissions+=clsBankUser::enPermissions::pUpdateClient;
            }
    
            if(clsUtil::AreYouSure("Find Clients (y/n)? "))
            {
                Permissions+=clsBankUser::enPermissions::pFindClient;          
            }
    
            if(clsUtil::AreYouSure("Transaction (y/n)? "))
            {
                Permissions+=clsBankUser::enPermissions::pTransactions;
            }
    
            if(clsUtil::AreYouSure("Manage Users (y/n)? "))
            {
                Permissions+=clsBankUser::enPermissions::pManageUsers;
            }
            if(clsUtil::AreYouSure("Display LoginHistory (y/n)? "))
            {
                Permissions+=clsBankUser::enPermissions::pLogingHistory;
            }
    
        }else
        {
            return Permissions=-1;
        }
        return Permissions;
    }


public:
    static void DisplayAddNewUserScreen()
    {
        _DrawScreenHeader("Manage Users","Add New User");
        string UserName=clsInputValidate<string>::ReadString("Enter User Name?");

        while(clsBankUser::IsUserExist(UserName))
        {
            UserName=clsInputValidate<string>::ReadString("This User Name is Already Exist Please Enter Another One!");
        }

        clsBankUser User= clsBankUser::GetAddNewClientObject(UserName);
        _ReadUserInfo(User);

        if(clsUtil::AreYouSure())
        {
            clsBankUser::enSaveResult SaveResult= User.Save();

            switch (SaveResult)
            {
            case clsBankUser::enSaveResult::svSucceeded :
                cout<<"\nThe User Acount Added Successfully."<<endl;
                _printUserCard(User);
                break;
            case clsBankUser::enSaveResult::svFaildAccountReserved :
                cout<<"\nThis Acount is Already Exist!"<<endl;
                break;

            default:
                cout<<"\nUnexpected Error!!"<<endl;
                break;
            }
        }else
        {
            cout<<"\nThe Operation Has Been Done Seccussfully. \n";
        }

        

    }
};