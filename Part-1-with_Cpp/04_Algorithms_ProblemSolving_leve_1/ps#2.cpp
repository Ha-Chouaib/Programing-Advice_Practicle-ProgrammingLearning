#include <iostream>
#include <string>
using namespace std;

string GetName(){

    string Name;
    cout<<"please enter your name: ";
    getline(cin, Name);

    return Name;
}

void DisplayName(string Name){

    cout<< "your name is: "<<Name <<endl;
}

int main(){

    DisplayName(GetName());

    return 0;
}