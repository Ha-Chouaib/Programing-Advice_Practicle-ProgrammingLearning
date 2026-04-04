#include<iostream>
#include"clsStack.h"

using namespace std;

int main()
{

    clsStack<short>STK;

    STK.push(1);
    STK.push(2);
    STK.push(3);
    STK.push(4);
    

    STK.print();

    cout<<"Stack Size: "<<STK.Size()<<endl;
    cout<<"First Node: "<<STK.Top()<<endl;
    cout<<"Last Node: "<<STK.Bottom()<<endl;

    STK.pop();

    cout<<"\nAfter Pop() method"<<endl;
    STK.print();

    cout<<"Stack Size: "<<STK.Size()<<endl;
    cout<<"First Node: "<<STK.Top()<<endl;
    cout<<"Last Node: "<<STK.Bottom()<<endl;

    cout<<"Get Item(2):"<<STK.GetItem(2)<<endl;

    cout<<"Update Item(0) By 100"<<endl;
    STK.UpdateItem(0,100);
    STK.print();

    cout<<"InsertAfter 200 After Item(1)"<<endl;
    STK.InsertAfter(1, 200);
    STK.print();

    cout<<"Insert At Top"<<endl;
    STK.InsertAtFront(0);
    STK.print();

    cout<<"Insert At Bottom 300"<<endl;
    STK.InsertAtBack(300);
    STK.print();

    cout<<"Clear Stack"<<endl;
    STK.Clear();
    STK.IsEmpty()? cout<<"The Stack Is Empty"<<endl : cout<<"The Stack Not Empty"<<endl;
    cout<<"Stack Size is: "<<STK.Size()<<endl;

    return 0;
}