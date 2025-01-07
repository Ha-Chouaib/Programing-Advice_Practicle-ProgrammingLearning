#include <iostream>
#include <string>
using namespace std;

//-->Write a program read a string and then trim left ,right amd all.

string ReadTxt(string MSG)
{   
    string Txt="";
    cout<< MSG <<endl;
    getline(cin, Txt);

    return Txt;
}

string TrimLeft(string str)
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

string TrimRigth(string str)
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

string Trim(string str)
{
    return TrimLeft(TrimRigth(str));
}

int main()
{   
    string str=ReadTxt("Enter a string");

    
    cout<<"\nTrimLeft: "<<TrimLeft(str) <<endl;
    cout<<"\nTrimRigth: "<<TrimRigth(str) <<endl;
    cout<<"\nTrim: "<<Trim(str) <<endl;

    return 0;
}