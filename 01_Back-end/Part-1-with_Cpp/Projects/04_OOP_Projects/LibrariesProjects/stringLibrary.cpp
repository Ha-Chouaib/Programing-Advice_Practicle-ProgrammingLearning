#include<iostream>
#include "clsString.h"
using namespace std;


int main()
{
    cout <<"Small Letters Number: "<< clsString::countSmallLetters("Hello my man what's good?") <<endl;
    clsString S1;
    S1.ReadStringFromUser("Please enter a txt?");

    cout<< "Vawels Number: " <<S1.countVowel() <<endl;
    cout<< "Words Number: " <<S1.CountEachWordOfStr() <<endl;


    return 0;
}