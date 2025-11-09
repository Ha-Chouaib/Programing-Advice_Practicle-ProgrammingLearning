#include <iostream>
#include <vector>
using namespace std;


int main()
{
    vector <int> vNums={1,2,4,57,6,12,3};

    //--> you can access the elements using [.at(...)]

    cout<<" access with at()" <<endl;
    cout<<"Element at index [0]--> "<< vNums.at(0) <<endl;
    cout<<"Element at index [1]--> "<< vNums.at(1) <<endl;
    cout<<"Element at index [2]--> "<< vNums.at(2) <<endl;
    cout<<"Element at index [4]--> "<< vNums.at(4) <<endl;

    cout<<endl;
    //--> you can access the elements using the normal index (vectName[index]).

    cout<<" access with [index]" <<endl;
    cout<<"Element at index [0]--> "<< vNums[0] <<endl;
    cout<<"Element at index [1]--> "<< vNums[1] <<endl;
    cout<<"Element at index [2]--> "<< vNums[2] <<endl;
    cout<<"Element at index [4]--> "<< vNums[4] <<endl;



    return 0;
}