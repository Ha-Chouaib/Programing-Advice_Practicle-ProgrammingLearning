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

string JoinStr(string arrStr[4],short arrLength ,string Delimeter=" ")
{   
    string str="";
    for(short i=0; i<arrLength  ; i++)
    {
        str+= arrStr[i] + Delimeter; 
    }

    return str.substr(0, str.length() - Delimeter.length());
}

int main()
{   vector <string> vstr={"Chouaib","Brahim","Hicham","Kamal"};
    string arrStr[4]={"Ali","Ahned","Mazin","Non"};

    cout<<"Vector content: "<<endl;
    for(string &Token :vstr)
    {
        cout<< Token <<endl;
    }
    cout<<"\nAfter Join Strings with vector: "<< JoinStr(vstr) <<endl;

    cout<<"\nArray content: "<<endl;
    for(string &Token :arrStr)
    {
        cout<< Token <<endl;
    }
    cout<<"\nAfter Join Strings with array: "<< JoinStr(arrStr,4,"\\ ") <<endl;

    return 0;
}