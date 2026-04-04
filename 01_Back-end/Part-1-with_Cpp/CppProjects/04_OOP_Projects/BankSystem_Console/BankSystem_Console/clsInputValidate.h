#pragma once
#include<iostream>
#include<limits>
#include"clsDate.h"
#include"clsPeriod.h"
using namespace std;

template <class T>
class clsInputValidate
{

public:

    static T ReadNumberInRange(T From, T To, string Message, string ErrorMSG = "InValid! The Number NOt Within the Range\n")
    {
        T Num = 0;
        do
        {
            cout << Message << endl;
            cout << ": ";
            cin >> Num;
            while (cin.fail())
            {
                cin.clear();
                cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');

                cout << "Type Error Please Enter an Integer!\n";
                cin >> Num;
            }
            if ((Num < From || Num > To))
            {
                cout << ErrorMSG << endl;
            }


        } while (Num < From || Num > To);
        return Num;
    }

    static T ReadNumber(string MSG = "", string ErorMSG = "Wrong Type Please enter a Double number!\n")
    {
        T Num = 0;

        cout << MSG << endl;
        cin >> Num;
        while (cin.fail())
        {
            cin.clear();
            cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');

            cout << ErorMSG;
            cin >> Num;
        }


        return Num;
    }

    static T ReadPositiveNumber(string MSG)
    {
        T Num = 0;
        do {
            cout << MSG << endl;
            cin >> Num;
            while (cin.fail())
            {
                cin.clear();
                cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');

                cout << "Type Error Please Enter an Integer!\n";
                cin >> Num;
            }
        } while (Num < 0);
        return Num;
    }

    static string ReadString(string MSG)
    {
        string str = "";
        cout << MSG << endl;
        getline(cin >> ws, str);
        return str;
    }

    static T IsNumberBetween(T Number, T Num1, T Num2)
    {
        return (Number >= Num1 && Number <= Num2);
    }

    static T IsDateBetween(T Date, T DateFrom, T DateTo)
    {
        return T::IsDateWithinPeriod(T(DateFrom, DateTo), Date);
    }

    static T IsValid_Date(T Date)
    {
        return T::IsValidDate(Date);
    }
};
