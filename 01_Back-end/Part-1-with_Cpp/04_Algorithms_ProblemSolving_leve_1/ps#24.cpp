#include <iostream>
using namespace std;

short ReadAge(){
    short Age= 0;
    cout<<"Enter the Age: ";
    cin>>Age;
    return Age;
}

bool ValidateNumberInRange(short Number, short From, short To){
    return (Number >= From && Number<= To);
}

void DisplayResult(short Age){
    if(ValidateNumberInRange(Age,18,45))
        cout<<"Is a Valide Age."<<endl;
    else
        cout<<"Is Not a Valide Age."<<endl;
}
int main(){

    DisplayResult(ReadAge());
    return 0;
}