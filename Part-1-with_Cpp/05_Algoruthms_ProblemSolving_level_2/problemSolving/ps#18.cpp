#include <iostream>
using namespace std;

//write a program that Encrypt and Decrypt a Text.

string ReadText(string MSG){
    string  str="";
    cout<< MSG <<endl;
    getline(cin,str);
    return str;
}

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

void BeforAfterEncryption(string BeforEnc, string AfterEnc){

    cout<< "Text befor Encryption: "<< BeforEnc <<endl;
    cout<< "Text after Encryption: "<< AfterEnc <<endl;
}

int main(){
    const short EncryptionKey=2;
    string GetText="", TxtBeforEncryption="", TxtAfterEncryption="";

    GetText= ReadText("enter a text to encrypt");

    TxtAfterEncryption= Encryption(GetText, EncryptionKey);
    TxtBeforEncryption= Decryption( TxtAfterEncryption,EncryptionKey);

    BeforAfterEncryption(TxtBeforEncryption, TxtAfterEncryption);
    


    return 0;
}