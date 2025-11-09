#include <iostream>
#include <string>
using namespace std;

enum enReverceFullName{First_to_Last=0, Last_to_First=1};
struct stInfo{
    string FirstName;
    string LasttName;
};

stInfo ReadInfo(){
    stInfo Info;

    cout<<"enter the First Name: ";
    cin>> Info.FirstName;

    cout<< "enter the Last Name: ";
    cin>>Info.LasttName;

    return Info;
}

string GetFullName(stInfo Info, bool Reverced){
    string FullName= "";
    if(Reverced)
        FullName = Info.LasttName + " " + Info.FirstName ;
    else
        FullName = Info.FirstName + " " + Info.LasttName ;


    return FullName;
}

void DisplayFullName(string FullName){

    cout<< "Hello! "<< FullName <<endl;
}

int main()
{

    DisplayFullName(GetFullName(ReadInfo(), enReverceFullName::Last_to_First));

    return 0;
}
