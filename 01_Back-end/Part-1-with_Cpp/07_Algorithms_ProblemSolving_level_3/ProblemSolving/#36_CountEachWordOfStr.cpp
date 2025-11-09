#include<iostream>
#include<cctype>
using namespace std;

// write a program raed a string and then Count Each word in that string.
string ReadTxt(string MSG)
{   
    string Txt="";
    cout<< MSG <<endl;
    getline(cin, Txt);

    return Txt;
}

short CountEachWordOfStr(string str)
{
  string Delimiter=" ";
  short pos=0;
  string Word="";
  short Counter=0;

  while ((pos= str.find(Delimiter)) != std::string::npos)
  {
    Word= str.substr(0, pos);
    if(Word != "")
        Counter++;
    str.erase(0,pos + Delimiter.length());

  }
  if(str != "")
    Counter++;

return Counter;
  
}

int main()
{
    string str=ReadTxt("Please enter a string");

    cout<<"The number Of the Words in the string is: " <<CountEachWordOfStr(str)<<endl;
    return 0;
}