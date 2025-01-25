#include<iostream>
using namespace std;

class Node
{
public:
    Node* Next;
    Node* Prev;
    short Value;
};


int main()
{
    Node* Head;
    Node *N1=NULL,*N2=NULL,*N3=NULL;

    N1=new Node();
    N2=new Node();
    N3=new Node();

    N1->Value=1;
    N2->Value=2;
    N3->Value=3;

    N1->Prev=NULL;
    N1->Next=N2;

    N2->Prev=N1;
    N2->Next=N3;

    N3->Prev=N2;
    N3->Next=NULL;

    Head=N1;

    cout<<"Go Next:\n";
    while(Head != NULL)
    {
        cout<< Head->Value <<" ";
        Head=Head->Next;
    }
    cout<<endl;
    cout<<"Go Previous:\n";
    Head=N3;
    while(Head != NULL)
    {
        cout<< Head->Value <<" ";
        Head=Head->Prev;
    }
    cout<<endl;
    

    return 0;
}