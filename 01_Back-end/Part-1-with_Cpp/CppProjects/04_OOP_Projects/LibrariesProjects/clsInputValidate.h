#pragma once
#include<iostream>
#include<limits>
#include"clsDate.h"
#include"clsPeriod.h"
using namespace std;

class clsInputValidate
{
    
public:    
    static int ReadNumberInRange(int From, int To,string Message,string ErrorMSG="InValid! The Number NOt Within the Range\n")
    {   int Num=0;
        do
        {
            cout<< Message <<endl;
            cin>> Num;
            while (cin.fail())
            {
                cin.clear();
                cin.ignore(std::numeric_limits<std::streamsize>::max(),'\n');

                cout<<"Type Error Please Enter an Integer!\n";
                cin>>Num;
            }
            if((Num < From || Num > To))
            {
                cout<< ErrorMSG <<endl;
            }


        } while (Num < From || Num > To);
        return Num;
    }

    static int ReadNumber(string MSG="",string ErrorMSG="Wrong Type Please enter an Integer!\n")
    {
        int Num=0;

        cout<< MSG <<endl;
        cin>> Num;
        while (cin.fail())
        {
            cin.clear();
            cin.ignore(std::numeric_limits<std::streamsize>::max(),'\n');

            cout<<ErrorMSG;
            cin>>Num;
        }


        return Num;
    }

    static double ReadNumber(string MSG="",string ErorMSG="Wrong Type Please enter a Double number!\n")
    {
        double Num=0;

        cout<< MSG <<endl;
        cin>> Num;
        while (cin.fail())
        {
            cin.clear();
            cin.ignore(std::numeric_limits<std::streamsize>::max(),'\n');

            cout<<ErorMSG;
            cin>>Num;
        }


        return Num;
    }

    static float ReadPositiveNumber(string MSG)
        {
            float Num=0;
            do{
                cout<< MSG <<endl;
                cin>> Num;
                while (cin.fail())
                {
                    cin.clear();
                    cin.ignore(std::numeric_limits<std::streamsize>::max(),'\n');

                    cout<<"Type Error Please Enter an Integer!\n";
                    cin>>Num;
                }
            }while(Num < 0);
            return Num;
        }

    static float ReadNumber(string MSG)
    {
        float Num=0;
        cout<< MSG <<endl;
        cin>>Num;
        return Num;
    }

    static string ReadString(string MSG){
            string  str="";
            cout<< MSG <<endl;
            getline(cin,str);
            return str;
        }

    static bool IsNumberBetween(int Number, int Num1,int Num2)
    {
        return (Number >= Num1 && Number<= Num2) ;
    }

    static bool IsNumberBetween(double Number, double Num1, double Num2)
    {
        return (Number >= Num1 && Number<=Num2);
    }
    
    static bool IsDateBetween(clsDate Date, clsDate DateFrom, clsDate DateTo)
    {
        return clsPeriod::IsDateWithinPeriod(clsPeriod(DateFrom,DateTo),Date);
    }

    static bool IsValid_Date(clsDate Date)
    { 
        return clsDate::IsValidDate( Date);
    }
};