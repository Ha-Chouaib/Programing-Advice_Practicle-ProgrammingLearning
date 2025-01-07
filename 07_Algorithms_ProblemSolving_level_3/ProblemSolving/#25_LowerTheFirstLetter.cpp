#include <iostream>
#include<string>
#include<cctype>
using namespace std;


//Write a program to read a string then Lower the first Letter of each Word in that string.

string ReadTxt(string MSG)
{   
    string Txt="";
    cout<< MSG <<endl;
    getline(cin, Txt);

    return Txt;
}

string Upper_LowerString(string &Txt)
{
    bool IsFirstLitter= true;
    for(int i=0;i<Txt.length(); i++)
    {
        if(Txt[i] != ' ' && IsFirstLitter)
        {
            Txt[i]=char(tolower(Txt[i]));
        }

        IsFirstLitter=(Txt[i] == ' '? true : false);
    }
    return Txt;
}

int main()
{
    string Txt=ReadTxt("Enter a Txt");
    cout<<"\nBefor: " <<Txt <<endl;
    Txt=Upper_LowerString(Txt);
    cout<<"After: " <<Txt <<endl;


    return 0;
}