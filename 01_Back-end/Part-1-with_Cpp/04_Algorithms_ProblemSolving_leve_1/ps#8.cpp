#include <iostream>
using namespace std;

enum enPassFail{Fail=0, Pass=1};

int ReadMark(){
    int Mark;
    cout<<"please Add a Mark: ";
    cin>>Mark;
    return Mark;
}

bool CheckMark_IsPass(int Mark){

    if( Mark >= 50)
        return enPassFail::Pass;
    else
        return enPassFail::Fail;
}

void DisplayResult(int Mark){

    if(CheckMark_IsPass(Mark))
        cout<<"\nPass"<<endl;
    else
        cout<<"\nFail"<<endl;
}

int main(){

    DisplayResult(ReadMark());
    return 0;
}