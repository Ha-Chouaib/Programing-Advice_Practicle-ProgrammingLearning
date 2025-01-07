#include <iostream>
using namespace std;

enum enMonthOfYear{

    January   = 1,
    February  = 2,
    March     = 3,
    April     = 4,
    May       = 5,
    June      = 6,
    July      = 7,
    August    = 8,
    september = 9,
    October   = 10,
    November  = 11,
    December  = 12,
};
int ReadNumberInRange(string MSG, int From, int To){

    int Number=0;
    do{
        cout<< MSG <<endl;
        cin>>Number;
    }while( From > Number || Number >To);

    return Number;
}

enMonthOfYear GetMonthNumber(){

    return (enMonthOfYear) ReadNumberInRange("Please enter a month number from 1 to 12",1,12);
}

string GetMonthName(enMonthOfYear Month){

    switch(Month){

        case enMonthOfYear::January :
            return "january";
        case enMonthOfYear::February :
            return "Febrary";
        case enMonthOfYear::March :
            return "March";
        case enMonthOfYear::April :
            return "April";
        case enMonthOfYear::May :
            return "May";
        case enMonthOfYear::June :
            return "June";
        case enMonthOfYear::July :
            return "July";
        case enMonthOfYear::August :
            return "August";
        case enMonthOfYear::september :
            return "September";
        case enMonthOfYear::October :
            return "October";
        case enMonthOfYear::November :
            return "November";
        case enMonthOfYear::December :
            return "Desember";
        default:
            return "Wrong option"; 
    }
}
int main(){

    cout<< GetMonthName(GetMonthNumber())<<endl;
    return 0;
}