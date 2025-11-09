#pragma once
#include<iostream>
#include<vector>
#include<string>
#include<cctype>
using namespace std;

namespace Str
{
class clsString
{
    string _strValue;
    
public:

    clsString()
    {
        _strValue="";
    }
    clsString(string StringValue)
    {
        _strValue=StringValue;
    }

    void SetString(string Str)
    {
        _strValue=Str;
    }
    string GetString()
    {
        return _strValue;
    }

    void ReadStringFromUser(string MSG)
    {
        cout<< MSG <<endl;
        getline(cin >> ws, _strValue);
    }

    static unsigned short Length(string Str)
    {
        return Str.length();
    }
    unsigned short Length()
    {
        return Length(_strValue);
    }


    static char _InverceCharCase(char Char)
    {
        return (islower(Char)) ? char(toupper(Char)):char(tolower(Char));
    }

    static string Encryption(string Txt, short EncryptionKey=5)
    {
        for(int i=0; i<= Txt.length();i++)
        {
            Txt[i]=char( (int)Txt[i] +EncryptionKey);

        }    
        return Txt;
    }
    void Encryption(short EncryptionKey=5)
    {
        Encryption(_strValue,EncryptionKey);
    }

    static string Decryption(string Text, short EncryptionKey=5)
    {
        for(int i=0; i<=Text.length(); i++)
        {
            Text[i]=char( (int)Text[i] -EncryptionKey);
        }
        return Text;
    }
    void Decryption(short EncryptionKey=5)
    {
        Decryption(_strValue,EncryptionKey);
    }

    static string UpperFirstLetterOfWord(string &Txt)
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
    void UpperFirstLetterOfWord()
    {
        _strValue= UpperFirstLetterOfWord(_strValue);
    }

    static string LowerFirstLetterOfWord(string &Txt)
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
    void LowerFirstLetterOfWord()
    {
        _strValue= LowerFirstLetterOfWord(_strValue);
    }
   
    static string InvertAllStringCharsCase( string str)
    {
        for(int i=0; i<str.length(); i++)
        {
            str[i]=_InverceCharCase(str[i]);
        }
        return str;
    }
    void InvertAllStringCharsCase()
    {
        _strValue= InvertAllStringCharsCase(_strValue);
    }

    static unsigned short countCapLetters( string str)
    {   int CoutCap=0;
        for(int i=0; i<str.length(); i++)
        {
             if( isupper(str[i]))
                CoutCap++;
        }
        return CoutCap;
    }
    unsigned short countCapLetters()
    {
        return countCapLetters(_strValue);
    }

    static unsigned short countSmallLetters( string str)
    {   int CoutSmall=0;
        for(int i=0; i<str.length(); i++)
        {
            if( islower(str[i]))
                CoutSmall++;
        }
        return CoutSmall;
    }
    unsigned short countSmallLetters()
    {
        return countSmallLetters(_strValue);
    }

    static string Upper_LowerString(string &Txt,bool ToLower=true)
    {   
        for( int i=0;i<Txt.length(); i++)
        {   
            if(ToLower)
                Txt[i]=char(tolower(Txt[i]));
            else
                Txt[i]=char(toupper(Txt[i]));

        }
    return Txt;
    }
    void Upper_LowerString(bool ToLower=true)
    {
        _strValue= Upper_LowerString(_strValue,ToLower);
    }

    unsigned short CountLetterInString(string str, char CharToCount,bool MatchCase=true)
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
    unsigned short CountLetterInString(char CharToCount,bool MatchCase = true)
    {
        return CountLetterInString(_strValue,CharToCount, MatchCase);
    }

    static bool _IsVowel(char Char)
       {   
           Char=tolower(Char);
           return ((Char == 'a') || (Char == 'e')|| (Char == 'i')|| (Char == 'o')|| (Char == 'u')) ;

       }

    static unsigned short countVowel(string str)
    {   short Counter=0;
        for(int i=0; i< str.length(); i++)
        {
            _IsVowel(str[i])? Counter++ : Counter;
        }
        return Counter;
    }
    unsigned short countVowel()
    {
        return countVowel(_strValue);
    }

