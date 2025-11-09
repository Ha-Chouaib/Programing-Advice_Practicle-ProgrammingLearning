#include <iostream>
#include <vector>
using namespace std;

//--> the concept of Iterator it meains just access of vector elements using pionters.
int main()
{   
    vector <int> Vec={12,3,4,55,6,6,7};

    vector<int> ::iterator iter ;//ypu can  name it any.

    for(iter = Vec.begin(); iter != Vec.end(); iter++)
    {
        cout << *iter <<endl;
    }

    return 0;
}