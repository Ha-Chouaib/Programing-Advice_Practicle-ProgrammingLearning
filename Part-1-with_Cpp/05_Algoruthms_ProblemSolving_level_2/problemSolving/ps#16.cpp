#include <iostream>
using namespace std;

//write a program print all possibilities form [AAA] to [ZZZ].

void PrintLettersFormAAAtoZZZ(){

    cout<<endl;
    string Word="";
    for(int i=65; i<=90; i++)
    {

       for(int x=65; x<= 90 ;x++)
       {
            for (int y = 65; y <=90; y++)
            {
                Word+=char(i);
                Word+=char(x);
                Word+=char(y);
                cout<<  Word <<endl;

                Word="";
            }
            
       }
       cout<<"----------------------\n";
    }
}

int main(){

    PrintLettersFormAAAtoZZZ();
    return 0;
}