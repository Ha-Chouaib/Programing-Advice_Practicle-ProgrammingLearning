#include <iostream>
using namespace std;

void RecursionFunc(int N, int M)
{
    if(N <= M)
    {
        cout<< M <<endl;
        RecursionFunc(N, M-1);
    }
}

int PowerNOfM(int Base, int Power)
{
    
    if(Power == 0)
    {
        return 1;
    }else
    {
        return (Base *PowerNOfM(Base, Power-1));
    }

}
    

int main()
{
    RecursionFunc(1,10);
    cout<<"The Power:" << PowerNOfM(2,4);
    return 0;
}