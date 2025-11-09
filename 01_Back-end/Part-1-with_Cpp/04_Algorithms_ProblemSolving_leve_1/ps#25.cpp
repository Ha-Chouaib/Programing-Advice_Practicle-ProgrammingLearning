#include <iostream>
using namespace std;

short ReadAge(){
    short Age= 0;
    cout<<"Enter the Age between 18 and 45: ";
    cin>>Age;
    return Age;
}

bool ValidateNumberInRange(short Number, short From, short To){
    return (Number >= From && Number<= To);
}

short ReadAgeUtileBetween(short From, short To){
    short Age=0;
    do
    {
        Age=ReadAge();
    } while (! ValidateNumberInRange(ReadAge(),From,To));

    return Age;
    
}

void DisplayResult(short Age){
    
        cout<<"Is a Valide Age."<<endl;
        
}
int main(){

    DisplayResult(ReadAgeUtileBetween(18,45));
    return 0;
}