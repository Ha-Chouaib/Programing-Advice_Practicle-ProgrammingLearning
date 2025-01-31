#include<iostream>
#include"clsMyQuueu.h"

using namespace std;

int main()
{

clsMyQueue<short>Que;

    Que.push(1);
    Que.push(2);
    Que.push(3);
    Que.push(4);

    Que.print();

    cout<<"List Size: "<<Que.Size()<<endl;
    cout<<"First Node: "<<Que.Front()<<endl;
    cout<<"Last Node: "<<Que.Back()<<endl;

    Que.pop();

    cout<<"\nAfter Pop() method"<<endl;
    Que.print();

    cout<<"List Size: "<<Que.Size()<<endl;
    cout<<"First Node: "<<Que.Front()<<endl;
    cout<<"Last Node: "<<Que.Back()<<endl;

    cout<<"Get Item(2):"<<Que.GetItem(2);

    cout<<"Update Item(0) By 100"<<endl;
    Que.UpdateItem(0,100);
    Que.print();

    cout<<"InsertAfter 200 After Item(1)"<<endl;
    Que.InsertAfter(1, 200);
    Que.print();

    cout<<"Insert At Front"<<endl;
    Que.InsertAtFront(0);
    Que.print();

    cout<<"Insert At Back 300"<<endl;
    Que.InsertAtBack(300);
    Que.print();

    cout<<"Clear Queue"<<endl;
    Que.Clear();
    Que.IsEmpty()? cout<<"The Que Is Empty"<<endl : cout<<"The Que Not Empty"<<endl;
    cout<<"Queue Size is: "<<Que.Size()<<endl;

    return 0;
}