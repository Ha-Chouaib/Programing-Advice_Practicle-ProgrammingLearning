#include <iostream>
using namespace std;

enum enDays{Sun=1, Mon=2, Tue=3, Wed=4, Thu=5, Fri=6, Sat=7};

int ReadNumberInRange(string MSG, int From, int To){

    int Number=0;
    do{
        cout<< MSG <<endl;
        cin>>Number;
    }while( From > Number || Number >To);

    return Number;
}

enDays GetDayNumber(){

    return (enDays) ReadNumberInRange("Please enter :\n (1 For Sun),\n (2 For Mon),\n (3 For Tue),\n (4 For Wed),\n (5 For Thu),\n (6 For Fri),\n (7 For Sat) ",1,7);
}

string GetDayName(enDays Day){

    switch(Day){

        case enDays::Sun :
            return "Sunday";
        case enDays::Mon :
            return "Monday";
        case enDays::Tue :
            return "Tuesday";
        case enDays::Wed :
            return "Wednesday";
        case enDays::Thu :
            return "Thursday";
        case enDays::Fri :
            return "Friday";
        case enDays::Sat :
            return "Saturday";
        default:
            return "Wrong option"; 
    }
}

int main(){

    cout<<GetDayName(GetDayNumber())<<endl;
    return 0;
}