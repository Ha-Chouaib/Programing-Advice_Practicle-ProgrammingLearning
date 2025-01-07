#include <iostream>
#include<string>
#include<cctype>
using namespace std;


//Write a program to read a string then Upper Or Lower the Whole string.

string ReadTxt(string MSG)
{   
    string Txt="";
    cout<< MSG <<endl;
    getline(cin, Txt);

    return Txt;
}

string Upper_LowerString(string &Txt,bool IsLower=true)
{   
    for( int i=0;i<Txt.length(); i++)
    {   
        if(IsLower)
            Txt[i]=char(tolower(Txt[i]));
        else
            Txt[i]=char(toupper(Txt[i]));
       
    }
    return Txt;
}

int main()
{
    string Txt=ReadTxt("Enter a Txt");
    cout<<"\nBefor: " <<Txt <<endl;

    Txt=Upper_LowerString(Txt);
    cout<<"After Lowering: " <<Txt <<endl;
    Txt=Upper_LowerString(Txt,false);
    cout<<"After Uppering: " <<Txt <<endl;

    return 0;
}