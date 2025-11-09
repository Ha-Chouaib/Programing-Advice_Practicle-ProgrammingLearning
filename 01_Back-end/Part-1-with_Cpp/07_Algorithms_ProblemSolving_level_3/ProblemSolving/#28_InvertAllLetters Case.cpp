#include<iostream>
#include<cctype>
using namespace std;

//Write a program  that Read a string then invert all its case. and print it

string ReadTxt(string MSG)
{   
    string Txt="";
    cout<< MSG <<endl;
    getline(cin, Txt);

    return Txt;
}

char InverCharCase(char Char)
{
    return (islower(Char)) ? char(toupper(Char)):char(tolower(Char));
}

string InvertAllstringChars( string str)
{
    for(int i=0; i<str.length(); i++)
    {
        str[i]=InverCharCase(str[i]);
    }
    return str;
}
int main()
{
    string txt=ReadTxt("Please enter a string");

    txt=InvertAllstringChars(txt);
    cout<< txt <<endl;

    return 0;
}