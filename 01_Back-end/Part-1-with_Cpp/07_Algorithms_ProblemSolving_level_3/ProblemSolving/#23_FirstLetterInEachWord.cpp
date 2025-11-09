#include <iostream>
#include <string>
using namespace std;

//Write a program to read a string then print the first Letter of each Word in that string.

string ReadTxt(string MSG)
{   
    string Txt="";
    cout<< MSG <<endl;
    getline(cin, Txt);

    return Txt;
}
void GetFirstLetterInWord(string Text)
{   
    bool IsFirstLetter=true;
    for(int i=0; i<Text.length(); i++)
    {
        if(Text[i] != ' ' &&  IsFirstLetter)
        {
            cout<< Text[i] <<endl;
        }
        IsFirstLetter= (Text[i] == ' '? true : false);
    }
}


int main()
{
    string Getstring=ReadTxt("Enter a Text:");

    GetFirstLetterInWord(Getstring);

    return 0;
}