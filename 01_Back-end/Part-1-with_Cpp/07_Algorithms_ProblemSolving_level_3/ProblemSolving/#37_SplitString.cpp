#include <iostream>
#include <string>
#include <vector>
using namespace std;

// write a program raed a string and then Make a function to split  Each word in vector .
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

void PrintSplitWords(vector <string> vWords)
{   cout<<"Token= "<<vWords.size() <<endl;
    for(string &Line : vWords)
    {
        cout<< Line <<endl;
    }
}

int main()
{   
    string str=ReadTxt("Please enter a text:");
    vector <string> vSplitStr;
    MySplit(str,vSplitStr,"h");
    PrintSplitWords(vSplitStr);
    


    return 0;
}