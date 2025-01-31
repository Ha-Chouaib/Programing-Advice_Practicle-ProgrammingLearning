#include <iostream>
#include <cstdlib>
using namespace std;

//write a program ask the user  to Choose acharacter type, then print a random char in tha type.
 

enum enRandomCharType
{
    SmallLetter=1,
    CapitalLetter=2,
    SpecialCaracter=3,
    Digit=4,
};
int RandomNumber(int From, int To)
{
    int RandNum= rand()% (To -From +1) +From;
    return RandNum;
}
enRandomCharType ReadCharType()
{   
    int Randoption;
    cout<< "\nTo get Random of: "
        <<"\nsmall letter      Enter-->[1]"
        <<"\nCapital letter    Enter-->[2]"
        <<"\nSpecial Character Enter-->[3]"
        <<"\na Digit           Enter-->[4]"
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
        
    default:
        return char(RandomNumber(48,57));
    }
}

int main()
{
    srand((unsigned)time(NULL));
    enRandomCharType CharType= ReadCharType();
    cout<< GetRandomChar(CharType) <<endl;

    return 0;
}