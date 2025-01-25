#include <iostream>
using namespace std;

/*in the normal case the local variable inside a function well be destroyed automatically by 
    the programe while the function finish execution.
But whe we add [static] to the variable well not be destroyed until the whole programe finished 
    so its value well be conserved in the memory even the scope live of the function is finished.
*/ 

void MyFunc()
{
    static int num=1;
    cout<<"Value of num: "<<num <<endl;
    num++;
}

int main()
{

    MyFunc();
    MyFunc();
    MyFunc();
    MyFunc();

    return 0;
}