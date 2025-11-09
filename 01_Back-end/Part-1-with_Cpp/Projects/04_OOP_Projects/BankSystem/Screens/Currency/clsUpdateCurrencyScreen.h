#pragma once 
#include<iostream>
#include"../clsScreen.h"
#include"../../RootClasses/clsCurrency.h"
#include"../../Libs/clsInputValidate.h"


using namespace std;

class clsUpdateCurrencyScreen : protected clsScreen
{
    static void _PrintCurrencyCard(clsCurrency Curreency)
    {   
        
        cout<<"\n\t|==================|[ "<<Curreency.Country()<<" ]|===============|\n";
        cout<<"\n-----------------------------------------------------------------|\n";
        cout<<"| "<<"Currency Code..||"<<Curreency.CurrencyCode();
        cout<<"\n-----------------------------------------------------------------|\n";
        cout<<"| "<<"Currency Name..||"<<Curreency.CurrencyName();
        cout<<"\n-----------------------------------------------------------------|\n";
        cout<<"| "<<"Rate/(1$)......||"<<Curreency.Rate();
        cout<<"\n=================================================================|\n\n";
        
    }
    static clsCurrency _GetCureny()
    {
        string CurrCode=clsInputValidate<string>::ReadString("Please Enter Currency Code?");
        while (!clsCurrency::IsCurrencyExist(CurrCode))
        {
            CurrCode=clsInputValidate<string>::ReadString("InValid Currency Code Please Try Again!");
        }
        return clsCurrency::FindByCode(CurrCode);
    } 
public:

    static void DisplayUpdateCurrencyScreen()
    {
        _DrawScreenHeader("Currency Exchange","Update Currency");
        clsCurrency Currency =_GetCureny();
        _PrintCurrencyCard(Currency);

        float UpdatedRate=clsInputValidate<float>::ReadPositiveNumber("Enter Updated Rate");
        if(clsUtil::AreYouSure("Are You Sure To Update This Rate? (Y/N)."))
        {
            Currency.UpdateRate(UpdatedRate);
            cout<<"The Rate Updated Successfully."<<endl;
            _PrintCurrencyCard(Currency);
        }else
        {
            cout<<"\nThe Operation Ignored Successfully."<<endl;
        }
    }
};