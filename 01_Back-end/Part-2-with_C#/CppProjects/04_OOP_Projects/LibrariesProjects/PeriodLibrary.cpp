#include <iostream>
#include "clsPeriod.h"

int main()

{

    clsPeriod Period1(clsDate(1, 1, 2025), clsDate(18, 3, 2025));
    Period1.Print();

    cout << "\n";

    clsPeriod Period2(clsDate(3, 1, 2025), clsDate(5, 1, 2025));
    Period2.Print();

    cout << Period1.IsOverLapWith(Period2) <<endl;

    cout << clsPeriod::IsOverlapPeriods(Period1, Period2) << endl;

    cout<<"Period Length: "<< Period1.Length();

    
    return 0;
}