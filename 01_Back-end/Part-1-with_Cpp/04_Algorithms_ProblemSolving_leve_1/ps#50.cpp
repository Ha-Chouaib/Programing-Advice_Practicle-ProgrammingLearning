#include <iostream>
using namespace std;



string ReadPinCode(){

    string PinCode="";
    cout<< "please entre the PIN Code:";
    cin>>PinCode;
    return PinCode;
}

bool Login()
{
    string PINCode;
    short counter= 0;
    do
    {
        PINCode= ReadPinCode();
        if(PINCode == "1234")
            return 1;
        else
        {
            counter++;
            if(counter == 3)
                return 0;

            cout<<"\nWrong Pass Please try again";
            cout<<"\nyou still have "<< 3 - counter << " attempts"<<endl;    
        }
    }while( PINCode != "1234" || counter <=3);
    return 0;
}

int main(){

    if(Login())
    {
        cout<<"\n your Balance is: "<< 12357 <<endl;
    }else
    {
        cout<<" Your Cat is Blocked.";
    };
    return 0;
}