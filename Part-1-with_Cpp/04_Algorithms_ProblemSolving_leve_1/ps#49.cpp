#include <iostream>
using namespace std;

string ReadPinCode(){

    string PinCode="";
    cout<< "please entre the PIN Code:";
    cin>>PinCode;
    return PinCode;
}

bool Login(){
    string PINCode;
    do{
        PINCode= ReadPinCode();
        if(PINCode == "1234")
            return 1;
        else{

            cout<<"\nWrong Pass Please try again"<<endl;
            system("color 4F");
        }
    }while( PINCode != "1234");
    return 0;
}

int main(){

    if(Login()){
        system("color 2F");
        cout<<"\n your Balance is: "<< 12357 <<endl;

    };
    return 0;
}