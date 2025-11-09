#include<iostream>
#include<cctype>
using namespace std;

// write a program raed a string and then count the vowel letters of that str.
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

short countVowel(string str)
{   short Counter=0;
    for(int i=0; i< str.length(); i++)
    {
        IsVowel(str[i])? Counter++ : Counter;
    }
    return Counter;
}

int main()
{
    string str=ReadTxt("Please enter a string");

    cout<<"You Have [ "<< countVowel(str) <<" ] Vowel in that string"<<endl;
    return 0;
}