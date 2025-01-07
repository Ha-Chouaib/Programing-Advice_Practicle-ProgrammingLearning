#include<iostream>
#include<cctype>
using namespace std;

//Write a program  that Read a string and count a Given Char

string ReadTxt(string MSG)
{   
    string Txt="";
    cout<< MSG <<endl;
    getline(cin, Txt);

    return Txt;
}
char ReadChar(string MSG)
{
    char Letter;
    cout<< MSG <<endl;
    cin>> Letter;

    return Letter;
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
short CountLetters(string str, char CharToCount)
{   
    str=Upper_LowerString(str);
    short counter;
    for(int i=0; i< str.length(); i++)
    {
        if(CharToCount == str[i])
        counter++;
    }
    return counter;
}


int main()
{
    string txt=ReadTxt("Please enter a string");
    char CharToCount=ReadChar("please enter a char to count");

    cout<<"The Letter "<<CharToCount <<" is repeated [ "<<CountLetters(txt, CharToCount) <<" ] Time(s)"<<endl;    
    return 0;
}