    static unsigned short CountEachWordOfStr(string str)
    {
      string Delimiter=" ";
      short pos=0;
      string Word="";
      short Counter=0;

      while ((pos= str.find(Delimiter)) != std::string::npos)
      {
        Word= str.substr(0, pos);
        if(Word != "")
            Counter++;
        str.erase(0,pos + Delimiter.length());

      }
      if(str != "")
        Counter++;

    return Counter;
    
    }
    unsigned short CountEachWordOfStr()
    {
        return CountEachWordOfStr(_strValue);
    }

    static vector <string> Split(string str, string Delimiter)
    { 
        vector <string> vSplitstr;
        string Token="";
        short pos=0;

        while((pos= str.find(Delimiter)) != std::string::npos)
        {
            Token=str.substr(0, pos);
                 
                vSplitstr.push_back(Token);
                
            Token.clear();
            str.erase(0, pos + Delimiter.length());
        }

        if(str != "")
            vSplitstr.push_back(str);
        
        return vSplitstr;
    }
    vector <string> Split(string Delimiter)
    {
        return Split(_strValue ,Delimiter);
    }

    static string JoinStr(vector <string> &vStr, string Delimeter=" ")
    {   
        string str="";
        for(string &Token : vStr)
        {
            str += Token + Delimeter;
        }

        return str.substr(0, str.length() - Delimeter.length());
    }  
    static string JoinStr(string arrStr[],short arrLength ,string Delimeter=" ")
    {   
        string str="";
        for(short i=0; i<arrLength  ; i++)
        {
            str+= arrStr[i] + Delimeter; 
        }

        return str.substr(0, str.length() - Delimeter.length());
    }
    
    static string ReverceWords(string str, string Delimeter=" ")
    {  
        vector <string> vStr;
        string RevStr="";
        vStr= Split(str,Delimeter);

        vector <string>::iterator Iter= vStr.end();
        while(Iter != vStr.begin())
        {
            Iter--;
            RevStr+= *Iter + " ";
        }
        RevStr= RevStr.substr(0, RevStr.length() -1);
        return RevStr;
    }
    void ReverceWords(string Delimeter=" ")
    {
        _strValue= ReverceWords(_strValue, Delimeter);
    }

    static string ReplaceWords(string Str,string Separator=" ",string OldWord="", string NewWord="", bool MatchCase=true)
    {   vector <string> vStr;
        string NewStr="";
        vStr= Split(Str,Separator);

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
                if(Upper_LowerString (OldWord) != Upper_LowerString(Word))
                    NewStr+= Word + " ";
                else
                    NewStr+=NewWord + " ";
            }

        }

        return NewStr.substr(0,NewStr.length()-1);

    }    
    void ReplaceWords(string Separator=" ",string OldWord="", string NewWord="", bool MatchCase=true)
    {
        _strValue= ReplaceWords(_strValue, Separator, OldWord, NewWord, MatchCase);
    }

    static string RemovePunctvations(string Str)
    {
        for(short i=0; i<Str.length(); i++)
        {
            if(ispunct(Str[i]))
            {
                Str.erase(i,1);
            }
        }  
        return Str; 
    }
    void RemovePunctvations()
    {
        _strValue= RemovePunctvations(_strValue);
    }

    static string TrimLeft(string str)
    {   
        for(int i=0; i<str.length(); i++)
        {   
            if(str[i] != ' ' || str[i] != '\t')
            {
                return str.substr(i, str.length()-i );
            }  
        }

        return "";
    }
    void TrimLeft()
    {
        _strValue= TrimLeft(_strValue);
    }

    static string TrimRigth(string str)
    {
        for(int i=str.length(); i > 0; i--)
        {
            if(str[i] != ' ' || str[i] != '\t')
            {
                return str.substr(0, i +1);
            }
        }
        return "";
    }
    void TrimRigth()
    {
        _strValue= TrimRigth(_strValue);
    }

    static string Trim(string str)
    {
        return TrimLeft(TrimRigth(str));
    }
    void Trim()
    {
        _strValue= Trim(_strValue);
    }


};


}

