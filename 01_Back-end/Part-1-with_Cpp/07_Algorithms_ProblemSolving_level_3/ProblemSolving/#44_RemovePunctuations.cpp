#include <iostream>
#include <vector>
#include <cctype>
#include <string>

using namespace std;

// write a program read astring then remove all punctuations in that string

string ReadTxt(string MSG)
{   
    string Txt="";
    cout<< MSG <<endl;
    getline(cin, Txt);

    return Txt;
}

string RemovePunctvations(string Str)
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

int main()
{   
    string Str=ReadTxt("please enter a string With Punctuations");

    cout<<"\n\nThe Original String: "<<endl;
    cout<<Str<<endl;

    cout<<"After Removint Punctuations: "<<endl;
    cout<<RemovePunctvations(Str)<<endl;


    return 0;
}