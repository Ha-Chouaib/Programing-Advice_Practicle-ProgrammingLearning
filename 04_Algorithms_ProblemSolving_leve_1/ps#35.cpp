#include <iostream>
using namespace std;

struct stBiggyBanckInfo{
    short Pennies, Nickels, Dimes, Quarters, Dollars;
};

stBiggyBanckInfo ReadBiggyBanckInfo(){
    stBiggyBanckInfo Banck;

    cout<<"How Much Pennies: ";
    cin>>Banck.Pennies;
    cout<<"How Much Nickels: ";
    cin>>Banck.Nickels;
    cout<<"How Much Dimes: ";
    cin>>Banck.Dimes;
    cout<<"How Much Quarters: ";
    cin>>Banck.Quarters;
    cout<<"How Much Dollars: ";
    cin>>Banck.Dollars;

    return Banck;
}

int GetTotPennies(stBiggyBanckInfo Banck){
    
    int TotPen=Banck.Pennies + Banck.Nickels *5 + Banck.Dimes *10 + Banck.Quarters *25 + Banck.Dollars *100; 
    return TotPen;
}  

template<typename Param> // To keep the parameter type Dynamic "you can name it any"
void ShowResult(Param Result, string MSG=""){

    cout<<endl << MSG << Result <<endl;
}


int main(){
    int TotPennies =GetTotPennies(ReadBiggyBanckInfo());
    
    ShowResult(TotPennies,"The Total Of Pennies you have is: ");
    ShowResult( (float)TotPennies/100,"The Total Of Dollars you have is: ");
    
    return 0;
}