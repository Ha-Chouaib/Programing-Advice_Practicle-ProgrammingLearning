#include<iostream>
#include<cctype>
using namespace std;

//Write a program  that Read a string and count capital and small letters and the whole str length . and print it

string ReadTxt(string MSG)
{   
    string Txt="";
    cout<< MSG <<endl;
    getline(cin, Txt);

    return Txt;
}
enum enCountCapOrSmall{cap=1, Small=2, all=3};
//Generic function.
short countLetters(string str, enCountCapOrSmall capORsmall=enCountCapOrSmall::all)
{   
    if(capORsmall == enCountCapOrSmall::all)
        return str.length();
     int counter=0;
    for(int i=0; i<str.length(); i++)
    {
         if(capORsmall == enCountCapOrSmall::cap && isupper(str[i]))
            counter++;
        if(capORsmall == enCountCapOrSmall::Small && islower(str[i]))
            counter++;
    }
    return counter;
}

int countCapLetters( string str)
{   int CoutCap=0;
    for(int i=0; i<str.length(); i++)
    {
         if( isupper(str[i]))
            CoutCap++;
    }
    return CoutCap;
}
int countSmallLetters( string str)
{   int CoutSmall=0;
    for(int i=0; i<str.length(); i++)
    {
        if( islower(str[i]))
            CoutSmall++;
    }
    return CoutSmall;
}

int main()
{
    string txt=ReadTxt("Please enter a string");
    
    cout<<"Method 1:\n";
    cout<<"String Length: "<<txt.length() <<endl;
    cout<<"Capital letters are: "<<countCapLetters(txt) << " letter\n";
    cout<<"Smaall letters are: "<< countSmallLetters(txt) << " letter\n";
    
    cout<<"\n\nMethod 2:\n";
    cout<<"String Length: "<<countLetters(txt) <<endl;
    cout<<"Capital letters are: "<<countLetters(txt,enCountCapOrSmall::cap) << " letter\n";
    cout<<"Smaall letters are: "<< countLetters(txt,enCountCapOrSmall::Small) << " letter\n";
    

    return 0;
}