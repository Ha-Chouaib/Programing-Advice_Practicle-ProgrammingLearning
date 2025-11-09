#include <iostream>
using namespace std;

short ReadNumberInRange(short From, short To){

    short Grade;
    do{
        cout<<"please enter The Grade between 0 and 100: "<<endl;
        cin>>Grade;
    }while(From > Grade || Grade > To);
    return Grade;
}

char FilterGrades(short Grade){

    if(Grade >= 90)
        return 'A';
    else if(Grade >=80)
        return 'B';
    else if(Grade >=70)
        return 'C';
    else if(Grade >=60)
        return 'D';
    else if(Grade >=50)
        return 'E';
    else 
        return 'F';
}

void ShowResult(char Result, string MSG=""){

    cout<<endl << MSG << Result <<endl;
}
int main(){

    ShowResult(FilterGrades(ReadNumberInRange(0,100)),"The Grade is in: ");
    return 0;
}