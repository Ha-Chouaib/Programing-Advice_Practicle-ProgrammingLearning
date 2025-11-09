#include <iostream>
#include <vector>
using namespace std;


//this method [only used when absolutely necessary] because it slows down the program.

int main()
{   
    vector <int> X={1,2,3,4,5};

    try
    {
        cout << X.at(6) <<endl; //here in the normal case the program well  closed and Crashed
                                // but when we use try\catch it well just show the error msg you add in the catch body
                                // instead of crashing.

    }catch(...)
    {
        cout<<"Error Message: overflow access..."<<endl;
    }


    return 0;
}