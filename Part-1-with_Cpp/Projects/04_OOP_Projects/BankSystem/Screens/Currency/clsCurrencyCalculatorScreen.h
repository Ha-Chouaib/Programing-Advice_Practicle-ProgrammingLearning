#pragma once
#include<iostream>
#include"../../RootClasses/clsCurrency.h"
#include"../clsScreen.h"
#include"../../Libs/clsInputValidate.h"
#include"../../Libs/clsUtil.h"
#include<iomanip>

using namespace std;
class clsCurrencyCalculatorScreen : protected clsScreen
{
    static clsCurrency _GetCureny()
    {
        string CurrCode=clsInputValidate<string>::ReadString("Please Enter Currency Code?");
        while (!clsCurrency::IsCurrencyExist(CurrCode))
        {
            CurrCode=clsInputValidate<string>::ReadString("InValid Currency Code Please Try Again!");
        }
        return clsCurrency::FindByCode(CurrCode);
    } 

    static float _ExchangeCurrency(float Amount, clsCurrency From, clsCurrency To)
    {
        return From.ExChangeToAnotherCurrency(Amount,To);
    }

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
    static void _PrintExchangeResult(float OldAmount,clsCurrency CurrencyFrom,float NewAmount,clsCurrency CurrencyTo)
    {
        cout<<clsUtil::Tabs(2)<<"------------Exchange Result------------\n";
        cout<<clsUtil::Tabs(1)<<"From-->[ "<<OldAmount<<" ]==( "<<CurrencyFrom.CurrencyCode()<<" )"<<"|==|To-->[ "<<NewAmount<<" ]==( "<<CurrencyTo.CurrencyCode()<<" )"<<endl;
        cout<<clsUtil::Tabs(2)<<"---------------------------------------\n";
    }

public:

    static void DisplayCurencyCalculatorScreen()
    {
       do
       {
            _DrawScreenHeader("Currency Exchange","Currency Calculator");

            cout<<"\n\t.........Convert [From].........\n";
            clsCurrency FromCurrency = _GetCureny();
            _PrintCurrencyCard(FromCurrency);
            cout<<"\n\t\t....................\n";

            float Amount=0;
            do
            {
                Amount=clsInputValidate<float>::ReadPositiveNumber("Enter Amount To Exchange?");

            }while(clsUtil::AreYouSure("Do You Change This Amount? (Y/N)"));

            cout<<"\n\t.........Convert [TO].........\n";
            clsCurrency ToCurrency = _GetCureny();
            _PrintCurrencyCard(ToCurrency);


            float ExchangedAmount=_ExchangeCurrency(Amount,FromCurrency,ToCurrency);

            _PrintExchangeResult(Amount,FromCurrency,ExchangedAmount,ToCurrency);


       } while (clsUtil::AreYouSure("Do You Want Extchage Another Currency? (Y/N)"));
       

    }



};
