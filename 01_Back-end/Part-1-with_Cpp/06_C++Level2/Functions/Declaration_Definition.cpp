#include <iostream>
using namespace std;

//above the main function it's for declaration write the function under the main and declare it here.

void SumN(int,int); //--> Declare with the function head.

int main()
{
    SumN(1,3);
    return 0;
}
//Here for function definition for the body without declaration above the main well not run it ganna show an Error.


void SumN(int a, int b)
{
    cout<< (a+b) <<endl; 
}