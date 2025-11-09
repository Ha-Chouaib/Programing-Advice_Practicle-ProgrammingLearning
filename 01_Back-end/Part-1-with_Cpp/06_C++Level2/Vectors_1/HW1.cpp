#include <iostream>
#include <vector>
using namespace std;



int main()
{
    vector <int> vNum ={12,23,1,24,3,5,6};

    for(int &N : vNum)
    {
        cout<< N <<" ";
    }
    cout<<endl;
    return 0;
}