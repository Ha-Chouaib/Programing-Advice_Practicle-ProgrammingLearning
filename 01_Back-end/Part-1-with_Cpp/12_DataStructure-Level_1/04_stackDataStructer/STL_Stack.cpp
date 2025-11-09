#include<iostream>
#include<stack>

using namespace std;


int main()
{
    stack<short>StkNumbers;

    StkNumbers.push(10);
    StkNumbers.push(20);
    StkNumbers.push(30);
    StkNumbers.push(40);

    cout<<"StkNumbers Size: "<<StkNumbers.size()<<endl;

    while(!StkNumbers.empty())
    {
        cout<< StkNumbers.top()<<endl;//  The Concept Of LIFO: Last In First Out.
        StkNumbers.pop();
    }



    return 0;
}