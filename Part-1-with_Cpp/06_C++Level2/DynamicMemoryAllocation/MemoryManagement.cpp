#include <iostream>
using namespace std;


int main()
{   int * PtrX;
    float * PtrY;

    //Dynamicallay allocate the memory
    //--> here you take a temp space from the memory
    PtrX= new int;
    PtrY= new float; 

    //--> then assign values  to these spaces you taken
//!\\ But without defining the variables. like [int x;] (X)No ##Put the value directy into the pointer.  
    *PtrX= 12;
    *PtrY= 34.8;

    //-->Use the pointers value however you want.
    cout << *PtrX <<endl;
    cout << *PtrY <<endl;

    //--> After the values Done its Job Remove it from The Memory by [delete pointer name]
    delete PtrX;
    delete PtrY;

    //with that you well have a fast and powerfull program 
    return 0;
}