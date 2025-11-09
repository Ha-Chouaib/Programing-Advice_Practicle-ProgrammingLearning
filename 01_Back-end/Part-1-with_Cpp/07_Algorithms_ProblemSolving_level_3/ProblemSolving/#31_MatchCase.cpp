#include<iostream>
#include<cctype>
using namespace std;

//Write a program  that Read a string and count a Given Char (Match case or not)

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
char InverCharCase(char Char)
{
    return (islower(Char)) ? char(toupper(Char)):char(tolower(Char));
}

short CountLetters(string str, char CharToCount,bool MatchCase=true)
{   
    
    short counter;
    for(int i=0; i< str.length(); i++)
    {   
        if(MatchCase)
        { 
            if(CharToCount == str[i])
            counter++;
        }
        else
        {
            if(tolower(CharToCount) == tolower(str[i]))
                counter++;
        }
    }
    return counter;
}


int main()
{
    string txt=ReadTxt("Please enter a string");
    char CharToCount=ReadChar("please enter a char to count");

    cout<<"The Letter "<<CharToCount <<" is repeated [ "<<CountLetters(txt, CharToCount) <<" ] Time(s)"<<endl;
        
    cout<<"The Letter \""<<CharToCount <<"\" Or \""<<InverCharCase(CharToCount) <<"\" is repeated [ "<<CountLetters(txt, CharToCount,false) <<" ] Time(s)"<<endl;    
    return 0;
}