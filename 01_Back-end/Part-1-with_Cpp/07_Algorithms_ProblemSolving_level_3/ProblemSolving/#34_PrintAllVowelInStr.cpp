#include<iostream>
#include<cctype>
using namespace std;

// write a program raed a string and then print all vowel letters of that str.
string ReadTxt(string MSG)
{   
    string Txt="";
    cout<< MSG <<endl;
    getline(cin, Txt);

    return Txt;
}
bool IsVowel(char Char)
{   
    Char=tolower(Char);
    return ((Char == 'a') || (Char == 'e')|| (Char == 'i')|| (Char == 'o')|| (Char == 'u')) ;
        
}

void PrintVowels(string str)
{   
    for(int i=0; i< str.length(); i++)
    {
        if(IsVowel(str[i]) )
            cout<<str[i] <<"   ";
    }
    cout<<endl;
}

int main()
{
    string str=ReadTxt("Please enter a string");

    cout<<"Vowels in the string are: ";
    PrintVowels(str);
    return 0;
}