#pragma once
#include <iostream>
#include <limits>
#include <string>
using namespace std;

namespace ReadInput
{
int ReadPositiveNumInRange(int From, int To,string Message)
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
        

    } while (Num < From || Num > To);
    return Num;
}

int ReadNumber(string MSG="")
{
    int Num=0;
    
    cout<< MSG <<endl;
    cin>> Num;
    while (cin.fail())
    {
        cin.clear();
        cin.ignore(std::numeric_limits<std::streamsize>::max(),'\n');

        cout<<"Wrong Type Please enter an Integer!\n";
        cin>>Num;
    }
    
    
    return Num;
}

float ReadPositiveNumber(string MSG)
    {
        float Num=0;
        do{
            cout<< MSG <<endl;
            cin>> Num;
        }while(Num < 0);
        return Num;
    }

string ReadString(string MSG){
        string  str="";
        cout<< MSG <<endl;
        getline(cin,str);
        return str;
    }
    
void RedaArray(int Arr[], int& ArrLength)
{
   ArrLength=ReadPositiveNumber("Enter number of element:");
   for(int i=0; i<ArrLength; i++)
   {
        cout<<"Element["<< i+1 <<"]: ";
        cin>>Arr[i];
   }
}

}