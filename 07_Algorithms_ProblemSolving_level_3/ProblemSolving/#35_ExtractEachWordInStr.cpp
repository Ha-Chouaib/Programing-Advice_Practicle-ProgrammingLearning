#include<iostream>
#include<cctype>
using namespace std;

// write a program raed a string and then print Each word in that string.
string ReadTxt(string MSG)
{   
    string Txt="";
    cout<< MSG <<endl;
    getline(cin, Txt);

    return Txt;
}
//--> My method
void PrintWordsOfStr(string str)
{
    string Word="";
    for(int i=0; i<str.length(); i++)
    {
        if(str[i] !=' ' )
        {
            Word+=str[i];
        }else
        {
            cout<< Word <<endl;
            Word="";        
        }
    }
    if(Word != "")
        cout<< Word <<endl;
}
//-->Prof Method
void CountEachWordOfStr(string str)
{
   string Delimiter=" ";
   short pos=0;
   string Word="";
   while((pos=str.find(Delimiter)) != std::string::npos)//--> [npos]==No position
    {
        Word= str.substr(0, pos);
        if(Word != "")
            cout<< Word <<endl;

        str.erase(0, pos + Delimiter.length()); //->[erase]-->Cat a part of string.
    }
    if(str !="")
        cout<< str <<endl;
}

int main()
{
    string str=ReadTxt("Please enter a string");

    // PrintWordsOfStr(str);
    CountEachWordOfStr(str);
    return 0;
}