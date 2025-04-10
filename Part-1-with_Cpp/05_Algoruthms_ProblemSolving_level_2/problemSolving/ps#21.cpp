#include <iostream>
#include <cstdlib>
using namespace std;

//write a program print random keys based on user instructions:
//##Choose the Char Type.
//##How Many keys.
//##How Many Parts on the key.
//##How Many Chars on the Part.

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

float ReadPositiveNumber(string MSG){
    float Num=0;
    do{
        cout<< MSG <<endl;
        cin>> Num;
    }while(Num < 0);
    return Num;
}

int RandomNumber(int From, int To)
{
    int RandNum= rand()% (To -From +1) +From;
    return RandNum;
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

void GenerateRandomKeys(enRandomCharType CharType ,int HowManyKeys,short HowmanyParts, short HowmanyChars)
{
    for(int i=1; i<=HowManyKeys; i++)
    {
        cout<<"Key["<< i <<"]: "<<GenerateRandomKey(CharType,HowmanyParts, HowmanyChars)<<endl;
    }
}


int main()
{
    srand((unsigned)time(NULL));

    enRandomCharType Chartype= ReadCharType();
    int HowmanyKeys= ReadPositiveNumber("How many keys do you want?");
    short HowmanyParts= ReadPositiveNumber("How many Parts do you want in the key?");
    short HowmanyChars= ReadPositiveNumber("How many Characters do you want in a part?");

    GenerateRandomKeys(Chartype, HowmanyKeys, HowmanyParts,HowmanyChars);
    return 0;
}