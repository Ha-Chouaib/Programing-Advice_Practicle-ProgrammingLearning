#include<iostream>
#include<cctype>
using namespace std;

char ReadChar(string MSG)
{
    char Letter;
    cout<< MSG <<endl;
    cin>> Letter;

    return Letter;
}

bool IsVowel(char Char)
{   
    Char=tolower(Char);
    return ((Char == 'a') || (Char == 'e')|| (Char == 'i')|| (Char == 'o')|| (Char == 'u')) ;
        
}

void IsVowelResult(char Char)
{

    IsVowel(Char) ?  cout<<"The Char \'"<< Char <<"\' is a VOWEL"<<endl :cout<<"The Char \'"<< Char <<"\' is NOT a VOWEL"<<endl;
    
}
int main()
{
    char Char=ReadChar("Enter a character");
    IsVowelResult(Char);
    return 0;
}