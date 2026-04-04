#include<iostream>
#include"clsDate.h"

using namespace std;

int main()
{

    clsDate Date1;
    cout<<"Current Date: ";
    Date1.print();

    cout<<"Date After Adding One Day: ";
    Date1.PlusOneDay();
    Date1.print();
    
    clsDate D2("1/2/2000");
    D2.print();

    cout<<"Difference between Date1 and Date2: " <<Date1.GetDiffereceOfTowDates(D2) <<endl;

    return 0;
}


