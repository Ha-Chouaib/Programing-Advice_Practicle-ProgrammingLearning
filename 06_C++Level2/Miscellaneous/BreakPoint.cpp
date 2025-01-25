#include <iostream>
using namespace std;

int x(int a, int b)
{
    return a+b*100;
}
int main()
{
    int a,b,c,d;
    a=1;
    b=++a;
    c= a-b;
    d= c*b;
    x(a,b);
    for (int i = 0; i < a +b; i++)
    {
        c++;
    }
        d=c*b;
    cout<< a <<endl;
    cout<< b <<endl;
    cout<< c <<endl;
    cout<< d <<endl;

    return 0;
}