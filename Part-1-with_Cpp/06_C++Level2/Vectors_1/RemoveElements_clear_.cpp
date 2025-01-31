#include <iostream>
#include <vector>
using namespace std;

int main()
{
    vector <int> vNums;

    vNums.push_back(10);
    vNums.push_back(11);
    vNums.push_back(23);
    vNums.push_back(45);
    vNums.push_back(54);

    cout<<"Vector size: "<<vNums.size()<<endl;
    vNums.clear();// clear() remove all at once
    cout<<"Vector size: "<<vNums.size()<<endl;

    return 0;
}