#include<iostream>
#include <vector>
using namespace std;


int main()
{   
    vector <int> vNumber;

    vNumber.push_back(1);
    vNumber.push_back(2);
    vNumber.push_back(3);
    vNumber.push_back(4);
    vNumber.push_back(5);

    for(int &Number: vNumber)
    {
        cout<< Number <<endl;
    }


    return 0;
}