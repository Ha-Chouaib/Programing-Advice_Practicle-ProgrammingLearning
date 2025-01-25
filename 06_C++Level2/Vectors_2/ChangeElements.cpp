#include <iostream>
#include <vector>
using namespace std;



int main()
{   
    vector <int> x={1,3,4,6};

    cout<<"vector initial values: "<<endl;
    for(const int &n :x)
    {
        cout<< n <<endl;
    }

    cout<<"Values updated using for()\n";
    for(int &n : x)
    {
        n++;
        cout<< n <<endl;
    }

    cout<<endl;

    cout<<"Values Updating using [index]=\\ at(...)=..."<<endl;
    x[0]=100;
    x[1]=1000;
    x.at(2)=10000;
    x.at(3)=100000;

    for(const int &n :x)
    {
        cout << n <<endl;
    }


    return 0;
}