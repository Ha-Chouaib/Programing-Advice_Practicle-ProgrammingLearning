#pragma once
#include<iostream>
#include<iomanip>
#include"../clsScreen.h"
#include"../../RootClasses/clsCurrency.h"
#include"../../Libs/clsInputValidate.h"

using namespace std;

class clsFindCurrencyScreen :protected clsScreen
{
    enum enFindCurrency{eByCode=1,eByName=2};
    static short _ReadCurrencyOption()
    {
        return clsInputValidate<short>::ReadNumberInRange(1,2,"Search By Currency: [1]-->(Code) // [2]-->(Name)");
    }
    static string _ReadCurrencyName_Code(string MSG)
    {
        return clsInputValidate<string>::ReadString(MSG);
    }
    
    static void _PrintCurrencyCard(clsCurrency Curreency)
    {
        cout<<"\n=================================================================|\n";
        cout<<"| "<<"Country........||"<<Curreency.Country();
        cout<<"\n-----------------------------------------------------------------|\n";
        cout<<"| "<<"Currency Code..||"<<Curreency.CurrencyCode();
        cout<<"\n-----------------------------------------------------------------|\n";
        cout<<"| "<<"Currency Name..||"<<Curreency.CurrencyName();
        cout<<"\n-----------------------------------------------------------------|\n";
        cout<<"| "<<"Rate/(1$)......||"<<Curreency.Rate();
        cout<<"\n=================================================================|\n\n";
        
    }
    
    static clsCurrency _FindByCode()
    {   
        string CurrencyCode=_ReadCurrencyName_Code("Enter Currency Code?");
        while(!clsCurrency::IsCurrencyExist(CurrencyCode))
        {
            CurrencyCode=_ReadCurrencyName_Code("InValid Currency Code Please Try Again!");
        }
        return clsCurrency::FindByCode(CurrencyCode);
        
    }
    
    static clsCurrency _FindByName()
    {   
        string CurrencyName= _ReadCurrencyName_Code("Enter Currency Name?");
        clsCurrency Curr= clsCurrency::FindByName(CurrencyName);
        
        while(Curr.IsEmpty())
        {
            CurrencyName= _ReadCurrencyName_Code("InValid Name Please Try Again!");
            Curr= clsCurrency::FindByName(CurrencyName);
        } 
        return Curr;
    }
    
    static clsCurrency _FindBrain(enFindCurrency Opt)
    {
        switch (Opt)
        {
        case enFindCurrency::eByCode :
            return _FindByCode();

        case enFindCurrency::eByName :
            return _FindByName();

        default:
            return clsCurrency::GetEmptyCurrencyObjcet();
        }
    }
public:

    static void DisplayFindCurrencyScreen()
    {   
        _DrawScreenHeader("Currency Exchange","Find Currency");
        _PrintCurrencyCard(_FindBrain((enFindCurrency)_ReadCurrencyOption()));

    }

};