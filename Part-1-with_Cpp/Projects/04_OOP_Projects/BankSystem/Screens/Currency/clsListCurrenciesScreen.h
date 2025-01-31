#pragma once
#include<iostream>
#include<iomanip>
#include"../clsScreen.h"
#include"../../RootClasses/clsCurrency.h"
#include"../../Libs/clsUtil.h"

using namespace std;

class clsListCurenciesScreen : protected clsScreen
{
    static void _ListCurrency(clsCurrency Currency)
    {
        cout<<"| "<<left<<setw(30)<<Currency.Country()
            <<"| "<<left<<setw(15)<<Currency.CurrencyCode()
            <<"| "<<left<<setw(40)<<Currency.CurrencyName()
            <<"| "<<left<<setw(10)<<Currency.Rate()<<" |"<<endl;
    }

public:
    static void DisplayCurrenciesList()
    {
        vector<clsCurrency>vCurrencies=clsCurrency::GetCurrenciesData();
        string Title="Currencies List";
        string SubTitle="[ "+to_string(vCurrencies.size())+" ] Records";
        _DrawScreenHeader(Title,SubTitle);

        cout<<"=========================================================================================================\n";
        cout<<"| "<<left<<setw(30)<<"Country"
            <<"| "<<left<<setw(15)<<"Currency Code"
            <<"| "<<left<<setw(40)<<"Currency Name"
            <<"| "<<left<<setw(10)<<"Rate/(1$)"<<" |"<<endl;
        cout<<"=========================================================================================================\n";
        cout<<"| "<<left<<setw(30)<<""<<"| "<<left<<setw(15)<<""<<"| "<<left<<setw(40)<<""
            <<"| "<<left<<setw(10)<<""<<" |"<<endl;
        if(vCurrencies.size()==0)
        {
            cout<<endl<<clsUtil::Tabs(3) <<"<< Empty ! >>"<<endl;
        }else
        {
            for(clsCurrency &C : vCurrencies)
            {
                _ListCurrency(C);
                cout<<"---------------------------------------------------------------------------------------------------------\n";
            }
        }


    }
};


