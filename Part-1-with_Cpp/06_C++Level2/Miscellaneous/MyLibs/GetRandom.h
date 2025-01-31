#pragma once
#include <iostream>
#include <cstdlib>
using namespace std;

namespace GetRandom
{
int RandomNumber(int From, int To)
{
    int RandNum= rand()% (To -From +1) +From;
    return RandNum;
}

enum enRandomCharType
{
    SmallLetter=1,
    CapitalLetter=2,
    SpecialCaracter=3,
    Digit=4,
    All=5,
};

enRandomCharType ReadCharType()
{   
    int Randoption;
    cout<< "\nTo get Random of: "
        <<"\nsmall letter      Enter-->[1]"
        <<"\nCapital letter    Enter-->[2]"
        <<"\nSpecial Character Enter-->[3]"
        <<"\na Digit           Enter-->[4]"
        <<"\nUse all           Enter-->[5]"
        <<"\n: ";
    cin>>Randoption;
    return (enRandomCharType )Randoption;

}

char GetRandomChar( enRandomCharType CharType)
{
    switch(CharType)
    {
    case enRandomCharType::SmallLetter :
        return char(RandomNumber(97,122));

    case enRandomCharType::CapitalLetter:
        return char(RandomNumber(65,90));

    case enRandomCharType::SpecialCaracter:
        return char(RandomNumber(33,47));
        
    case enRandomCharType::Digit:
        return char(RandomNumber(48,57));

    case enRandomCharType::All:
        return char(RandomNumber(32,127));

    default:
        return char(RandomNumber(48,57));
    }
}

string GenerateRandomWord(enRandomCharType CharType, short HowmanyChars)
{

    string RandWord="";
    
    for(int i=1; i<=HowmanyChars; i++)
    {
        RandWord+= GetRandomChar(CharType);
        
    }
    return RandWord;
}

string AddSeparator(short i,short Length, string Separator)
{   
    if(i >= 1 && i <Length && Length !=1 )
        return Separator;
    return "";
}

string GenerateRandomKey(enRandomCharType CharType, short HowmanyParts,short HowmanyChars )
{
    string RandKey="";
    for(int i=1; i <=HowmanyParts; i++)
    {
        RandKey+=GenerateRandomWord(CharType,HowmanyChars) + AddSeparator(i,HowmanyParts,"-");
    }
    return RandKey;
}


}