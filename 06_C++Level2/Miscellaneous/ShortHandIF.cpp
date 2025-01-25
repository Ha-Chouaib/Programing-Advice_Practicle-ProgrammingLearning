#include <iostream>
using namespace std;


bool IsPositiveNum(float Num)
{
    return (Num > 0)? 1:0;
}


int main()
{
    int num=1;
    string Result=(num == 0)? "The number= Zero" : IsPositiveNum(num)? "Positive" : "Negative";

    cout<< Result <<endl;
    return 0;
}