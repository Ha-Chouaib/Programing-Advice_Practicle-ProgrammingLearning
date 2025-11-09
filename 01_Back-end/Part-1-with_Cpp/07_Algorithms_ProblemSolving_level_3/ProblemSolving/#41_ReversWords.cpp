#include <iostream>
#include <string>
#include <vector>

using namespace std;
//Write a program read string then reverce  the string words and then print it.

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


string ReverceWords(string str)
{  
    vector <string> vStr;
    string RevStr="";
    MySplit(str,vStr," ");

    vector <string>::iterator Iter= vStr.end();
    while(Iter != vStr.begin())
    {
        Iter--;
        RevStr+= *Iter + " ";
    }
    RevStr= RevStr.substr(0, RevStr.length() -1);
    return RevStr;
}

int main()
{   string str=ReadTxt("Enetr a txt:");

    

    cout<<"The string after revercing words:"<<endl;
    cout<<ReverceWords(str)<<endl;

    return 0;
}