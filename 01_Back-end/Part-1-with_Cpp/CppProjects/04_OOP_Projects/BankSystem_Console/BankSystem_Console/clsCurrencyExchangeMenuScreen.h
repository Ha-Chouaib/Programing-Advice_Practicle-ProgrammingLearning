
#pragma once
#include<iostream>
#include"clsScreen.h"
#include"clsInputValidate.h"
#include"clsUtil.h"
#include"clsListCurrenciesScreen.h"
#include"clsFindCurrencyScreen.h"
#include"clsUpdateCurrencyScreen.h"
#include"clsCurrencyCalculatorScreen.h"

using namespace std;

class clsCurrencyMenuScreen :protected clsScreen
{
    enum enCurrencyMenuOption { eListCurrencies = 1, eFindCurrency = 2, eUpdateRate = 3, eCurrencyCalculator = 4, eMainMenu };

    static short _ReadCurrencyMenuOption()
    {
        return clsInputValidate<short>::ReadNumberInRange(1, 5, "Please Get Your Option From (1) To (5).");
    }
    static void _GoBackToCurrencyMenu()
    {
        cout << "\nPress [Enter] Key To Go Back To Currency Menu..." << endl;
        cin.ignore();
        cin.get();
        DisplayCurrencyMenuScreen();
    }

    static void _ListCurrenciesScreen()
    {
        clsListCurenciesScreen::DisplayCurrenciesList();
    }
    static void _FindCurrenciesScreen()
    {
        clsFindCurrencyScreen::DisplayFindCurrencyScreen();
    }
    static void _UpdateRateScreen()
    {
        clsUpdateCurrencyScreen::DisplayUpdateCurrencyScreen();
    }
    static void _CurrencyCalculatorScreen()
    {
        clsCurrencyCalculatorScreen::DisplayCurencyCalculatorScreen();
    }
    static void _BackToMainMenu()
    {

    }

    static void _CurrencyMenuBrain(enCurrencyMenuOption Option)
    {
        switch (Option)
        {
        case enCurrencyMenuOption::eListCurrencies:
            system("cls");
            _ListCurrenciesScreen();
            _GoBackToCurrencyMenu();
            break;
        case enCurrencyMenuOption::eFindCurrency:
            system("cls");
            _FindCurrenciesScreen();
            _GoBackToCurrencyMenu();
            break;
        case enCurrencyMenuOption::eUpdateRate:
            system("cls");
            _UpdateRateScreen();
            _GoBackToCurrencyMenu();
            break;
        case enCurrencyMenuOption::eCurrencyCalculator:
            system("cls");
            _CurrencyCalculatorScreen();
            _GoBackToCurrencyMenu();
            break;
        case enCurrencyMenuOption::eMainMenu:
            system("cls");
            _BackToMainMenu();
            break;
        default:
            system("cls");
            _GoBackToCurrencyMenu();
            break;
        }
    }

public:

    static void DisplayCurrencyMenuScreen()
    {
        _DrawScreenHeader("Currency Exchange Screen", "Currency Main Menu");

        cout << endl << clsUtil::Tabs(5) << "========================================\n\n";
        cout << clsUtil::Tabs(6) << "[1]-->(Show Currencies List---)\n";
        cout << clsUtil::Tabs(6) << "[2]-->(Find Currency----------)\n";
        cout << clsUtil::Tabs(6) << "[3]-->(Update Rate------------)\n";
        cout << clsUtil::Tabs(6) << "[4]-->(Currency Calculator----)\n";
        cout << clsUtil::Tabs(6) << "[5]-->(Back To Main Menu------)\n";
        cout << endl << clsUtil::Tabs(5) << "========================================\n\n";

        _CurrencyMenuBrain((enCurrencyMenuOption)_ReadCurrencyMenuOption());
    }


};