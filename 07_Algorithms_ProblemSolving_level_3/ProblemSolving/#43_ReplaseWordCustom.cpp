#include <iostream>
#include <string>
#include <vector>
using namespace std;

//write a program to read a string and replace a given  word by older one using Custom function not the bult in one.
//-->Do it in tow case the Case of the mach case and insesitive for the case
string ReadTxt(string MSG)
{   
    string Txt="";
    cout<< MSG <<endl;
    getline(cin, Txt);

    return Txt;
}

void MySplit(string str, vector <string>& vSplitstr, string Delimiter)
{
    string Token="";
    string Word="";
    short pos=0;
    

    while((pos= str.find(Delimiter)) != std::string::npos)
    {
        Token=str.substr(0, pos);

        if(Token != "")
        {   for(int i=0; i<Token.length();i++)
            {
                if(Token[i] != ' ')
                    Word+= Token[i];
            }

            vSplitstr.push_back(Word);
            
        }
        
        Word.clear();
        str.erase(0, pos + Delimiter.length());
    }

    if(str != "")
        vSplitstr.push_back(str);
}

string ChangStrCase(string Str, bool ToLower=true)
{  
    for(int i=0; i<Str.length(); i++)
    {
        if(ToLower)
            Str[i]=char(tolower(Str[i]));
        else
            Str[i]=char(toupper(Str[i]));
    }
    return Str;
}

string ReplaceWords(string Str,string Separator ,string OldWord, string NewWord, bool MatchCase=true)
{   vector <string> vStr;
    string NewStr="";
    MySplit(Str,vStr,Separator);

    for(string &Word : vStr)
    {   
        if(MatchCase)
        {
            if(OldWord != Word)
                NewStr+= Word + " ";
            else
                NewStr+=NewWord + " ";
        }
        else
        {
            if(ChangStrCase(OldWord) != ChangStrCase(Word))
                NewStr+= Word + " ";
            else
                NewStr+=NewWord + " ";
        }
            
    }
    
    return NewStr.substr(0,NewStr.length()-1);
    
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
    
    cout<<"Match Case: "<<ReplaceWords(Str,"/",OldWord,NewWord) <<endl;
    cout<<"Not Sesitive Case: "<<ReplaceWords(Str, "/",OldWord,NewWord,false) <<endl;

    return 0;
}