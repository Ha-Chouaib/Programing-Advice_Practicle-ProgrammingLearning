#include<iostream>
#include<queue>

using namespace std;


int main()
{   
    //cTHe Oposite of Stack. 
    //Works By The Concept Of FIFO: First In Firt Out.
    queue <short>Q1,Q2;

    Q1.push(1);
    Q1.push(2);
    Q1.push(3);
    Q1.push(4);

    cout<<"Size: "<<Q1.size()<<endl;
    cout<<"Front: "<<Q1.front()<<endl;//The First Item In the Queue
    cout<<"Back: "<<Q1.back()<<endl;//The Last Item In the Queue.

    while (!Q1.empty())
    {
        cout<<Q1.front()<<endl;
        Q1.pop();
    }

    Q1.push(1);
    Q1.push(2);
    Q1.push(3);
    Q1.push(4);

    Q2.push(5);
    Q2.push(6);
    Q2.push(7);
    Q2.push(8);

    cout<<"Swap Queue\n";

    Q1.swap(Q2); //The Same As Stack Swap Method.
    

    return 0;
}