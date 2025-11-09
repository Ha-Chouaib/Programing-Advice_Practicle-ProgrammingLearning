#include <iostream>
#include<string>
#include<cctype>
using namespace std;


//Write a program to read a string then Upper the first Letter of each Word in that string.

string ReadTxt(string MSG)
{   
    string Txt="";
    cout<< MSG <<endl;
    getline(cin, Txt);

    return Txt;
}

string UpperFirstLetterOfWord(string &Txt)
{
    bool IsFirstLitter= true;
    for(int i=0;i<Txt.length(); i++)
    {
        if(Txt[i] != ' ' && IsFirstLitter)
        {
            Txt[i]=char(toupper(Txt[i]));
        }

        IsFirstLitter=(Txt[i] == ' '? true : false);
    }
    return Txt;
}

int main()
{
    string Txt=ReadTxt("Enter a Txt");
    cout<<"\nBefor: " <<Txt <<endl;
    Txt=UpperFirstLetterOfWord(Txt);
    cout<<"After: " <<Txt <<endl;


    return 0;
}