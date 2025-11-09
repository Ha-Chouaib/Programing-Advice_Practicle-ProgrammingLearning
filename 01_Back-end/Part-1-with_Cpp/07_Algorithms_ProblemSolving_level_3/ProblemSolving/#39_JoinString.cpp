#include <iostream>
#include <vector>
using namespace std;

// write a program Join strings within a vector the print the vector elements and also the joined strinds


string JoinStr(vector <string> &vStr, string Delimeter=" ")
{   
    string str="";
    for(string &Token : vStr)
    {
        str += Token + Delimeter;
    }

    return str.substr(0, str.length() - Delimeter.length());
}

int main()
{   vector <string> vstr={"Chouaib","Brahim","Hicham","Kamal"};

    cout<<"Vector content: "<<endl;
    for(string &Token :vstr)
    {
        cout<< Token <<endl;
    }

    cout<<"\nAfter Join Strings: "<< JoinStr(vstr) <<endl;
    cout<<"After Join Strings: "<< JoinStr(vstr,";") <<endl;

    return 0;
}