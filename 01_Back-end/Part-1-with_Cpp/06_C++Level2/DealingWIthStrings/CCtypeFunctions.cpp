#include <iostream>
#include <string>
#include <cctype>

using namespace std;


int main()
{   char X,Y;
    X='e';
    Y='E';
    cout<<"tolower(): "<< X <<" --> "<<char(tolower(X)) <<endl; 
    cout<<"toupper(): "<< Y <<" --> "<<char(toupper(Y))<<endl;

    cout<< X<<"isupper(): "<<isupper(X) <<endl; // if uppper returns any numbers exipt 0 if not return 0;
    cout<< Y<<"islower(): "<<islower(Y) <<endl; // if uppper returns any numbers exipt 0 if not return 0;

    cout<<"[9] isdigit(): "<< isdigit('9') <<endl;// digit from 1 to 9
    cout<<"[A] isdigit(): "<< isdigit('A') <<endl;

    //punctuation characters are:!@#$%^&*()><?|...
    cout<< "[;] ispunct(): " << ispunct(';') <<endl;
    cout<< "[l] ispunct(): " << ispunct('l') <<endl;

    return 0;
}