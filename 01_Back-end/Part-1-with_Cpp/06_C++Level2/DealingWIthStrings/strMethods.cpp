#include <iostream>
#include <string>
using namespace std;



int main()
{
    string str="I'am the bset ever as a software engineer";

    cout<<"str length: " <<str.length()<<endl;

    cout<<"the Lettre that at position (8): " <<str.at(8) <<endl;

    str.append(" My name is chouaib hadadi.");// Add a text at the end of string variable value.
    cout<< str <<endl;

    str.push_back('G'); // Add just character at the end.
    cout<< str <<endl;

    str.insert(6," {King} ");// Add a text at specific position you want.
    cout<< str <<endl;

    str.pop_back();//Remove the last char from the string.
    cout<< str <<endl;

    cout<< str.find("chouaib") <<endl;//Find the position of a txt in the string.

    cout<< str.find("Chouaib") <<endl;
    //But if the text you loking for doesn't exist  well show an a long number maens the the txt not found.
    // so that's whay its better to use :

    if(str.find("Chouaib")== str.npos)
        cout<<"Chouaib Not Found" <<endl; // instead of the long number.

    str.clear();// clear the whole string.
    cout<< str <<endl;



    return 0;
}