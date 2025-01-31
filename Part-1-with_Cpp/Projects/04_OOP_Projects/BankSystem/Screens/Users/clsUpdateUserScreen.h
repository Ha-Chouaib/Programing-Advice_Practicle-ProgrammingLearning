#pragma once
#include<iostream>
#include"../clsScreen.h"
#include"../../RootClasses/clsBankUser.h"
#include"../../Libs/clsUtil.h"
#include"../../Libs/clsInputValidate.h"

using namespace std;

class clsUpdateUserScreen : protected clsScreen
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

    static clsBankUser::enUpdateOptions _ReadUpdateOption()
    {
        return (clsBankUser::enUpdateOptions) clsInputValidate<short>::ReadNumberInRange(0,2,"Get Your Option: ");
    }

    static void _ReadCustomInf(clsBankUser& User)
    {
        cout<<"\n(First Name)--> [ "<<User.FirstName() <<" ]"<<endl;   
        if(clsUtil::AreYouSure("Update ? (Y/N)."))
        {
            User.SetFirstName(clsInputValidate<string>::ReadString("First Name: "));
        }
        
        cout<<"\n(Last Name)--> [ "<<User.LastName() <<" ]"<<endl;
        if(clsUtil::AreYouSure("Update ? (Y/N)."))
        {
            User.SetLastName(clsInputValidate<string>::ReadString("Last Name: "));
        }

        cout<<"\n(Email)--> [ "<<User.Email() <<" ]"<<endl;
        if(clsUtil::AreYouSure("Update ? (Y/N)."))
        {
            User.SetEmail(clsInputValidate<string>::ReadString("Email: "));
        }

        cout<<"\n(Phone number)--> [ "<<User.Phone() <<" ]"<<endl;
        if(clsUtil::AreYouSure("Update ? (Y/N)."))
        {
            User.SetPhone(clsInputValidate<string>::ReadString("Phone: "));
        }

        cout<<"\n(PassWord)--> [ "<<User.Password() <<" ]"<<endl;
        if(clsUtil::AreYouSure("Update ? (Y/N)."))
        {
            User.SetPassWord(clsInputValidate<string>::ReadString("PassWord: "));
        }

        cout<<"\n(Permissions)--> [ "<<User.Permissions() <<" ]"<<endl;
        if(clsUtil::AreYouSure("Update ? (Y/N)."))
        {
            User.SetPermissions(_ReadPermissions());
        }
        
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
            if(clsUtil::AreYouSure("Display Login History (y/n)? "))
            {
                Permissions+=clsBankUser::enPermissions::pLogingHistory;
            }
    
        }else
        {
            return Permissions=-1;
        }
        return Permissions;
    }


    static void _UpdatedObject(clsBankUser& User,clsBankUser::enUpdateOptions Option)
    {

        switch (Option)
        {
        case clsBankUser::enUpdateOptions::eIgnore :

            User.SetIsIgnored(true);
            break;

        case clsBankUser::enUpdateOptions::eAll :

            _ReadUserInfo(User) ;
            break;

        case clsBankUser::enUpdateOptions::eCustom :

            _ReadCustomInf(User);
            break;

        default:

            User.SetIsIgnored(true);
            break;
        }
    }

    static void _ShowUpdateOptionsMenu(clsBankUser& User)
    {   
        cout<<"\n- - - - - - - - - - - - - - - -\n";
        cout<<clsUtil::Tabs(3) <<"\nUpdate Options:"<<endl;
        cout<<"\n- - - - - - - - - - - - - - - -\n\n";

        cout<<"[0]-->(Ignore Operation) // [1]-->(Update All) // [2]-->(Update Custom Inf)"<<endl;

        _UpdatedObject(User, _ReadUpdateOption());
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

public:

    static void UpdateUserScreen()
    {

        _DrawScreenHeader("Manage Users",".Update User Field.");

        string UserName=clsInputValidate<string>::ReadString("Enter User Name");

        while(!clsBankUser::IsUserExist(UserName))
        {
            cout<<"The User Name [ "<< UserName <<" ] Not Exist, Please Enter a Valid User Name."<<endl;
            UserName=clsInputValidate<string>::ReadString(": ");
        }

        clsBankUser User= clsBankUser::Find(UserName);
        _printUserCard(User);

        _ShowUpdateOptionsMenu(User);

        if(!User.IsIgnored())
        {
            clsBankUser::enSaveResult SaveResult;
            SaveResult=User.Save();
            
            switch (SaveResult)
            {
            case clsBankUser::enSaveResult::svFaildEmptyObject :
                cout<<"\nError Empty Object the Update Operation Faild \n";
                break;
            case clsBankUser::enSaveResult::svSucceeded :
                cout<<"\nAccount Updated Successfully \n";
                _printUserCard(User);
                break;

            default:
                cout<<"\nUnexpected Error!"<<endl;
                break;
            }
        }else
        {
            cout<<"\nThe Operation Has Been Ignored Successfully."<<endl;
            User.SetIsIgnored(false);
        }
    }
};