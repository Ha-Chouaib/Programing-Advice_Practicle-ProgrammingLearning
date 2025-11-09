#include<iostream>
#include<cctype>
using namespace std;

//Write a program  that Read a char then invert its case. and print it

char ReadChar(string MSG)
{
    char Letter;
    cout<< MSG <<endl;
    cin>> Letter;

    return Letter;
}

char InverCharCase(char Char)
{
    return (islower(Char)) ? char(toupper(Char)):char(tolower(Char));
}

int main()
{
    char Char=ReadChar("Please enter a char");

    Char=InverCharCase(Char);
    cout<< Char <<endl;

    return 0;
}