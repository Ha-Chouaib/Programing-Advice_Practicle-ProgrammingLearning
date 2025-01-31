#include<iostream>
#include<stack>

using namespace std;

int main()
{
    stack <short> Stk1;
    stack <short> Stk2;

    Stk1.push(10);
    Stk1.push(20);
    Stk1.push(30);
    Stk1.push(40);
    Stk1.push(50);

    Stk2.push(60);
    Stk2.push(70);
    Stk2.push(80);
    Stk2.push(90);
    Stk2.push(100);

    cout<<"Before Swaping Method\n";

    cout<<"Stk1= ";
    while (!Stk1.empty())
    {
        cout<<Stk1.top()<<" ";
        Stk1.pop();
    }

    cout<<"\nStk2= ";
    while (!Stk2.empty())
    {
        cout<<Stk2.top()<<" ";
        Stk2.pop();
    }
    
    cout<<"\n\nAfter Swaping Method\n";

    Stk1.push(10);
    Stk1.push(20);
    Stk1.push(30);
    Stk1.push(40);
    Stk1.push(50);

    Stk2.push(60);
    Stk2.push(70);
    Stk2.push(80);
    Stk2.push(90);
    Stk2.push(100);

    Stk1.swap(Stk2);

    cout<<"Stk1= ";
    while (!Stk1.empty())
    {
        cout<<Stk1.top()<<" ";
        Stk1.pop();
    }
    
    cout<<"\nStk2= ";
    while (!Stk2.empty())
    {
        cout<<Stk2.top()<<" ";
        Stk2.pop();
    }
    
    return 0;
}