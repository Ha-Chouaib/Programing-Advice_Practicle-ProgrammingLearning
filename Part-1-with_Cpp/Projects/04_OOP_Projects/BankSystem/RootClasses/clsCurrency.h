#pragma once
#include<iostream>
#include<vector>
#include<string>
#include<fstream>
#include"../Libs/clsString.h"

using namespace std;

class clsCurrency
{
    enum enMode{eEmptyMode,eUpdateMode=1};
    enMode _Mode;

    string _Country="";
    string _CurrencyCode="";
    string _CurrencyName="";
    float _Rate=0;

    static clsCurrency _ConvertDataLineToCurrencyObject(string Data,string Separator="#//#")
    {
        vector<string>vCurr=Str::clsString::Split(Data,Separator);
        return clsCurrency(enMode::eUpdateMode,vCurr[0],vCurr[1],vCurr[2],stof(vCurr[3]));
    }
    string _ConvertCurrencyObjectToLine(clsCurrency Currency,string Separator="#//#")
    {
        string L="";
        L=Currency.Country() +Separator;
        L+=Currency.CurrencyCode() +Separator;
        L+=Currency.CurrencyName() +Separator;
        L+=to_string(Currency.Rate());
        return L;
    }
   
    static vector<clsCurrency> _LoadCurrenciesDataFromFile()
    {
        vector<clsCurrency> _vCurr;
        fstream F;
        F.open("TxtFiles/Currencies.txt", ios::in);
        if(F.is_open())
        {   
            string L;
            while(getline(F,L))
            {
                _vCurr.push_back(_ConvertDataLineToCurrencyObject(L));
            }
        }
        F.close();
        return _vCurr;
    }
    void _UpdateCurrencysDataFile(vector<clsCurrency> &vCurrency)
    {
        fstream F;
        F.open("TxtFiles/Currencies.txt",ios::out);
        if(F.is_open())
        {
            for(clsCurrency &C : vCurrency)
            {
                F<<_ConvertCurrencyObjectToLine(C)<<endl;
            }
        }
        F.close();
    }
    
    void _Update()
    {
        vector<clsCurrency> _vCurr;
        _vCurr=_LoadCurrenciesDataFromFile();

        for(clsCurrency &C : _vCurr)
        {
            if(C.CurrencyCode() == CurrencyCode())
            {
                C=*this;
                break;
            }
        }

        _UpdateCurrencysDataFile(_vCurr);
    }
    public:
    clsCurrency(enMode Mode,string Country,string CurrencyCode,string CurrencyName,float Rate)
    {
        _Mode= Mode;
        _Country=Country;
        _CurrencyCode=CurrencyCode;
        _CurrencyName=CurrencyName;
        _Rate=Rate;
    }

    bool IsEmpty()
    {
        return _Mode == enMode::eEmptyMode;
    }
    string Country()
    {
        return _Country;
    }
    string CurrencyCode()
    {
        return _CurrencyCode;
    }
    string CurrencyName()
    {
        return _CurrencyName;
    }
    
    void UpdateRate(float UpdatedRate)
    {
        _Rate=UpdatedRate;
        _Update();

    }

    float ExchangeToUSD(float Amount)
    {
        return (float) (Amount / _Rate);
    }
    float ExChangeToAnotherCurrency(float Amount ,clsCurrency ToCurrency)
    {      
        float AmountInUSD= ExchangeToUSD(Amount);
        
        if(ToCurrency.CurrencyCode()== "USD")
        {
            return AmountInUSD;
        }
        return (float) (AmountInUSD * ToCurrency.Rate());
    }
    float Rate()
    {
        return _Rate;
    }
    static clsCurrency GetEmptyCurrencyObjcet()
    {
        return clsCurrency(enMode::eEmptyMode,"","","",0); 
    }

    static clsCurrency FindByCode(string CurrencyCode)
    {
        CurrencyCode=Str::clsString::Upper_LowerString(CurrencyCode,false);

        fstream F;
        F.open("TxtFiles/Currencies.txt", ios::in);
        if(F.is_open())
        {
            string Line="";
            while(getline(F,Line))
            {
                clsCurrency C=_ConvertDataLineToCurrencyObject(Line);
                if(C.CurrencyCode() == CurrencyCode)
                {
                    F.close();
                    return C;
                }
            }
        }
        F.close();
        return  GetEmptyCurrencyObjcet();
    }
    static clsCurrency FindByName(string currencyName)
    {
        currencyName=Str::clsString::Upper_LowerString(currencyName,false);

        fstream F;
        F.open("TxtFiles/Currencies.txt", ios::in);
        if(F.is_open())
        {
            string Line="";
            while(getline(F,Line))
            {
                clsCurrency Curr=_ConvertDataLineToCurrencyObject(Line);
                string Curr_Name=Curr.CurrencyName();

                if(Str::clsString::Upper_LowerString(Curr_Name, false) == currencyName)
                {
                    F.close();
                    return Curr;
                }
            }
        }
        F.close();
        return GetEmptyCurrencyObjcet();
    }

    static bool IsCurrencyExist(string CurrencyCode)
    {
        clsCurrency C =FindByCode(CurrencyCode);
        return (!C.IsEmpty());
    }

    static vector<clsCurrency>GetCurrenciesData()
    {
        return _LoadCurrenciesDataFromFile();
    }


};