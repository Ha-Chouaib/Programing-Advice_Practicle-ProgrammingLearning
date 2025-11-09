#pragma once
#include <iostream>
#include <string>
using namespace std;

namespace HandleStr
{
string Encryption(string Txt, short EncryptionKey)
    {
        for(int i=0; i<= Txt.length();i++)
        {
            Txt[i]=char( (int)Txt[i] +EncryptionKey);

        }    
        return Txt;
    }
    
string Decryption(string Text, short EncryptionKey)
    {
        for(int i=0; i<=Text.length(); i++)
        {
            Text[i]=char( (int)Text[i] -EncryptionKey);
        }
        return Text;
    }
}