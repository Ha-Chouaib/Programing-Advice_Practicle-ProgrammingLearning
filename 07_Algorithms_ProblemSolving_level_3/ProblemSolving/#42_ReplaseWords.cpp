#include <iostream>
#include <string>
#include <vector>
using namespace std;

//write a program to read a string and replace a given  word by older one using built in function.

string ReadTxt(string MSG)
{   
    string Txt="";
    cout<< MSG <<endl;
    getline(cin, Txt);

    return Txt;
}

string ReplaceWordsUsingBuitInFunction(string Str,string WordToReplace,string NweWord)
{
    short pos=Str.find(WordToReplace);
    while(pos != std::string::npos)
    {
        Str.replace(pos, WordToReplace.length(),NweWord);
        pos=Str.find(WordToReplace);
    }

    return Str;
}

int main()
{
    string Str= ReadTxt("Enter a string: ");
    string OldWord= ReadTxt("Enter the old Word: ");
    string NewWord= ReadTxt("Enter the new word: ");

    cout<<"\nThe Original String:"<<endl;
    cout<< Str <<endl;
    cout<<endl;
    cout<<"The string After Replacing:[ "<<OldWord <<" ] By [ "<<NewWord <<" ]."<<endl;
    
    cout<<ReplaceWordsUsingBuitInFunction(Str, OldWord,NewWord) <<endl;

    return 0;
}